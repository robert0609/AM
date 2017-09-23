using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlueFox.AM.UI;
using BlueFox.AM.DAO;
using System.Data;

namespace BlueFox.AM.BL
{
    public class AccountListBiz : IDisposable
    {
        public AccountList View
        {
            get;
            private set;
        }

        private Accessor _access;

        private IList<SiteGroup> _accountList;

        public AccountListBiz()
        {
            this.View = new AccountList(this);
            this._access = new Accessor(Global.DataFileName);
            this._access.Connect(Global.Password);
        }

        public void Reconnect()
        {
            this._access.Connect(Global.Password);
        }

        public void Run()
        {
            var dat = this.GetAccountList();
            //this.View.DataSource = dat;
            this.View.ShowDialog();
        }

        public DataTable GetAccountList()
        {
            //DataTable accList = this.InitDataSource();
            var datAccountTable = this._access.LoadTable();
            this._accountList = this._access.Load();
            //foreach (DataRow acc in dbDataTable.Rows)
            //{
            //    var r = accList.NewRow();
            //    r["Id"] = acc["rowid"];
            //    r["SiteName"] = acc["SiteName"];
            //    r["URL"] = acc["UrlString"];
            //    r["UserName"] = acc["UserName"];
            //    r["Password"] = acc["Password"];
            //    accList.Rows.Add(r);
            //}
            return datAccountTable;
        }

        private DataTable InitDataSource()
        {
            DataTable dat = new DataTable();
            dat.Columns.Add(new DataColumn("Id"));
            dat.Columns.Add(new DataColumn("SiteName"));
            dat.Columns.Add(new DataColumn("URL"));
            dat.Columns.Add(new DataColumn("UserName"));
            dat.Columns.Add(new DataColumn("Password"));
            return dat;
        }

        //public void DeleteAccount(IList<string> idList)
        //{
        //    if (this._datAccountTable == null)
        //    {
        //        return;
        //    }
        //    var delRows = this._datAccountTable.Select().Where(dr => idList.Contains(dr["Id"].ToString()));
        //    var delAccIds = delRows.Select(dr => dr["AccId"].ToString());
        //    foreach (var id in idList)
        //    {
        //        Site acc = new Site();
        //        acc["Id"] = id;
        //        this._access.Delete(acc);
        //    }
        //}

        //public string InsertAccount(Site acc)
        //{
        //    return this._access.Insert(acc);
        //}

        //public void UpdateAccount(Site acc)
        //{
        //    this._access.Update(acc);
        //}

        public void Dispose()
        {
            if (this._access != null)
            {
                this._access.Dispose();
                this._access = null;
            }
        }
    }
}
