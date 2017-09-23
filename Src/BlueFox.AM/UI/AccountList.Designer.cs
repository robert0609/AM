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
            this.gbServiceControl = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.gbServiceControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbServiceControl
            // 
            this.gbServiceControl.Controls.Add(this.btnStop);
            this.gbServiceControl.Controls.Add(this.btnStart);
            this.gbServiceControl.Location = new System.Drawing.Point(12, 12);
            this.gbServiceControl.Name = "gbServiceControl";
            this.gbServiceControl.Size = new System.Drawing.Size(467, 89);
            this.gbServiceControl.TabIndex = 0;
            this.gbServiceControl.TabStop = false;
            this.gbServiceControl.Text = "Service Control";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(20, 30);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 30);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(180, 30);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 30);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // AccountList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(491, 316);
            this.Controls.Add(this.gbServiceControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(509, 363);
            this.Name = "AccountList";
            this.Text = "Account List-";
            this.gbServiceControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.GroupBox gbServiceControl;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
    }
}