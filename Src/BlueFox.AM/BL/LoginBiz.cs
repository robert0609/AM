using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlueFox.AM.UI;

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
            this.View.btnLogin.Click += new EventHandler(btnLogin_Click);
            this.View.btnExit.Click += new EventHandler(btnExit_Click);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
