using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueFox.Security;
using System.Configuration;

namespace BlueFox.AM.Setting
{
    public static class Common
    {
        public static string BaseDir
        {
            get;
            private set;
        }

        public static Certificates Cert
        {
            get
            {
                if (_cert == null)
                {
                    throw new NullReferenceException("Certificates is not initialized!");
                }
                return _cert;
            }
            set
            {
                _cert = value;
            }
        }

        private static Certificates _cert;

        public static void Init()
        {
            BaseDir = AppDomain.CurrentDomain.BaseDirectory;

            var privateFile = ConfigurationManager.AppSettings["CurrentPrivateKeyFile"];
            var publicFile = ConfigurationManager.AppSettings["CurrentPublicKeyFile"];
            if (!string.IsNullOrEmpty(privateFile) && !string.IsNullOrEmpty(publicFile))
            {
                _cert = new Certificates();
                _cert.Import(privateFile);
            }
        }

        public static void SetAppSetting(string key, string value)
        {
            var configure = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configure.AppSettings.Settings[key].Value = value;
            configure.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
