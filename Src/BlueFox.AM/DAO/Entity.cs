using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueFox.AM.DAO
{
    public abstract class Entity
    {
        protected const string INSERT_VALUE = "'{0}'";
        protected const string UPDATE_SET = " {0} = '{1}' ";
        protected const string WHERE = " {0} = '{1}' ";

        public DataStatus Status
        {
            get;
            protected set;
        }

        protected virtual void ModifiedProperty()
        {
            switch (this.Status)
            {
                case DataStatus.NoChanged:
                    this.Status = DataStatus.Changed;
                    break;
                case DataStatus.New:
                    break;
                case DataStatus.Changed:
                    break;
                case DataStatus.Deleted:
                    break;
            }
        }

        public void Save()
        {
            switch (this.Status)
            {
                case DataStatus.NoChanged:
                    break;
                case DataStatus.New:
                    {
                        var cmd = this.GenInsertString();
                        using (Accessor access = new Accessor(Global.DataFileName))
                        {
                            access.Connect(Global.Password);
                            access.ExecuteUID(cmd);
                        }
                    }
                    break;
                case DataStatus.Changed:
                    {
                        var cmd = this.GenUpdateString();
                        using (Accessor access = new Accessor(Global.DataFileName))
                        {
                            access.Connect(Global.Password);
                            access.ExecuteUID(cmd);
                        }
                    }
                    break;
                case DataStatus.Deleted:
                    {
                        var cmd = this.GenDeleteString();
                        using (Accessor access = new Accessor(Global.DataFileName))
                        {
                            access.Connect(Global.Password);
                            access.ExecuteUID(cmd);
                        }
                    }
                    break;
            }
        }

        protected abstract string GenInsertString();

        protected abstract string GenUpdateString();

        protected abstract string GenDeleteString();
    }
}
