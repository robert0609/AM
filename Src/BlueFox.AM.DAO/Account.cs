using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueFox.AM.DAO
{
    public class Account : Entity
    {
        public string Id
        {
            get;
            private set;
        }

        private bool _userNameChanged;
        private string _userName;
        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                if (value != this._userName)
                {
                    this.ModifiedProperty();
                    this._userName = value;
                    this._userNameChanged = true;
                }
            }
        }

        private bool _passwordChanged;
        private string _password;
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                if (value != this._password)
                {
                    this.ModifiedProperty();
                    this._password = value;
                    this._passwordChanged = true;
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

        public Account() : this(Guid.NewGuid().ToString())
        {

        }

        public Account(string id)
        {
            this.Id = id;
            this._userName = string.Empty;
            this._password = string.Empty;
            this._siteId = string.Empty;
            this.Status = DataStatus.New;
        }

        public Account(string id, string userName, string password, string siteId)
        {
            this.Id = id;
            this._userName = userName;
            this._password = password;
            this._siteId = siteId;
            this.Status = DataStatus.NoChanged;
        }

        protected override string GenInsertString()
        {
            StringBuilder sb = new StringBuilder("Insert into Account(Id, SiteId, UserName, Password) values(");
            sb.Append(string.Format(INSERT_VALUE, this.Id));
            sb.Append(",");
            sb.Append(string.Format(INSERT_VALUE, this._siteId));
            sb.Append(",");
            sb.Append(string.Format(INSERT_VALUE, this._userName));
            sb.Append(",");
            sb.Append(string.Format(INSERT_VALUE, this._password));
            sb.Append(")");

            return sb.ToString();
        }

        protected override string GenUpdateString()
        {
            StringBuilder sb = new StringBuilder("Update Account Set ");
            if (this._siteIdChanged)
            {
                sb.Append(string.Format(UPDATE_SET, "SiteId", this._siteId));
                sb.Append(",");
            }
            if (this._userNameChanged)
            {
                sb.Append(string.Format(UPDATE_SET, "UserName", this._userName));
                sb.Append(",");
            }
            if (this._passwordChanged)
            {
                sb.Append(string.Format(UPDATE_SET, "Password", this._password));
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(" Where ");
            sb.Append(string.Format(WHERE, "Id", this.Id));

            return sb.ToString();
        }

        protected override string GenDeleteString()
        {
            StringBuilder sb = new StringBuilder("Delete from Account Where ");
            sb.Append(string.Format(WHERE, "Id", this.Id));

            return sb.ToString();
        }        
    }
}
