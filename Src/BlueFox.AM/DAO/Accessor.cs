﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace BlueFox.AM.DAO
{
    public sealed class Accessor : IDisposable
    {
        private string _fileName;

        private SQLiteConnection _con;

        public Accessor(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(string.Format("{0} doesn't exist, please connect U disk!", fileName));
            }
            this._fileName = fileName;
        }

        public void Connect(string pwd)
        {
            this._con = new SQLiteConnection();
            SQLiteConnectionStringBuilder connsb = new SQLiteConnectionStringBuilder();
            connsb.DataSource = this._fileName;
            connsb.Password = pwd;
            this._con.ConnectionString = connsb.ToString();
            this._con.Open();
        }

        public IList<Account> Select(Condition condition)
        {
            IList<Account> ret = new List<Account>();
            using (SQLiteCommand cmd = new SQLiteCommand(this._con))
            {
                cmd.CommandText = "Select * from Account " + condition.ToWhereString();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    var acc = new Account 
                    { 
                        Id = dataReader["Id"].ToString(),
                        SiteName = dataReader["SiteName"].ToString(),
                        URL = dataReader["URL"].ToString(),
                        UserName = dataReader["UserName"].ToString(),
                        Password = dataReader["Password"].ToString() 
                    };
                    ret.Add(acc);
                }
            }
            return ret;
        }

        public void Dispose()
        {
            if (this._con != null && this._con.State != System.Data.ConnectionState.Closed)
            {
                this._con.Close();
                this._con.Dispose();
                this._con = null;
            }
        }
    }
}