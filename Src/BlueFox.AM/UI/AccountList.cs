using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlueFox.AM.DAO;
using BlueFox.AM.BL;

namespace BlueFox.AM.UI
{
    public partial class AccountList : BaseForm
    {
        public IList<SiteGroup> AccountGroupList
        {
            get; set;
        }

        private AccountListBiz _biz;

        private bool _isExitMenuClicked;

        public AccountList(AccountListBiz biz) : base()
        {
            InitializeComponent();
            this._isExitMenuClicked = false;
            this._biz = biz;
            this.RemovableDrivePulled += new DelegateRemovableDrivePulled(AccountList_RemovableDrivePulled);
            this.RemovableDriveArrived += new DelegateRemovableDriveArrived(AccountList_RemovableDriveArrived);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.DataSource = null;
            this._isExitMenuClicked = true;
            this.Close();
        }

        private void AccountList_RemovableDriveArrived(object sender, RemovableDriveEventArgs e)
        {
            this._biz.Reconnect();
            //this.DataSource = this._biz.GetAccountList();
        }

        private void AccountList_RemovableDrivePulled(object sender, RemovableDriveEventArgs e)
        {
            //this.DataSource = null;
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Text += Global.UserName;
            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!this._isExitMenuClicked)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
            base.OnClosing(e);
        }
    }
}
