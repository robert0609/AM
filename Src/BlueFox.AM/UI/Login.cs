using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlueFox.AM.BL;
using System.IO;

namespace BlueFox.AM.UI
{
    public partial class Login : BaseForm
    {
        public bool DoLogin
        {
            get;
            private set;
        }

        public string UserName
        {
            get
            {
                return this.txtUid.Text;
            }
        }

        public string Password
        {
            get
            {
                return this.txtPwd.Text;
            }
        }

        public string DataFileName
        {
            get;
            private set;
        }

        public Login()
        {
            InitializeComponent();
            this.Load += new EventHandler(Login_Load);
            this.btnLogin.Click += new EventHandler(btnLogin_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.DoLogin = false;
            this.txtUid.Text = "robert0609";
            this.txtPwd.Text = "19750903";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtUid.Text))
                {
                    MessageBox.Show("Please input UserName!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtUid.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtPwd.Text))
                {
                    MessageBox.Show("Please input Password!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPwd.Focus();
                    return;
                }
                this.DataFileName = this.FindDataFile();
                if (string.IsNullOrEmpty(this.DataFileName))
                {
                    return;
                }
                this.DoLogin = true; ;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FindDataFile()
        {
            if (this.currentRemovableDrives != null && this.currentRemovableDrives.Count > 0)
            {
                var template = "{0}" + this.txtUid.Text + Global.DATAFILE_EX;
                foreach (var loop in this.currentRemovableDrives)
                {
                    var fileName = string.Format(template, loop.RootDirectory.FullName);
                    if (File.Exists(fileName))
                    {
                        return fileName;
                    }
                }
            }
            MessageBox.Show("AM didn't find data file,please connect U disk!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.btnLogin.Focus();
            return null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
