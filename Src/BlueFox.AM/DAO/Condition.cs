using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueFox.AM.DAO
{
    public class Condition
    {
        private const string WHERE_LIKE = " {0} like '{1}' ";
        private const string WHERE_EQUAL = " {0} = '{1}' ";
        private const string WHERE = " WHERE ";
        private const string AND = " AND ";

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

        public string ToWhereString()
        {
            StringBuilder sb = new StringBuilder(WHERE);
            if (!string.IsNullOrEmpty(this.Id))
            {
                sb.Append(string.Format(WHERE_EQUAL, "Id", this.Id));
                sb.Append(AND);
            }
            if (!string.IsNullOrEmpty(this.SiteName))
            {
                sb.Append(string.Format(WHERE_LIKE, "SiteName", this.Like(this.SiteName)));
                sb.Append(AND);
            }
            if (!string.IsNullOrEmpty(this.URL))
            {
                sb.Append(string.Format(WHERE_LIKE, "URL", this.Like(this.URL)));
                sb.Append(AND);
            }
            if (sb.Length == WHERE.Length)
            {
                return string.Empty;
            }
            else
            {
                return sb.Remove(sb.Length - 5, 5).ToString();
            }
        }

        private string Like(string val)
        {
            return "%" + val + "%";
        }
    }
}
