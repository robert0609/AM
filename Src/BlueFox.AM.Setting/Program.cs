using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BlueFox.AM.Setting
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
                Common.Init();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Index());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
