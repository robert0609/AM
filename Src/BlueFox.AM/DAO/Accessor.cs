using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;
using BlueFox.Security;
using System.Data;

namespace BlueFox.AM.DAO
{
    public sealed class Accessor : IDisposable
    {
        private string _fileName;

        private SQLiteConnection _con;

        public Accessor(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(string.Format("{0} doesn't exist, please connect U disk!", fileName));
            }
            this._fileName = fileName;
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
                cmd.CommandText = "Select g.rowid as Id, g.Id as GroupId, g.GroupName, s.Id as SiteId, s.SiteName, u.Id as UrlId, u.UrlString as URL, a.Id as AccId, a.UserName, a.Password from SiteGroup g left join Site s on g.Id = s.GroupId left join Url u on s.Id = u.SiteId left join Accout a on s.Id = a.SiteId order by g.rowid, s.SiteName";
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
                cmd.CommandText = "Select g.rowid as Id, g.Id as GroupId, g.GroupName, s.Id as SiteId, s.SiteName, u.Id as UrlId, u.UrlString as URL, a.Id as AccId, a.UserName, a.Password from SiteGroup g left join Site s on g.Id = s.GroupId left join Url u on s.Id = u.SiteId left join Accout a on s.Id = a.SiteId order by g.rowid, s.SiteName";
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
            if (this._con != null && this._con.State != System.Data.ConnectionState.Closed)
            {
                this._con.Close();
                this._con.Dispose();
                this._con = null;
            }
        }
    }
}
