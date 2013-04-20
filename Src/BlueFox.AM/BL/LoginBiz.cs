using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlueFox.AM.UI;
using BlueFox.AM.DAO;

namespace BlueFox.AM.BL
{
    public class LoginBiz
    {
        public Login View
        {
            get;
            private set;
        }

        public LoginBiz()
        {
            this.View = new Login();
        }

        public LoginResult Run()
        {
            bool UserInfoGot = this.ReadFromCache();
            if (UserInfoGot)
            {
                //TODO
                return LoginResult.Succeed;
            }
            else
            {
                return this.LoopReadFromUI();
            }
        }

        private LoginResult LoopReadFromUI()
        {
            bool UserInfoGot = this.ReadFromUI();
            if (UserInfoGot)
            {
                if (this.DoLogin())
                {
                    return LoginResult.Succeed;
                }
                else
                {
                    MessageBox.Show("Password is not correct! Please retry to input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return this.LoopReadFromUI();
                }
            }
            else
            {
                return LoginResult.Exit;
            }
        }

        private bool ReadFromCache()
        {
            return false;
        }

        private bool ReadFromUI()
        {
            this.View.ShowDialog();
            if (this.View.DoLogin)
            {
                Global.UserName = this.View.UserName;
                Global.Password = this.View.Password;
                Global.DataFileName = this.View.DataFileName;
            }
            return this.View.DoLogin;
        }

        private bool DoLogin()
        {
            try
            {
                using (Accessor access = new Accessor(Global.DataFileName))
                {
                    access.Connect(Global.Password);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    public enum LoginResult
    {
        Failed,
        Succeed,
        Exit
    }
}
