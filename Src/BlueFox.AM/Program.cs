using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BlueFox.AM.UI;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            (new Login()).Show();
            Application.Run();
        }
    }
}
