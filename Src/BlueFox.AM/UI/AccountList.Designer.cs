namespace BlueFox.AM.UI
{
    partial class AccountList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcAccountList = new System.Windows.Forms.TabControl();
            this.tpPrivate = new System.Windows.Forms.TabPage();
            this.tcLevels = new System.Windows.Forms.TabControl();
            this.tpLevel0 = new System.Windows.Forms.TabPage();
            this.dgvLevel0 = new System.Windows.Forms.DataGridView();
            this.menuAccList = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcAccountList.SuspendLayout();
            this.tpPrivate.SuspendLayout();
            this.tcLevels.SuspendLayout();
            this.tpLevel0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLevel0)).BeginInit();
            this.menuAccList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcAccountList
            // 
            this.tcAccountList.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcAccountList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcAccountList.Controls.Add(this.tpPrivate);
            this.tcAccountList.HotTrack = true;
            this.tcAccountList.ItemSize = new System.Drawing.Size(100, 18);
            this.tcAccountList.Location = new System.Drawing.Point(0, 24);
            this.tcAccountList.Margin = new System.Windows.Forms.Padding(0);
            this.tcAccountList.Name = "tcAccountList";
            this.tcAccountList.SelectedIndex = 0;
            this.tcAccountList.Size = new System.Drawing.Size(792, 543);
            this.tcAccountList.TabIndex = 0;
            // 
            // tpPrivate
            // 
            this.tpPrivate.Controls.Add(this.tcLevels);
            this.tpPrivate.Location = new System.Drawing.Point(4, 4);
            this.tpPrivate.Name = "tpPrivate";
            this.tpPrivate.Padding = new System.Windows.Forms.Padding(3);
            this.tpPrivate.Size = new System.Drawing.Size(784, 517);
            this.tpPrivate.TabIndex = 0;
            this.tpPrivate.Text = "Private";
            this.tpPrivate.UseVisualStyleBackColor = true;
            // 
            // tcLevels
            // 
            this.tcLevels.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcLevels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcLevels.Controls.Add(this.tpLevel0);
            this.tcLevels.Location = new System.Drawing.Point(0, 0);
            this.tcLevels.Multiline = true;
            this.tcLevels.Name = "tcLevels";
            this.tcLevels.SelectedIndex = 0;
            this.tcLevels.Size = new System.Drawing.Size(784, 517);
            this.tcLevels.TabIndex = 1;
            // 
            // tpLevel0
            // 
            this.tpLevel0.Controls.Add(this.dgvLevel0);
            this.tpLevel0.Location = new System.Drawing.Point(4, 4);
            this.tpLevel0.Name = "tpLevel0";
            this.tpLevel0.Padding = new System.Windows.Forms.Padding(3);
            this.tpLevel0.Size = new System.Drawing.Size(776, 492);
            this.tpLevel0.TabIndex = 0;
            this.tpLevel0.Text = "Level-0";
            this.tpLevel0.UseVisualStyleBackColor = true;
            // 
            // dgvLevel0
            // 
            this.dgvLevel0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLevel0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLevel0.Location = new System.Drawing.Point(0, 0);
            this.dgvLevel0.Name = "dgvLevel0";
            this.dgvLevel0.RowTemplate.Height = 23;
            this.dgvLevel0.Size = new System.Drawing.Size(776, 492);
            this.dgvLevel0.TabIndex = 0;
            // 
            // menuAccList
            // 
            this.menuAccList.BackColor = System.Drawing.Color.Transparent;
            this.menuAccList.Font = new System.Drawing.Font("Lucida Console", 9F);
            this.menuAccList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.addRowToolStripMenuItem,
            this.deleteRowToolStripMenuItem});
            this.menuAccList.Location = new System.Drawing.Point(0, 0);
            this.menuAccList.Name = "menuAccList";
            this.menuAccList.Size = new System.Drawing.Size(792, 24);
            this.menuAccList.TabIndex = 1;
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.userToolStripMenuItem.Text = "User";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // addRowToolStripMenuItem
            // 
            this.addRowToolStripMenuItem.Name = "addRowToolStripMenuItem";
            this.addRowToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.addRowToolStripMenuItem.Text = "AddRow";
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.deleteRowToolStripMenuItem.Text = "DeleteRow";
            // 
            // AccountList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.tcAccountList);
            this.Controls.Add(this.menuAccList);
            this.MainMenuStrip = this.menuAccList;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "AccountList";
            this.Text = "Account List-";
            this.tcAccountList.ResumeLayout(false);
            this.tpPrivate.ResumeLayout(false);
            this.tcLevels.ResumeLayout(false);
            this.tpLevel0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLevel0)).EndInit();
            this.menuAccList.ResumeLayout(false);
            this.menuAccList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcAccountList;
        private System.Windows.Forms.TabPage tpPrivate;
        private System.Windows.Forms.MenuStrip menuAccList;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvLevel0;
        private System.Windows.Forms.ToolStripMenuItem addRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tcLevels;
        private System.Windows.Forms.TabPage tpLevel0;


    }
}