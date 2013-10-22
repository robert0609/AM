using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueFox.AM.DAO
{
    public class Url : Entity
    {
        public string Id
        {
            get;
            private set;
        }

        private bool _urlStringChanged;
        private string _urlString;
        public string UrlString
        {
            get
            {
                return this._urlString;
            }
            set
            {
                if (value != this._urlString)
                {
                    this.ModifiedProperty();
                    this._urlString = value;
                    this._urlStringChanged = true;
                }
            }
        }

        private bool _siteIdChanged;
        private string _siteId;
        public string SiteId
        {
            get
            {
                return this._siteId;
            }
            set
            {
                if (value != this._siteId)
                {
                    this.ModifiedProperty();
                    this._siteId = value;
                    this._siteIdChanged = true;
                }
            }
        }

        public Url(string siteId)
        {
            this.Id = Guid.NewGuid().ToString();
            this._urlString = string.Empty;
            this._siteId = siteId;
            this.Status = DataStatus.New;
        }

        public Url(string id, string urlString, string siteId)
        {
            this.Id = id;
            this._urlString = urlString;
            this._siteId = siteId;
            this.Status = DataStatus.NoChanged;
        }

        protected override string GenInsertString()
        {
            StringBuilder sb = new StringBuilder("Insert into Url(Id, SiteId, UrlString) values(");
            sb.Append(string.Format(INSERT_VALUE, this.Id));
            sb.Append(",");
            sb.Append(string.Format(INSERT_VALUE, this._siteId));
            sb.Append(",");
            sb.Append(string.Format(INSERT_VALUE, this._urlString));
            sb.Append(")");

            return sb.ToString();
        }

        protected override string GenUpdateString()
        {
            StringBuilder sb = new StringBuilder("Update Url Set ");
            if (this._siteIdChanged)
            {
                sb.Append(string.Format(UPDATE_SET, "SiteId", this._siteId));
                sb.Append(",");
            }
            if (this._urlStringChanged)
            {
                sb.Append(string.Format(UPDATE_SET, "UrlString", this._urlString));
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(" Where ");
            sb.Append(string.Format(WHERE, "Id", this.Id));

            return sb.ToString();
        }

        protected override string GenDeleteString()
        {
            StringBuilder sb = new StringBuilder("Delete from Url Where ");
            sb.Append(string.Format(WHERE, "Id", this.Id));

            return sb.ToString();
        }
    }
}
