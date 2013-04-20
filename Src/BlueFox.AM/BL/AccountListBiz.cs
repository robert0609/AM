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
    public class AccountListBiz
    {
        public AccountList View
        {
            get;
            private set;
        }

        public AccountListBiz()
        {
            this.View = new AccountList();
        }

        public void Run()
        {
            var dat = this.GetAccountList();
            this.View.DataSource = dat;
            this.View.ShowDialog();
            //Application.Run(this.View);
        }

        private DataTable GetAccountList()
        {
            DataTable accList = this.InitDataSource();
            using (Accessor access = new Accessor(Global.DataFileName))
            {
                access.Connect(Global.Password);
                var lst = access.Select(new Condition());
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
    }
}
