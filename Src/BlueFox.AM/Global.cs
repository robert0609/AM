using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueFox.Security;

namespace BlueFox.AM
{
    public class Global
    {
        public const string DATAFILE_EX = ".am";
        public const string CACHE_EX = ".ch";

        public static string UserName
        {
            get;
            set;
        }

        public static string Password
        {
            get;
            set;
        }

        public static string DataFileName
        {
            get;
            set;
        }

        public static string BaseDir
        {
            get;
            private set;
        }

        public static DES Encoder
        {
            get;
            private set;
        }

        static Global()
        {
            BaseDir = AppDomain.CurrentDomain.BaseDirectory;
            Encoder = new DES("sf7gh8hj");
        }
    }
}
