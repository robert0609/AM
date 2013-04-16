namespace BlueFox.AM.UI
{
    partial class Home
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
            this.tcHome = new System.Windows.Forms.TabControl();
            this.tpPrivate = new System.Windows.Forms.TabPage();
            this.menuHome = new System.Windows.Forms.MenuStrip();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvPrivate = new System.Windows.Forms.DataGridView();
            this.tcHome.SuspendLayout();
            this.tpPrivate.SuspendLayout();
            this.menuHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrivate)).BeginInit();
            this.SuspendLayout();
            // 
            // tcHome
            // 
            this.tcHome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcHome.Controls.Add(this.tpPrivate);
            this.tcHome.Location = new System.Drawing.Point(0, 24);
            this.tcHome.Margin = new System.Windows.Forms.Padding(0);
            this.tcHome.Name = "tcHome";
            this.tcHome.SelectedIndex = 0;
            this.tcHome.Size = new System.Drawing.Size(792, 543);
            this.tcHome.TabIndex = 0;
            // 
            // tpPrivate
            // 
            this.tpPrivate.Controls.Add(this.dgvPrivate);
            this.tpPrivate.Location = new System.Drawing.Point(4, 21);
            this.tpPrivate.Name = "tpPrivate";
            this.tpPrivate.Padding = new System.Windows.Forms.Padding(3);
            this.tpPrivate.Size = new System.Drawing.Size(784, 518);
            this.tpPrivate.TabIndex = 0;
            this.tpPrivate.Text = "Private";
            this.tpPrivate.UseVisualStyleBackColor = true;
            // 
            // menuHome
            // 
            this.menuHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlToolStripMenuItem});
            this.menuHome.Location = new System.Drawing.Point(0, 0);
            this.menuHome.Name = "menuHome";
            this.menuHome.Size = new System.Drawing.Size(792, 24);
            this.menuHome.TabIndex = 1;
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // dgvPrivate
            // 
            this.dgvPrivate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrivate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrivate.Location = new System.Drawing.Point(0, 0);
            this.dgvPrivate.Name = "dgvPrivate";
            this.dgvPrivate.RowTemplate.Height = 23;
            this.dgvPrivate.Size = new System.Drawing.Size(784, 518);
            this.dgvPrivate.TabIndex = 0;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.tcHome);
            this.Controls.Add(this.menuHome);
            this.MainMenuStrip = this.menuHome;
            this.Name = "Home";
            this.Text = "Home-";
            this.tcHome.ResumeLayout(false);
            this.tpPrivate.ResumeLayout(false);
            this.menuHome.ResumeLayout(false);
            this.menuHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrivate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcHome;
        private System.Windows.Forms.TabPage tpPrivate;
        private System.Windows.Forms.MenuStrip menuHome;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvPrivate;


    }
}