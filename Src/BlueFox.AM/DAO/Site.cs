using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueFox.Security;

namespace BlueFox.AM.DAO
{
    public class Site : Entity
    {
        public string Id
        {
            get;
            private set;
        }

        private bool _siteNameChanged;
        private string _siteName;
        public string SiteName
        {
            get
            {
                return this._siteName;
            }
            set
            {
                if (value != this._siteName)
                {
                    this.ModifiedProperty();
                    this._siteName = value;
                    this._siteNameChanged = true;
                }
            }
        }

        private bool _groupIdChanged;
        private string _groupId;
        public string GroupId
        {
            get
            {
                return this._groupId;
            }
            set
            {
                if (value != this._groupId)
                {
                    this.ModifiedProperty();
                    this._groupId = value;
                    this._groupIdChanged = true;
                }
            }
        }

        public IList<Url> UrlList
        {
            get;
            set;
        }

        public IList<Account> AccountList
        {
            get;
            set;
        }

        public Site(string groupId)
        {
            this.Id = Guid.NewGuid().ToString();
            this._siteName = string.Empty;
            this._groupId = groupId;
            this.Status = DataStatus.New;

            this.UrlList = new List<Url>();
            this.AccountList = new List<Account>();
        }

        public Site(string id, string siteName, string groupId)
        {
            this.Id = id;
            this._siteName = siteName;
            this._groupId = groupId;
            this.Status = DataStatus.NoChanged;

            this.UrlList = new List<Url>();
            this.AccountList = new List<Account>();
        }

        protected override string GenInsertString()
        {
            StringBuilder sb = new StringBuilder("Insert into Site(Id, SiteName, GroupId) values(");
            sb.Append(string.Format(INSERT_VALUE, this.Id));
            sb.Append(",");
            sb.Append(string.Format(INSERT_VALUE, this._siteName));
            sb.Append(",");
            sb.Append(string.Format(INSERT_VALUE, this._groupId));
            sb.Append(")");

            return sb.ToString();
        }

        protected override string GenUpdateString()
        {
            StringBuilder sb = new StringBuilder("Update Site Set ");
            if (this._siteNameChanged)
            {
                sb.Append(string.Format(UPDATE_SET, "SiteName", this._siteName));
                sb.Append(",");
            }
            if (this._groupIdChanged)
            {
                sb.Append(string.Format(UPDATE_SET, "GroupId", this._groupId));
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(" Where ");
            sb.Append(string.Format(WHERE, "Id", this.Id));

            return sb.ToString();
        }

        protected override string GenDeleteString()
        {
            StringBuilder sb = new StringBuilder("Delete from Site Where ");
            sb.Append(string.Format(WHERE, "Id", this.Id));

            return sb.ToString();
        }
    }
}
