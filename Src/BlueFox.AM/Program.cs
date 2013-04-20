using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BlueFox.AM.UI;
using BlueFox.AM.BL;

namespace BlueFox.AM
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                LoginBiz loginBiz = new LoginBiz();
                if (loginBiz.Run() == LoginResult.Succeed)
                {
                    AccountListBiz accListBiz = new AccountListBiz();
                    accListBiz.Run();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
