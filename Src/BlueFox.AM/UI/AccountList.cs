using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlueFox.AM.DAO;

namespace BlueFox.AM.UI
{
    public partial class AccountList : BaseForm
    {
        public DataTable DataSource
        {
            get
            {
                return this.dgvPrivate.DataSource as DataTable;
            }
            set
            {
                this.dgvPrivate.DataSource = value;
            }
        }

        private Accessor _access;

        public AccountList()
        {
            InitializeComponent();
            this.InitDataGrid();
            this.dgvPrivate.SizeChanged += new EventHandler(dgvPrivate_SizeChanged);
            this.addRowToolStripMenuItem.Click += new EventHandler(addRowToolStripMenuItem_Click);
            this.deleteRowToolStripMenuItem.Click += new EventHandler(deleteRowToolStripMenuItem_Click);
            this.dgvPrivate.CellEndEdit += new DataGridViewCellEventHandler(dgvPrivate_CellEndEdit);
            this.dgvPrivate.CellClick += new DataGridViewCellEventHandler(dgvPrivate_CellClick);
            //this.RemovableDriveArrived += new DelegateRemovableDriveArrived(AccountList_RemovableDriveArrived);
            this.RemovableDrivePulled += new DelegateRemovableDrivePulled(AccountList_RemovableDrivePulled);
        }

        private void AccountList_RemovableDrivePulled(object sender, RemovableDriveEventArgs e)
        {
            this._access.Dispose();
            this._access = null;
            this.DataSource = null;
            this.addRowToolStripMenuItem.Enabled = false;
            this.deleteRowToolStripMenuItem.Enabled = false;
        }

        private void AccountList_RemovableDriveArrived(object sender, RemovableDriveEventArgs e)
        {
            this.addRowToolStripMenuItem.Enabled = true;
            this.deleteRowToolStripMenuItem.Enabled = true;
            this._access = new Accessor(Global.DataFileName);
            this._access.Connect(Global.Password);
            this.DataSource = this.GetAccountList();
        }

        private DataTable GetAccountList()
        {
            DataTable accList = this.InitDataSource();
            using (Accessor access = new Accessor(Global.DataFileName))
            {
                access.Connect(Global.Password);
                var lst = access.Select(new Condition());
                foreach (var acc in lst)
                {
                    var r = accList.NewRow();
                    r["Id"] = acc.Id;
                    r["SiteName"] = acc.SiteName;
                    r["URL"] = acc.URL;
                    r["UserName"] = acc.UserName;
                    r["Password"] = acc.Password;
                    accList.Rows.Add(r);
                }
            }
            return accList;
        }

        private DataTable InitDataSource()
        {
            DataTable dat = new DataTable();
            dat.Columns.Add(new DataColumn("Id"));
            dat.Columns.Add(new DataColumn("SiteName"));
            dat.Columns.Add(new DataColumn("URL"));
            dat.Columns.Add(new DataColumn("UserName"));
            dat.Columns.Add(new DataColumn("Password"));
            return dat;
        }

        private void InitDataGrid()
        {
            this.dgvPrivate.AutoGenerateColumns = false;
            this.dgvPrivate.RowHeadersVisible = false;
            this.dgvPrivate.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.InactiveCaption;
            this.dgvPrivate.ScrollBars = ScrollBars.Both;
            this.dgvPrivate.AllowUserToResizeRows = false;
            this.dgvPrivate.AllowUserToResizeColumns = false;
            this.dgvPrivate.AllowUserToAddRows = false;
            this.dgvPrivate.AllowUserToDeleteRows = false;
            this.dgvPrivate.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.dgvPrivate.Columns.Add(this.GenerateColumn("Id", 150, false));
            this.dgvPrivate.Columns.Add(this.GenerateColumn("SiteName", 100, true));
            this.dgvPrivate.Columns.Add(this.GenerateColumn("URL", this.dgvPrivate.Width - 470, true));
            this.dgvPrivate.Columns.Add(this.GenerateColumn("UserName", 150, true));
            this.dgvPrivate.Columns.Add(this.GenerateButtonColumn("CopyUserName", 25));
            this.dgvPrivate.Columns.Add(this.GenerateColumn("Password", 150, true));
            this.dgvPrivate.Columns.Add(this.GenerateButtonColumn("CopyPassword", 25));
        }

        private DataGridViewColumn GenerateColumn(string name, int width, bool display)
        {
            var col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.HeaderText = name;
            col.DataPropertyName = name;
            col.Visible = display;
            col.Width = width;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            return col;
        }

        private DataGridViewColumn GenerateButtonColumn(string name, int width)
        {
            var col = new DataGridViewButtonColumn();
            col.Name = name;
            col.DataPropertyName = name;
            col.Width = width;
            col.HeaderText = string.Empty;
            col.Text = "C";
            col.UseColumnTextForButtonValue = true;
            return col;
        }

        private void dgvPrivate_SizeChanged(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            grid.Columns["URL"].Width = this.dgvPrivate.Width - 470;
        }

        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null)
            {
                return;
            }
            this.DataSource.Rows.Add(this.DataSource.NewRow());
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null)
            {
                return;
            }
            IList<string> selIds = new List<string>();
            foreach (DataGridViewRow row in this.dgvPrivate.SelectedRows)
            {
                if (row.Cells["Id"].Value == null || string.IsNullOrEmpty(row.Cells["Id"].Value.ToString()))
                {
                    continue;
                }
                selIds.Add(row.Cells["Id"].Value.ToString());
            }
            foreach (var id in selIds)
            {
                Account acc = new Account();
                acc["Id"] = id;
                this._access.Delete(acc);
            }
            IList<DataRow> selRows = new List<DataRow>();
            foreach (DataRow r in this.DataSource.Rows)
            {
                if (selIds.Contains(r["Id"].ToString()))
                {
                    selRows.Add(r);
                }
            }
            foreach (var r in selRows)
            {
                this.DataSource.Rows.Remove(r);
            }
        }

        private void dgvPrivate_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var name = this.dgvPrivate.Columns[e.ColumnIndex].DataPropertyName;
            var row = this.DataSource.Rows[e.RowIndex];
            Account acc = new Account();
            acc[name] = row[name].ToString();
            if (row["Id"] == null || string.IsNullOrEmpty(row["Id"].ToString()))
            {
                row["Id"] = this._access.Insert(acc);
            }
            else
            {
                acc["Id"] = row["id"].ToString();
                this._access.Update(acc);
            }
        }

        private void dgvPrivate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var name = this.dgvPrivate.Columns[e.ColumnIndex].DataPropertyName;
            if (name == "CopyUserName" || name == "CopyPassword")
            {
                if (e.RowIndex > -1)
                {
                    var fieldName = this.dgvPrivate.Columns[e.ColumnIndex - 1].DataPropertyName;
                    var objCell = this.DataSource.Rows[e.RowIndex][fieldName];
                    if (objCell != null)
                    {
                        Clipboard.Clear();
                        Clipboard.SetText(objCell.ToString());
                        //MessageBox.Show(string.Format("{0} has been copied to clipboard.", fieldName), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Text += Global.UserName;
            this._access = new Accessor(Global.DataFileName);
            this._access.Connect(Global.Password);
            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this._access != null)
            {
                this._access.Dispose();
                this._access = null;
            }
            base.OnClosing(e);
        }
    }
}
