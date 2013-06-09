using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueFox.Security;

namespace BlueFox.AM.DAO
{
    public class Account
    {
        private const string INSERT_VALUE = "'{0}'";
        private const string UPDATE_SET = " {0} = '{1}' ";

        public string Id
        {
            get;
            set;
        }

        public string SiteName
        {
            get;
            set;
        }

        public string URL
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case "Id":
                        return this.Id;
                    case "SiteName":
                        return this.SiteName;
                    case "URL":
                        return this.URL;
                    case "UserName":
                        return this.UserName;
                    case "Password":
                        return this.Password;
                    default:
                        return null;
                }
            }
            set
            {
                switch (propertyName)
                {
                    case "Id":
                        this.Id = value;
                        break;
                    case "SiteName":
                        this.SiteName = value;
                        break;
                    case "URL":
                        this.URL = value;
                        break;
                    case "UserName":
                        this.UserName = value;
                        break;
                    case "Password":
                        this.Password = value;
                        break;
                    default:
                        break;
                }
            }
        }

        public string ToValueString()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(this.Id))
            {
                this.Id = Guid.NewGuid().ToString();
            }
            sb.Append(string.Format(INSERT_VALUE, this.Id));
            sb.Append(',');
            if (string.IsNullOrEmpty(this.SiteName))
            {
                sb.Append("''");
            }
            else
            {
                sb.Append(string.Format(INSERT_VALUE, this.SiteName));
            }
            sb.Append(',');
            if (string.IsNullOrEmpty(this.URL))
            {
                sb.Append("''");
            }
            else
            {
                sb.Append(string.Format(INSERT_VALUE, this.URL));
            }
            sb.Append(',');
            if (string.IsNullOrEmpty(this.UserName))
            {
                sb.Append("''");
            }
            else
            {
                if (Global.Encoder == null)
                {
                    sb.Append(string.Format(INSERT_VALUE, this.UserName));
                }
                else
                {
                    sb.Append(string.Format(INSERT_VALUE, Global.Encoder.Encrypt(this.UserName)));
                }
            }
            sb.Append(',');
            if (string.IsNullOrEmpty(this.Password))
            {
                sb.Append("''");
            }
            else
            {
                if (Global.Encoder == null)
                {
                    sb.Append(string.Format(INSERT_VALUE, this.Password));
                }
                else
                {
                    sb.Append(string.Format(INSERT_VALUE, Global.Encoder.Encrypt(this.Password)));
                }
            }
            return sb.ToString();
        }

        public string ToSetString()
        {
            if (string.IsNullOrEmpty(this.Id))
            {
                throw new ArgumentNullException("Primary key [Id] is not set to NULL!");
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(UPDATE_SET, "Id", this.Id));
            if (!string.IsNullOrEmpty(this.SiteName))
            {
                sb.Append(',');
                sb.Append(string.Format(UPDATE_SET, "SiteName", this.SiteName));
            }
            if (!string.IsNullOrEmpty(this.URL))
            {
                sb.Append(',');
                sb.Append(string.Format(UPDATE_SET, "URL", this.URL));
            }
            if (!string.IsNullOrEmpty(this.UserName))
            {
                sb.Append(',');
                if (Global.Encoder == null)
                {
                    sb.Append(string.Format(UPDATE_SET, "UserName", this.UserName));
                }
                else
                {
                    sb.Append(string.Format(UPDATE_SET, "UserName", Global.Encoder.Encrypt(this.UserName)));
                }
            }
            if (!string.IsNullOrEmpty(this.Password))
            {
                sb.Append(',');
                if (Global.Encoder == null)
                {
                    sb.Append(string.Format(UPDATE_SET, "Password", this.Password));
                }
                else
                {
                    sb.Append(string.Format(UPDATE_SET, "Password", Global.Encoder.Encrypt(this.Password)));
                }
            }
            return sb.ToString();
        }
    }
}
