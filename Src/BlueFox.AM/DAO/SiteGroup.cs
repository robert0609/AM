using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueFox.AM.DAO
{
    public class SiteGroup : Entity
    {
        public string Id
        {
            get;
            private set;
        }

        private bool _groupNameChanged;
        private string _groupName;
        public string GroupName
        {
            get
            {
                return this._groupName;
            }
            set
            {
                if (value != this._groupName)
                {
                    this.ModifiedProperty();
                    this._groupName = value;
                    this._groupNameChanged = true;
                }
            }
        }

        public IList<Site> SiteList
        {
            get;
            set;
        }

        public SiteGroup()
        {
            this.Id = Guid.NewGuid().ToString();
            this._groupName = string.Empty;
            this.Status = DataStatus.New;

            this.SiteList = new List<Site>();
        }

        public SiteGroup(string id, string groupName)
        {
            this.Id = id;
            this._groupName = groupName;
            this.Status = DataStatus.NoChanged;

            this.SiteList = new List<Site>();
        }

        protected override string GenInsertString()
        {
            StringBuilder sb = new StringBuilder("Insert into SiteGroup(Id, GroupName) values(");
            sb.Append(string.Format(INSERT_VALUE, this.Id));
            sb.Append(",");
            sb.Append(string.Format(INSERT_VALUE, this._groupName));
            sb.Append(")");

            return sb.ToString();
        }

        protected override string GenUpdateString()
        {
            StringBuilder sb = new StringBuilder("Update SiteGroup Set ");
            if (this._groupNameChanged)
            {
                sb.Append(string.Format(UPDATE_SET, "GroupName", this._groupName));
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(" Where ");
            sb.Append(string.Format(WHERE, "Id", this.Id));

            return sb.ToString();
        }

        protected override string GenDeleteString()
        {
            StringBuilder sb = new StringBuilder("Delete from SiteGroup Where ");
            sb.Append(string.Format(WHERE, "Id", this.Id));

            return sb.ToString();
        }
    }
}
