using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Text;

namespace BlueFox.AM.Web.DAO
{
    public class AccessHelper
    {
        private readonly static OleDbConnection _con = new OleDbConnection(@"Provider='Microsoft.ACE.OLEDB.12.0';Data Source='D:\GitSpace\AM\Src\BlueFox.AM.Web\bluefox.accdb'");

        public static SiteGroup LoadSiteGroupById(string siteGroupId = null)
        {
            SiteGroup ret = null;
            if (!string.IsNullOrEmpty(siteGroupId))
            {
                OleDbCommand cmd = new OleDbCommand("Select * from SiteGroup Where Id = @SiteGroupId", _con);
                try
                {
                    _con.Open();
                    OleDbParameter p1 = new OleDbParameter("SiteGroupId", DbType.String);
                    p1.Value = siteGroupId;
                    cmd.Parameters.Add(p1);
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ret = new SiteGroup { Id = dataReader["Id"].ToString(), GroupName = dataReader["GroupName"].ToString(), SiteList = new List<Site>() };
                    }
                }
                finally
                {
                    cmd.Dispose();
                    _con.Close();
                }
            }
            if (ret == null)
            {
                ret = new SiteGroup { SiteList = new List<Site>() };
                if (string.IsNullOrEmpty(siteGroupId))
                {
                    ret.Id = Guid.NewGuid().ToString();
                }
                else
                {
                    ret.Id = siteGroupId;
                }
            }

            return ret;
        }

        public static IList<SiteGroup> LoadSiteGroup()
        {
            IList<SiteGroup> ret = new List<SiteGroup>();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = _con;
            StringBuilder cmdTxt = new StringBuilder("Select * from SiteGroup");
            cmd.CommandText = cmdTxt.ToString();

            try
            {
                _con.Open();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    ret.Add(new SiteGroup { Id = dataReader["Id"].ToString(), GroupName = dataReader["GroupName"].ToString(), SiteList = new List<Site>() });
                }
            }
            finally
            {
                cmd.Dispose();
                _con.Close();
            }

