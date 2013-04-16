using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public string ToValueString()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(this.Id))
            {
                sb.Append(string.Format(INSERT_VALUE, Guid.NewGuid().ToString()));
            }
            else
            {
                sb.Append(string.Format(INSERT_VALUE, this.Id));
            }
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
                sb.Append(string.Format(INSERT_VALUE, this.UserName));
            }
            sb.Append(',');
            if (string.IsNullOrEmpty(this.Password))
            {
                sb.Append("''");
            }
            else
            {
                sb.Append(string.Format(INSERT_VALUE, this.Password));
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
                sb.Append(string.Format(UPDATE_SET, "UserName", this.UserName));
            }
            if (!string.IsNullOrEmpty(this.Password))
            {
                sb.Append(',');
                sb.Append(string.Format(UPDATE_SET, "Password", this.Password));
            }
            return sb.ToString();
        }
    }
}
