using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;
using BlueFox.Security;
using System.Data;
using System.Configuration;

namespace BlueFox.AM.DAO
{
    public sealed class Accessor : IDisposable
    {
        private string _fileName;

        private SQLiteConnection _con;

        public Accessor() : this(AppDomain.CurrentDomain.BaseDirectory + "\\" + ConfigurationManager.AppSettings["DataFileName"])
        {
        }

        public Accessor(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(string.Format("{0} doesn't exist, please connect U disk!", fileName));
            }
            this._fileName = fileName;
        }

        public void Connect()
        {
            this.Connect(ConfigurationManager.AppSettings["DataPassword"]);
        }

        public void Connect(string pwd)
        {
            this._con = new SQLiteConnection();
            SQLiteConnectionStringBuilder connsb = new SQLiteConnectionStringBuilder();
            connsb.DataSource = this._fileName;
            connsb.Password = pwd;
            this._con.ConnectionString = connsb.ToString();
            this._con.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(this._con))
            {
                cmd.CommandText = "Select * from MetaInfo";
                cmd.ExecuteReader();
            }
        }

        public DataTable LoadTable()
        {
            DataTable ret = new DataTable();
            using (SQLiteCommand cmd = new SQLiteCommand(this._con))
            {
                cmd.CommandText = "Select g.rowid as Id, g.Id as GroupId, g.GroupName, s.Id as SiteId, s.SiteName, u.Id as UrlId, u.UrlString as URL, a.Id as AccId, a.UserName, a.Password from SiteGroup g left join Site s on g.Id = s.GroupId left join Url u on s.Id = u.SiteId left join Account a on s.Id = a.SiteId order by g.rowid, s.SiteName";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                var count = adapter.Fill(ret);
            }
            return ret;
        }

        public IList<SiteGroup> Load()
        {
            IList<SiteGroup> ret = new List<SiteGroup>();
            using (SQLiteCommand cmd = new SQLiteCommand(this._con))
            {
                cmd.CommandText = "Select g.rowid as Id, g.Id as GroupId, g.GroupName, s.Id as SiteId, s.SiteName, u.Id as UrlId, u.UrlString as URL, a.Id as AccId, a.UserName, a.Password from SiteGroup g left join Site s on g.Id = s.GroupId left join Url u on s.Id = u.SiteId left join Account a on s.Id = a.SiteId order by g.rowid, s.SiteName";
                #region test
                //DataTable dat = new DataTable();
                //SQLiteDataAdapter ada = new SQLiteDataAdapter(cmd);
                //var cnt = ada.Fill(dat);
                #endregion
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    var grpId = dataReader["GroupId"].ToString();
                    var grp = (from loop in ret where loop.Id == grpId select loop).FirstOrDefault();
                    if (grp == null)
                    {
                        grp = new SiteGroup(grpId, dataReader["GroupName"].ToString());
                        ret.Add(grp);
                    }
                    if (dataReader["SiteId"] != null && dataReader["SiteId"] != DBNull.Value && !string.IsNullOrEmpty(dataReader["SiteId"].ToString()))
                    {
                        var siteId = dataReader["SiteId"].ToString();
                        var site = (from loop in grp.SiteList where loop.Id == siteId select loop).FirstOrDefault();
                        if (site == null)
                        {
                            site = new Site(siteId, dataReader["SiteName"].ToString(), grpId);
                            grp.SiteList.Add(site);
                        }
                        if (dataReader["UrlId"] != null && dataReader["UrlId"] != DBNull.Value && !string.IsNullOrEmpty(dataReader["UrlId"].ToString()))
                        {
                            var urlId = dataReader["UrlId"].ToString();
                            var url = (from loop in site.UrlList where loop.Id == urlId select loop).FirstOrDefault();
                            if (url == null)
                            {
                                url = new Url(urlId, dataReader["UrlString"].ToString(), siteId);
                                site.UrlList.Add(url);
                            }
                        }
                        if (dataReader["AccId"] != null && dataReader["AccId"] != DBNull.Value && !string.IsNullOrEmpty(dataReader["AccId"].ToString()))
                        {
                            var accId = dataReader["AccId"].ToString();
                            var acc = (from loop in site.AccountList where loop.Id == accId select loop).FirstOrDefault();
                            if (acc == null)
                            {
                                acc = new Account(accId, dataReader["UserName"].ToString(), dataReader["Password"].ToString(), siteId);
                                site.AccountList.Add(acc);
                            }
                        }
                    }
                }
            }
            return ret;
        }

        public IList<SiteGroup> LoadSiteGroups()
        {
            IList<SiteGroup> ret = new List<SiteGroup>();
            using (SQLiteCommand cmd = new SQLiteCommand(this._con))
            {
                cmd.CommandText = "Select * from SiteGroup";
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    var grp = new SiteGroup(dataReader["Id"].ToString(), dataReader["GroupNamme"].ToString());
                    ret.Add(grp);
                }
            }
            return ret;
        }

        public SiteGroup LoadSiteGroup(string siteGroupId)
        {
            SiteGroup ret = null;
            using (SQLiteCommand cmd = new SQLiteCommand(this._con))
            {
                StringBuilder sb = new StringBuilder("Select * from SiteGroup Where Id = @SiteGroupId");
                SQLiteParameter p1 = new SQLiteParameter("SiteGroupId", DbType.String);
                p1.Value = siteGroupId;
                cmd.Parameters.Add(p1);
                cmd.CommandText = sb.ToString();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    ret = new SiteGroup(dataReader["Id"].ToString(), dataReader["GroupName"].ToString());
                }
            }
            return ret == null ? (string.IsNullOrEmpty(siteGroupId) ? new SiteGroup() : new SiteGroup(siteGroupId)) : ret;
        }

        public IList<Site> LoadSites(string siteGroupId)
        {
            IList<Site> ret = new List<Site>();
            using (SQLiteCommand cmd = new SQLiteCommand(this._con))
            {
                StringBuilder sb = new StringBuilder("Select * from Site Where GroupId = @SiteGroupId");
                SQLiteParameter p1 = new SQLiteParameter("SiteGroupId", DbType.String);
                p1.Value = siteGroupId;
                cmd.Parameters.Add(p1);
                cmd.CommandText = sb.ToString();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    var site = new Site(dataReader["Id"].ToString(), dataReader["SiteName"].ToString(), dataReader["GroupId"].ToString());
                    ret.Add(site);
                }
            }
            return ret;
        }

        public Site LoadSite(string siteId, string siteGroupId = null)
        {
            Site ret = null;
            using (SQLiteCommand cmd = new SQLiteCommand(this._con))
            {
                StringBuilder sb = new StringBuilder("Select * from Site Where Id = @SiteId");
                SQLiteParameter p1 = new SQLiteParameter("SiteId", DbType.String);
                p1.Value = siteId;
                cmd.Parameters.Add(p1);
                if (!string.IsNullOrEmpty(siteGroupId))
                {
                    sb = sb.Append(" and GroupId = @GroupId");
                    SQLiteParameter p2 = new SQLiteParameter("GroupId", DbType.String);
                    p2.Value = siteGroupId;
                    cmd.Parameters.Add(p2);
                }

                cmd.CommandText = sb.ToString();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    ret = new Site(dataReader["Id"].ToString(), dataReader["SiteName"].ToString(), dataReader["GroupId"].ToString());
                }
                if (ret != null)
                {
                    using (SQLiteCommand cmd2 = new SQLiteCommand(this._con))
                    {
                        StringBuilder sb2 = new StringBuilder("Select * from Url Where SiteId = @SiteId");
                        SQLiteParameter p2 = new SQLiteParameter("SiteId", DbType.String);
                        p2.Value = siteId;
                        cmd2.Parameters.Add(p2);
                        cmd2.CommandText = sb2.ToString();
                        dataReader = cmd2.ExecuteReader();
                        while (dataReader.Read())
                        {
                            var url = new Url(dataReader["Id"].ToString(), dataReader["UrlString"].ToString(), dataReader["SiteId"].ToString());
                            ret.UrlList.Add(url);
                        }
                    }

                    using (SQLiteCommand cmd3 = new SQLiteCommand(this._con))
                    {
                        StringBuilder sb3 = new StringBuilder("Select * from Account Where SiteId = @SiteId");
                        SQLiteParameter p3 = new SQLiteParameter("SiteId", DbType.String);
                        p3.Value = siteId;
                        cmd3.Parameters.Add(p3);
                        cmd3.CommandText = sb.ToString();
                        dataReader = cmd3.ExecuteReader();
                        while (dataReader.Read())
                        {
                            var account = new Account(dataReader["Id"].ToString(), dataReader["UserName"].ToString(), dataReader["Password"].ToString(), dataReader["SiteId"].ToString());
                            ret.AccountList.Add(account);
                        }
                    }
                }
            }
            if (ret == null)
            {
                ret = string.IsNullOrEmpty(siteId) ? new Site() : new Site(siteId);
                if (!string.IsNullOrEmpty(siteGroupId))
                {
                    ret.GroupId = siteGroupId;
                }
            }
            return ret;
        }

        public Url LoadUrl(string urlId, string siteId = null)
        {
            Url ret = null;
            using (SQLiteCommand cmd = new SQLiteCommand(this._con))
            {
                StringBuilder sb = new StringBuilder("Select * from Url Where Id = @UrlId");
                SQLiteParameter p1 = new SQLiteParameter("UrlId", DbType.String);
                p1.Value = urlId;
                cmd.Parameters.Add(p1);
                if (!string.IsNullOrEmpty(siteId))
                {
                    sb = sb.Append(" and SiteId = @SiteId");
                    SQLiteParameter p2 = new SQLiteParameter("SiteId", DbType.String);
                    p2.Value = siteId;
                    cmd.Parameters.Add(p2);
                }
                cmd.CommandText = sb.ToString();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    ret = new Url(dataReader["Id"].ToString(), dataReader["UrlString"].ToString(), dataReader["SiteId"].ToString());
                }
            }
            if (ret == null)
            {
                ret = string.IsNullOrEmpty(urlId) ? new Url() : new Url(urlId);
                if (!string.IsNullOrEmpty(siteId))
                {
                    ret.SiteId = siteId;
                }
            }
            return ret;
        }

        public Account LoadAccount(string accountId, string siteId = null)
        {
            Account ret = null;
            using (SQLiteCommand cmd = new SQLiteCommand(this._con))
            {
                StringBuilder sb = new StringBuilder("Select * from Account Where Id = @AccountId");
                SQLiteParameter p1 = new SQLiteParameter("AccountId", DbType.String);
                p1.Value = accountId;
                cmd.Parameters.Add(p1);
                if (!string.IsNullOrEmpty(siteId))
                {
                    sb = sb.Append(" and SiteId = @SiteId");
                    SQLiteParameter p2 = new SQLiteParameter("SiteId", DbType.String);
                    p2.Value = siteId;
                    cmd.Parameters.Add(p2);
                }
                cmd.CommandText = sb.ToString();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    ret = new Account(dataReader["Id"].ToString(), dataReader["UserName"].ToString(), dataReader["Password"].ToString(), dataReader["SiteId"].ToString());
                }
            }
            if (ret == null)
            {
                ret = string.IsNullOrEmpty(accountId) ? new Account() : new Account(accountId);
                if (!string.IsNullOrEmpty(siteId))
                {
                    ret.SiteId = siteId;
                }
            }
            return ret;
        }

        public void ExecuteUID(string cmdString)
        {
            SQLiteTransaction tran = this._con.BeginTransaction();
            SQLiteCommand cmd = new SQLiteCommand(this._con);
            try
            {
                cmd.CommandText = cmdString;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                cmd.Dispose();
                tran.Dispose();
            }
        }

        public void Dispose()
        {
            //if (this._con != null && this._con.State != System.Data.ConnectionState.Closed)
            if (this._con != null)
            {
                this._con.Close();
                //this._con.Dispose();
                this._con = null;
            }
        }
    }
}
