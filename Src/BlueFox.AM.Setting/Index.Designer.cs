namespace BlueFox.AM.Setting
{
    partial class Index
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tpAuthority = new System.Windows.Forms.TabPage();
            this.tpRegister = new System.Windows.Forms.TabPage();
            this.tpCert = new System.Windows.Forms.TabPage();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtCurrentPublicKeyFile = new System.Windows.Forms.TextBox();
            this.txtCurrentPrivateKeyFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateAuth = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.tbcMain.SuspendLayout();
            this.tpAuthority.SuspendLayout();
            this.tpRegister.SuspendLayout();
            this.tpCert.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcMain.Controls.Add(this.tpAuthority);
            this.tbcMain.Controls.Add(this.tpRegister);
            this.tbcMain.Controls.Add(this.tpCert);
            this.tbcMain.Location = new System.Drawing.Point(12, 12);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(768, 194);
            this.tbcMain.TabIndex = 0;
            // 
            // tpAuthority
            // 
            this.tpAuthority.Controls.Add(this.label3);
            this.tpAuthority.Controls.Add(this.btnGenerateAuth);
            this.tpAuthority.Location = new System.Drawing.Point(4, 21);
            this.tpAuthority.Name = "tpAuthority";
            this.tpAuthority.Padding = new System.Windows.Forms.Padding(3);
            this.tpAuthority.Size = new System.Drawing.Size(760, 169);
            this.tpAuthority.TabIndex = 0;
            this.tpAuthority.Text = "Authorize";
            this.tpAuthority.UseVisualStyleBackColor = true;
            // 
            // tpRegister
            // 
            this.tpRegister.Controls.Add(this.btnRegister);
            this.tpRegister.Controls.Add(this.txtPassword);
            this.tpRegister.Controls.Add(this.txtUserName);
            this.tpRegister.Controls.Add(this.label5);
            this.tpRegister.Controls.Add(this.label4);
            this.tpRegister.Location = new System.Drawing.Point(4, 21);
            this.tpRegister.Name = "tpRegister";
            this.tpRegister.Padding = new System.Windows.Forms.Padding(3);
            this.tpRegister.Size = new System.Drawing.Size(760, 169);
            this.tpRegister.TabIndex = 1;
            this.tpRegister.Text = "Register";
            this.tpRegister.UseVisualStyleBackColor = true;
            // 
            // tpCert
            // 
            this.tpCert.Controls.Add(this.btnGenerate);
            this.tpCert.Controls.Add(this.txtCurrentPublicKeyFile);
            this.tpCert.Controls.Add(this.txtCurrentPrivateKeyFile);
            this.tpCert.Controls.Add(this.label2);
            this.tpCert.Controls.Add(this.label1);
            this.tpCert.Location = new System.Drawing.Point(4, 21);
            this.tpCert.Name = "tpCert";
            this.tpCert.Size = new System.Drawing.Size(760, 169);
            this.tpCert.TabIndex = 2;
            this.tpCert.Text = "Certificates";
            this.tpCert.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(527, 119);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(175, 28);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate Key Files";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // txtCurrentPublicKeyFile
            // 
            this.txtCurrentPublicKeyFile.Location = new System.Drawing.Point(201, 73);
            this.txtCurrentPublicKeyFile.Name = "txtCurrentPublicKeyFile";
            this.txtCurrentPublicKeyFile.ReadOnly = true;
            this.txtCurrentPublicKeyFile.Size = new System.Drawing.Size(501, 19);
            this.txtCurrentPublicKeyFile.TabIndex = 3;
            // 
            // txtCurrentPrivateKeyFile
            // 
            this.txtCurrentPrivateKeyFile.Location = new System.Drawing.Point(201, 37);
            this.txtCurrentPrivateKeyFile.Name = "txtCurrentPrivateKeyFile";
            this.txtCurrentPrivateKeyFile.ReadOnly = true;
            this.txtCurrentPrivateKeyFile.Size = new System.Drawing.Size(501, 19);
            this.txtCurrentPrivateKeyFile.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Current Public Key File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Private Key File";
            // 
            // btnGenerateAuth
            // 
            this.btnGenerateAuth.Location = new System.Drawing.Point(94, 64);
            this.btnGenerateAuth.Name = "btnGenerateAuth";
            this.btnGenerateAuth.Size = new System.Drawing.Size(170, 28);
            this.btnGenerateAuth.TabIndex = 0;
            this.btnGenerateAuth.Text = "Generate Auth File";
            this.btnGenerateAuth.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(282, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(349, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "* The generated auth file should be copied to [C:] root directory.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "User Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(291, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(201, 19);
            this.txtUserName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(291, 73);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(201, 19);
            this.txtPassword.TabIndex = 3;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(400, 117);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(92, 28);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 218);
            this.Controls.Add(this.tbcMain);
            this.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Index";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Index";
            this.tbcMain.ResumeLayout(false);
            this.tpAuthority.ResumeLayout(false);
            this.tpRegister.ResumeLayout(false);
            this.tpRegister.PerformLayout();
            this.tpCert.ResumeLayout(false);
            this.tpCert.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tpAuthority;
        private System.Windows.Forms.TabPage tpRegister;
        private System.Windows.Forms.TabPage tpCert;
        private System.Windows.Forms.TextBox txtCurrentPublicKeyFile;
        private System.Windows.Forms.TextBox txtCurrentPrivateKeyFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnGenerateAuth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRegister;


    }
}