            return ret;
        }

        public static int SaveSiteGroup(string id, string groupName)
        {
            int ret = 0;
            _con.Open();
            OleDbCommand cmd = new OleDbCommand("Select Count(*) from SiteGroup Where Id = @SiteGroupId", _con);
            OleDbParameter p1 = new OleDbParameter("SiteGroupId", DbType.String);
            p1.Value = id;
            cmd.Parameters.Add(p1);
            var n = (int)cmd.ExecuteScalar();

            var tran = _con.BeginTransaction();
            try
            {
                if (n > 0)
                {
                    using (OleDbCommand cmd2 = new OleDbCommand("Update SiteGroup set GroupName = @GroupName where Id = @SiteGroupId", _con, tran))
                    {
                        OleDbParameter p3 = new OleDbParameter("GroupName", DbType.String);
                        p3.Value = groupName;
                        cmd2.Parameters.Add(p3);
                        OleDbParameter p2 = new OleDbParameter("SiteGroupId", DbType.String);
                        p2.Value = id;
                        cmd2.Parameters.Add(p2);

                        ret = cmd2.ExecuteNonQuery();
                        tran.Commit();
                    }
                }
                else
                {
                    using (OleDbCommand cmd2 = new OleDbCommand("Insert into SiteGroup(Id, GroupName) values(@SiteGroupId, @GroupName)", _con, tran))
                    {
                        OleDbParameter p2 = new OleDbParameter("SiteGroupId", DbType.String);
                        p2.Value = id;
                        cmd2.Parameters.Add(p2);
                        OleDbParameter p3 = new OleDbParameter("GroupName", DbType.String);
                        p3.Value = groupName;
                        cmd2.Parameters.Add(p3);

                        ret = cmd2.ExecuteNonQuery();
                        tran.Commit();
                    }
                }
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                cmd.Dispose();
                _con.Close();
            }

            return ret;
        }

        public static Site LoadSiteById(string siteId = null)
        {
            Site ret = null;
            if (!string.IsNullOrEmpty(siteId))
            {
                OleDbCommand cmd = new OleDbCommand("Select * from Site Where Id = @SiteId", _con);
                try
                {
                    _con.Open();
                    OleDbParameter p1 = new OleDbParameter("SiteId", DbType.String);
                    p1.Value = siteId;
                    cmd.Parameters.Add(p1);
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ret = new Site { Id = dataReader["Id"].ToString(), SiteName = dataReader["SiteName"].ToString(), GroupId = dataReader["GroupId"].ToString(), UrlList = new List<Url>(), AccountList = new List<Account>() };
                    }
                }
                finally
                {
                    cmd.Dispose();
                    _con.Close();
                }
            }
            if (ret == null)
            {
                ret = new Site { UrlList = new List<Url>(), AccountList = new List<Account>() };
                if (string.IsNullOrEmpty(siteId))
                {
                    ret.Id = Guid.NewGuid().ToString();
                }
                else
                {
                    ret.Id = siteId;
                }
            }

            return ret;
        }

        public static IList<Site> LoadSite(string siteGroupId = null)
        {
            IList<Site> ret = new List<Site>();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = _con;
            StringBuilder cmdTxt = new StringBuilder("Select * from Site");
            StringBuilder whereTxt = new StringBuilder();
            if (!string.IsNullOrEmpty(siteGroupId))
            {
                OleDbParameter p = new OleDbParameter("GroupId", DbType.String);
                p.Value = siteGroupId;
                cmd.Parameters.Add(p);

                whereTxt.Append(" where GroupId = @GroupId");
            }
            cmd.CommandText = cmdTxt.ToString() + whereTxt.ToString();

            try
            {
                _con.Open();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    ret.Add(new Site { Id = dataReader["Id"].ToString(), SiteName = dataReader["SiteName"].ToString(), GroupId = dataReader["GroupId"].ToString(), UrlList = new List<Url>(), AccountList = new List<Account>() });
                }
            }
            finally
            {
                cmd.Dispose();
                _con.Close();
            }
            
            return ret;
        }

        public static int SaveSite(string id, string siteName, string siteGroupId)
        {
            int ret = 0;
            _con.Open();
            OleDbCommand cmd = new OleDbCommand("Select Count(*) from Site Where Id = @SiteId", _con);
            OleDbParameter p1 = new OleDbParameter("SiteId", DbType.String);
            p1.Value = id;
            cmd.Parameters.Add(p1);
            var n = (int)cmd.ExecuteScalar();

            var tran = _con.BeginTransaction();
            try
            {
                if (n > 0)
                {
                    using (OleDbCommand cmd2 = new OleDbCommand("Update Site set SiteName = @SiteName, GroupId = @GroupId where Id = @SiteId", _con, tran))
                    {
                        OleDbParameter p3 = new OleDbParameter("SiteName", DbType.String);
                        p3.Value = siteName;
                        cmd2.Parameters.Add(p3);
                        OleDbParameter p4 = new OleDbParameter("GroupId", DbType.String);
                        p4.Value = siteGroupId;
                        cmd2.Parameters.Add(p4);
                        OleDbParameter p2 = new OleDbParameter("SiteId", DbType.String);
                        p2.Value = id;
                        cmd2.Parameters.Add(p2);

                        ret = cmd2.ExecuteNonQuery();
                        tran.Commit();
                    }
                }
                else
                {
                    using (OleDbCommand cmd2 = new OleDbCommand("Insert into Site(Id, SiteName, GroupId) values(@SiteId, @SiteName, @GroupId)", _con, tran))
                    {
                        OleDbParameter p2 = new OleDbParameter("SiteId", DbType.String);
                        p2.Value = id;
                        cmd2.Parameters.Add(p2);
                        OleDbParameter p3 = new OleDbParameter("SiteName", DbType.String);
                        p3.Value = siteName;
                        cmd2.Parameters.Add(p3);
                        OleDbParameter p4 = new OleDbParameter("GroupId", DbType.String);
                        p4.Value = siteGroupId;
                        cmd2.Parameters.Add(p4);

                        ret = cmd2.ExecuteNonQuery();
                        tran.Commit();
                    }
                }
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                cmd.Dispose();
                _con.Close();
            }

            return ret;
        }

        public static Url LoadUrlById(string urlId = null)
        {
            Url ret = null;
            if (!string.IsNullOrEmpty(urlId))
            {
                OleDbCommand cmd = new OleDbCommand("Select * from Url Where Id = @UrlId", _con);
                try
                {
                    _con.Open();
                    OleDbParameter p1 = new OleDbParameter("UrlId", DbType.String);
                    p1.Value = urlId;
                    cmd.Parameters.Add(p1);
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ret = new Url { Id = dataReader["Id"].ToString(), UrlString = dataReader["UrlString"].ToString(), SiteId = dataReader["SiteId"].ToString() };
                    }
                }
                finally
                {
                    cmd.Dispose();
                    _con.Close();
                }
            }
            if (ret == null)
            {
                ret = new Url();
                if (string.IsNullOrEmpty(urlId))
                {
                    ret.Id = Guid.NewGuid().ToString();
                }
                else
                {
                    ret.Id = urlId;
                }
            }

            return ret;
        }

        public static IList<Url> LoadUrl(string siteId = null)
        {
            IList<Url> ret = new List<Url>();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = _con;
            StringBuilder cmdTxt = new StringBuilder("Select * from Url");
            StringBuilder whereTxt = new StringBuilder();
            if (!string.IsNullOrEmpty(siteId))
            {
                OleDbParameter p = new OleDbParameter("SiteId", DbType.String);
                p.Value = siteId;
                cmd.Parameters.Add(p);

                whereTxt.Append(" where SiteId = @SiteId");
            }
            cmd.CommandText = cmdTxt.ToString() + whereTxt.ToString();

            try
            {
                _con.Open();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    ret.Add(new Url { Id = dataReader["Id"].ToString(), UrlString = dataReader["UrlString"].ToString(), SiteId = dataReader["SiteId"].ToString() });
                }
            }
            finally
            {
                cmd.Dispose();
                _con.Close();
            }

            return ret;
        }

        public static int SaveUrl(string id, string url, string siteId)
        {
            int ret = 0;
            _con.Open();
            OleDbCommand cmd = new OleDbCommand("Select Count(*) from Url Where Id = @UrlId", _con);
            OleDbParameter p1 = new OleDbParameter("UrlId", DbType.String);
            p1.Value = id;
            cmd.Parameters.Add(p1);
            var n = (int)cmd.ExecuteScalar();

            var tran = _con.BeginTransaction();
            try
            {
                if (n > 0)
                {
                    using (OleDbCommand cmd2 = new OleDbCommand("Update Url set UrlString = @UrlString, SiteId = @SiteId where Id = @UrlId", _con, tran))
                    {
                        OleDbParameter p3 = new OleDbParameter("UrlString", DbType.String);
                        p3.Value = url;
                        cmd2.Parameters.Add(p3);
                        OleDbParameter p4 = new OleDbParameter("SiteId", DbType.String);
                        p4.Value = siteId;
                        cmd2.Parameters.Add(p4);
                        OleDbParameter p2 = new OleDbParameter("UrlId", DbType.String);
                        p2.Value = id;
                        cmd2.Parameters.Add(p2);

                        ret = cmd2.ExecuteNonQuery();
                        tran.Commit();
                    }
                }
                else
                {
                    using (OleDbCommand cmd2 = new OleDbCommand("Insert into Site(Id, UrlString, SiteId) values(@UrlId, @UrlString, @SiteId)", _con, tran))
                    {
                        OleDbParameter p2 = new OleDbParameter("UrlId", DbType.String);
                        p2.Value = id;
                        cmd2.Parameters.Add(p2);
                        OleDbParameter p3 = new OleDbParameter("UrlString", DbType.String);
                        p3.Value = url;
                        cmd2.Parameters.Add(p3);
                        OleDbParameter p4 = new OleDbParameter("SiteId", DbType.String);
                        p4.Value = siteId;
                        cmd2.Parameters.Add(p4);

                        ret = cmd2.ExecuteNonQuery();
                        tran.Commit();
                    }
                }
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                cmd.Dispose();
                _con.Close();
            }

            return ret;
        }

        public static Account LoadAccountById(string accountId = null)
        {
            Account ret = null;
            if (!string.IsNullOrEmpty(accountId))
            {
                OleDbCommand cmd = new OleDbCommand("Select * from Account Where Id = @AccountId", _con);
                try
                {
                    _con.Open();
                    OleDbParameter p1 = new OleDbParameter("AccountId", DbType.String);
                    p1.Value = accountId;
                    cmd.Parameters.Add(p1);
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ret = new Account { Id = dataReader["Id"].ToString(), UserName = dataReader["UserName"].ToString(), Password = dataReader["Password"].ToString(), SiteId = dataReader["SiteId"].ToString() };
                    }
                }
                finally
                {
                    cmd.Dispose();
                    _con.Close();
                }
            }
            if (ret == null)
            {
                ret = new Account();
                if (string.IsNullOrEmpty(accountId))
                {
                    ret.Id = Guid.NewGuid().ToString();
                }
                else
                {
                    ret.Id = accountId;
                }
            }

            return ret;
        }

        public static IList<Account> LoadAccount(string siteId = null)
        {
            IList<Account> ret = new List<Account>();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = _con;
            StringBuilder cmdTxt = new StringBuilder("Select * from Account");
            StringBuilder whereTxt = new StringBuilder();
            if (!string.IsNullOrEmpty(siteId))
            {
                OleDbParameter p = new OleDbParameter("SiteId", DbType.String);
                p.Value = siteId;
                cmd.Parameters.Add(p);

                whereTxt.Append(" where SiteId = @SiteId");
            }
            cmd.CommandText = cmdTxt.ToString() + whereTxt.ToString();

            try
            {
                _con.Open();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    ret.Add(new Account { Id = dataReader["Id"].ToString(), UserName = dataReader["UserName"].ToString(), Password = dataReader["Password"].ToString(), SiteId = dataReader["SiteId"].ToString() });
                }
            }
            finally
            {
                cmd.Dispose();
                _con.Close();
            }

            return ret;
        }

        public static int SaveAccount(string id, string username, string password, string siteId)
        {
            int ret = 0;
            _con.Open();
            OleDbCommand cmd = new OleDbCommand("Select Count(*) from Account Where Id = @AccountId", _con);
            OleDbParameter p1 = new OleDbParameter("AccountId", DbType.String);
            p1.Value = id;
            cmd.Parameters.Add(p1);
            var n = (int)cmd.ExecuteScalar();

            var tran = _con.BeginTransaction();
            try
            {
                if (n > 0)
                {
                    using (OleDbCommand cmd2 = new OleDbCommand("Update Account set UserName = @UserName, Password = @Password, SiteId = @SiteId where Id = @AccountId", _con, tran))
                    {
                        OleDbParameter p3 = new OleDbParameter("UserName", DbType.String);
                        p3.Value = username;
                        cmd2.Parameters.Add(p3);
                        OleDbParameter p5 = new OleDbParameter("Password", DbType.String);
                        p5.Value = password;
                        cmd2.Parameters.Add(p5);
                        OleDbParameter p4 = new OleDbParameter("SiteId", DbType.String);
                        p4.Value = siteId;
                        cmd2.Parameters.Add(p4);
                        OleDbParameter p2 = new OleDbParameter("AccountId", DbType.String);
                        p2.Value = id;
                        cmd2.Parameters.Add(p2);

                        ret = cmd2.ExecuteNonQuery();
                        tran.Commit();
                    }
                }
                else
                {
                    using (OleDbCommand cmd2 = new OleDbCommand("Insert into Account(Id, UserName, Password, SiteId) values(@AccountId, @UserName, @Password, @SiteId)", _con, tran))
                    {
                        OleDbParameter p2 = new OleDbParameter("AccountId", DbType.String);
                        p2.Value = id;
                        cmd2.Parameters.Add(p2);
                        OleDbParameter p3 = new OleDbParameter("UserName", DbType.String);
                        p3.Value = username;
                        cmd2.Parameters.Add(p3);
                        OleDbParameter p5 = new OleDbParameter("Password", DbType.String);
                        p5.Value = password;
                        cmd2.Parameters.Add(p5);
                        OleDbParameter p4 = new OleDbParameter("SiteId", DbType.String);
                        p4.Value = siteId;
                        cmd2.Parameters.Add(p4);

                        ret = cmd2.ExecuteNonQuery();
                        tran.Commit();
                    }
                }
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                cmd.Dispose();
                _con.Close();
            }

            return ret;
        }
    }

    public class SiteGroup
    {
        public string Id { get; set; }
        public string GroupName { get; set; }
        public IList<Site> SiteList
        {
            get;
            set;
        }
    }

    public class Site
    {
        public string Id { get; set; }
        public string SiteName { get; set; }
        public string GroupId { get; set; }
        public IList<Url> UrlList
        {
            get;
            set;
        }

        public IList<Account> AccountList
        {
            get;
            set;
        }
    }

    public class Url
    {
        public string Id { get; set; }
        public string UrlString { get; set; }
        public string SiteId { get; set; }
    }

    public class Account
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SiteId { get; set; }
    }
}