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
            this.View.DataSource = dat;
            this.View.ShowDialog();
        }

        public DataTable GetAccountList()
        {
            DataTable accList = this.InitDataSource();
            var lst = this._access.Select(new Condition());
            foreach (var acc in lst)
            {
                var r = accList.NewRow();
                r["Id"] = acc.Id;
                r["SiteName"] = acc.SiteName;
                r["URL"] = acc.URL;
                r["UserName"] = acc.UserName;
                r["Password"] = acc.Password;
                accList.Rows.Add(r);
            }
            return accList;
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

        public void DeleteAccount(IList<string> idList)
        {
            foreach (var id in idList)
            {
                Account acc = new Account();
                acc["Id"] = id;
                this._access.Delete(acc);
            }
        }

        public string InsertAccount(Account acc)
        {
            return this._access.Insert(acc);
        }

        public void UpdateAccount(Account acc)
        {
            this._access.Update(acc);
        }

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
