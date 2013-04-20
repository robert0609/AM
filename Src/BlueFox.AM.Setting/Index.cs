using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BlueFox.Security;
using System.IO;
using System.Data.SQLite;

namespace BlueFox.AM.Setting
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
            this.Load += new EventHandler(Index_Load);
            this.btnGenerate.Click += new EventHandler(btnGenerate_Click);
            this.btnGenerateAuth.Click += new EventHandler(btnGenerateAuth_Click);
            this.btnRegister.Click += new EventHandler(btnRegister_Click);
        }

        private void Index_Load(object sender, EventArgs e)
        {
            this.txtCurrentPrivateKeyFile.Text = ConfigurationManager.AppSettings["CurrentPrivateKeyFile"];
            this.txtCurrentPublicKeyFile.Text = ConfigurationManager.AppSettings["CurrentPublicKeyFile"];
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                Common.Cert = new Certificates();
                this.txtCurrentPrivateKeyFile.Text = Common.Cert.Export(Common.BaseDir, true);
                this.txtCurrentPublicKeyFile.Text = Common.Cert.Export(Common.BaseDir, false);
                Common.SetAppSetting("CurrentPrivateKeyFile", this.txtCurrentPrivateKeyFile.Text);
                Common.SetAppSetting("CurrentPublicKeyFile", this.txtCurrentPublicKeyFile.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateAuth_Click(object sender, EventArgs e)
        {
            try
            {
                var uniqueId = Guid.NewGuid().ToString();
                var signed = Common.Cert.Sign(uniqueId);
                var fileName = Common.BaseDir + uniqueId + ".auth";
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8))
                {
                    sw.WriteLine(uniqueId);
                    sw.WriteLine(signed);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtUserName.Text) || string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    throw new ArgumentNullException("Please input UserName or Password!");
                }
                var fileName = Common.BaseDir + this.txtUserName.Text + ".am";
                SQLiteConnection.CreateFile(fileName);
                //建立数据库连接并打开数据库
                using (SQLiteConnection conn = new SQLiteConnection())
                {
                    SQLiteConnectionStringBuilder connsb = new SQLiteConnectionStringBuilder();
                    connsb.DataSource = fileName;
                    connsb.Password = this.txtPassword.Text;
                    conn.ConnectionString = connsb.ToString();
                    conn.Open();
                    //创建表
                    using (SQLiteCommand cmd = new SQLiteCommand("Create table Account(Id varchar(36) primary key, SiteName varchar(100), URL varchar(100), UserName varchar(20), Password varchar(20))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand("Create table MetaInfo(Id varchar(36))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    //插入验证数据
                    using (SQLiteCommand cmd = new SQLiteCommand(string.Format("Insert into MetaInfo values('{0}')", this.txtUserName.Text), conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
