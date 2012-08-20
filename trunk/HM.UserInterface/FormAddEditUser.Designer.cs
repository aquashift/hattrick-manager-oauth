namespace HM.UserInterface
{
    partial class FormAddEditUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddEditUser));
            this.groupBoxUserCredentials = new System.Windows.Forms.GroupBox();
            this.labelOAuthInstructions = new System.Windows.Forms.Label();
            this.buttonOpenURL = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxDataFolder = new System.Windows.Forms.TextBox();
            this.labelDataFolder = new System.Windows.Forms.Label();
            this.textBoxSecurityCode = new System.Windows.Forms.TextBox();
            this.labelSecurityCode = new System.Windows.Forms.Label();
            this.textBoxAuthorizationURL = new System.Windows.Forms.TextBox();
            this.labelOAuth = new System.Windows.Forms.Label();
            this.groupBoxUserData = new System.Windows.Forms.GroupBox();
            this.labelActivationDateValue = new System.Windows.Forms.Label();
            this.labelActivationDate = new System.Windows.Forms.Label();
            this.labelYouthTeamIdValue = new System.Windows.Forms.Label();
            this.labelYouthTeamId = new System.Windows.Forms.Label();
            this.labelTeamIdValue = new System.Windows.Forms.Label();
            this.labelTeamId = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.bwOAuth = new System.ComponentModel.BackgroundWorker();
            this.groupBoxUserCredentials.SuspendLayout();
            this.groupBoxUserData.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUserCredentials
            // 
            this.groupBoxUserCredentials.Controls.Add(this.labelOAuthInstructions);
            this.groupBoxUserCredentials.Controls.Add(this.buttonOpenURL);
            this.groupBoxUserCredentials.Controls.Add(this.buttonTest);
            this.groupBoxUserCredentials.Controls.Add(this.buttonBrowse);
            this.groupBoxUserCredentials.Controls.Add(this.textBoxDataFolder);
            this.groupBoxUserCredentials.Controls.Add(this.labelDataFolder);
            this.groupBoxUserCredentials.Controls.Add(this.textBoxSecurityCode);
            this.groupBoxUserCredentials.Controls.Add(this.labelSecurityCode);
            this.groupBoxUserCredentials.Controls.Add(this.textBoxAuthorizationURL);
            this.groupBoxUserCredentials.Controls.Add(this.labelOAuth);
            this.groupBoxUserCredentials.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUserCredentials.Name = "groupBoxUserCredentials";
            this.groupBoxUserCredentials.Size = new System.Drawing.Size(476, 169);
            this.groupBoxUserCredentials.TabIndex = 0;
            this.groupBoxUserCredentials.TabStop = false;
            this.groupBoxUserCredentials.Text = "groupBoxUserCredentials";
            // 
            // labelOAuthInstructions
            // 
            this.labelOAuthInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelOAuthInstructions.Location = new System.Drawing.Point(9, 50);
            this.labelOAuthInstructions.Name = "labelOAuthInstructions";
            this.labelOAuthInstructions.Padding = new System.Windows.Forms.Padding(3);
            this.labelOAuthInstructions.Size = new System.Drawing.Size(461, 49);
            this.labelOAuthInstructions.TabIndex = 12;
            this.labelOAuthInstructions.Text = resources.GetString("labelOAuthInstructions.Text");
            // 
            // buttonOpenURL
            // 
            this.buttonOpenURL.Enabled = false;
            this.buttonOpenURL.Location = new System.Drawing.Point(385, 106);
            this.buttonOpenURL.Name = "buttonOpenURL";
            this.buttonOpenURL.Size = new System.Drawing.Size(85, 24);
            this.buttonOpenURL.TabIndex = 4;
            this.buttonOpenURL.Text = "Open URL";
            this.buttonOpenURL.UseVisualStyleBackColor = true;
            this.buttonOpenURL.Click += new System.EventHandler(this.buttonOpenURL_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Enabled = false;
            this.buttonTest.Location = new System.Drawing.Point(385, 135);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(85, 24);
            this.buttonTest.TabIndex = 6;
            this.buttonTest.Text = "buttonTest";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(385, 19);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(85, 24);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "buttonBrowse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxDataFolder
            // 
            this.textBoxDataFolder.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDataFolder.Location = new System.Drawing.Point(122, 21);
            this.textBoxDataFolder.MaxLength = 20;
            this.textBoxDataFolder.Name = "textBoxDataFolder";
            this.textBoxDataFolder.ReadOnly = true;
            this.textBoxDataFolder.Size = new System.Drawing.Size(257, 20);
            this.textBoxDataFolder.TabIndex = 1;
            // 
            // labelDataFolder
            // 
            this.labelDataFolder.Location = new System.Drawing.Point(6, 21);
            this.labelDataFolder.Margin = new System.Windows.Forms.Padding(3);
            this.labelDataFolder.Name = "labelDataFolder";
            this.labelDataFolder.Size = new System.Drawing.Size(110, 21);
            this.labelDataFolder.TabIndex = 7;
            this.labelDataFolder.Text = "labelDataFolder";
            this.labelDataFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxSecurityCode
            // 
            this.textBoxSecurityCode.Location = new System.Drawing.Point(122, 137);
            this.textBoxSecurityCode.Name = "textBoxSecurityCode";
            this.textBoxSecurityCode.Size = new System.Drawing.Size(257, 20);
            this.textBoxSecurityCode.TabIndex = 5;
            this.textBoxSecurityCode.TextChanged += new System.EventHandler(this.textBoxSecurityCode_TextChanged);
            // 
            // labelSecurityCode
            // 
            this.labelSecurityCode.Location = new System.Drawing.Point(6, 137);
            this.labelSecurityCode.Margin = new System.Windows.Forms.Padding(3);
            this.labelSecurityCode.Name = "labelSecurityCode";
            this.labelSecurityCode.Size = new System.Drawing.Size(110, 21);
            this.labelSecurityCode.TabIndex = 4;
            this.labelSecurityCode.Text = "labelSecurityCode";
            this.labelSecurityCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxAuthorizationURL
            // 
            this.textBoxAuthorizationURL.Location = new System.Drawing.Point(122, 108);
            this.textBoxAuthorizationURL.Name = "textBoxAuthorizationURL";
            this.textBoxAuthorizationURL.Size = new System.Drawing.Size(257, 20);
            this.textBoxAuthorizationURL.TabIndex = 3;
            this.textBoxAuthorizationURL.TextChanged += new System.EventHandler(this.textBoxAuthorizationURL_TextChanged);
            // 
            // labelOAuth
            // 
            this.labelOAuth.Location = new System.Drawing.Point(6, 108);
            this.labelOAuth.Margin = new System.Windows.Forms.Padding(3);
            this.labelOAuth.Name = "labelOAuth";
            this.labelOAuth.Size = new System.Drawing.Size(110, 21);
            this.labelOAuth.TabIndex = 1;
            this.labelOAuth.Text = "labelOAuth";
            this.labelOAuth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxUserData
            // 
            this.groupBoxUserData.Controls.Add(this.labelActivationDateValue);
            this.groupBoxUserData.Controls.Add(this.labelActivationDate);
            this.groupBoxUserData.Controls.Add(this.labelYouthTeamIdValue);
            this.groupBoxUserData.Controls.Add(this.labelYouthTeamId);
            this.groupBoxUserData.Controls.Add(this.labelTeamIdValue);
            this.groupBoxUserData.Controls.Add(this.labelTeamId);
            this.groupBoxUserData.Enabled = false;
            this.groupBoxUserData.Location = new System.Drawing.Point(12, 187);
            this.groupBoxUserData.Name = "groupBoxUserData";
            this.groupBoxUserData.Size = new System.Drawing.Size(476, 104);
            this.groupBoxUserData.TabIndex = 10;
            this.groupBoxUserData.TabStop = false;
            this.groupBoxUserData.Text = "groupBoxUserData";
            // 
            // labelActivationDateValue
            // 
            this.labelActivationDateValue.Enabled = false;
            this.labelActivationDateValue.Location = new System.Drawing.Point(140, 72);
            this.labelActivationDateValue.Margin = new System.Windows.Forms.Padding(3);
            this.labelActivationDateValue.Name = "labelActivationDateValue";
            this.labelActivationDateValue.Size = new System.Drawing.Size(330, 21);
            this.labelActivationDateValue.TabIndex = 16;
            this.labelActivationDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelActivationDate
            // 
            this.labelActivationDate.Enabled = false;
            this.labelActivationDate.Location = new System.Drawing.Point(6, 72);
            this.labelActivationDate.Margin = new System.Windows.Forms.Padding(3);
            this.labelActivationDate.Name = "labelActivationDate";
            this.labelActivationDate.Size = new System.Drawing.Size(128, 21);
            this.labelActivationDate.TabIndex = 15;
            this.labelActivationDate.Text = "labelActivationDate";
            this.labelActivationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelYouthTeamIdValue
            // 
            this.labelYouthTeamIdValue.Enabled = false;
            this.labelYouthTeamIdValue.Location = new System.Drawing.Point(140, 46);
            this.labelYouthTeamIdValue.Margin = new System.Windows.Forms.Padding(3);
            this.labelYouthTeamIdValue.Name = "labelYouthTeamIdValue";
            this.labelYouthTeamIdValue.Size = new System.Drawing.Size(330, 21);
            this.labelYouthTeamIdValue.TabIndex = 14;
            this.labelYouthTeamIdValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelYouthTeamId
            // 
            this.labelYouthTeamId.Enabled = false;
            this.labelYouthTeamId.Location = new System.Drawing.Point(6, 46);
            this.labelYouthTeamId.Margin = new System.Windows.Forms.Padding(3);
            this.labelYouthTeamId.Name = "labelYouthTeamId";
            this.labelYouthTeamId.Size = new System.Drawing.Size(128, 21);
            this.labelYouthTeamId.TabIndex = 13;
            this.labelYouthTeamId.Text = "labelYouthTeamId";
            this.labelYouthTeamId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTeamIdValue
            // 
            this.labelTeamIdValue.Enabled = false;
            this.labelTeamIdValue.Location = new System.Drawing.Point(140, 20);
            this.labelTeamIdValue.Margin = new System.Windows.Forms.Padding(3);
            this.labelTeamIdValue.Name = "labelTeamIdValue";
            this.labelTeamIdValue.Size = new System.Drawing.Size(330, 21);
            this.labelTeamIdValue.TabIndex = 12;
            this.labelTeamIdValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTeamId
            // 
            this.labelTeamId.Enabled = false;
            this.labelTeamId.Location = new System.Drawing.Point(6, 20);
            this.labelTeamId.Margin = new System.Windows.Forms.Padding(3);
            this.labelTeamId.Name = "labelTeamId";
            this.labelTeamId.Size = new System.Drawing.Size(128, 21);
            this.labelTeamId.TabIndex = 11;
            this.labelTeamId.Text = "labelTeamId";
            this.labelTeamId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(312, 301);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(85, 24);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(403, 301);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(85, 24);
            this.buttonOk.TabIndex = 8;
            this.buttonOk.Text = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // bwOAuth
            // 
            this.bwOAuth.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwOAuth_GetRequestTokenURL);
            this.bwOAuth.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwOAuth_CompleteGetRequestTokenURL);
            // 
            // FormAddEditUser
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(500, 332);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxUserData);
            this.Controls.Add(this.groupBoxUserCredentials);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormAddEditUser";
            this.groupBoxUserCredentials.ResumeLayout(false);
            this.groupBoxUserCredentials.PerformLayout();
            this.groupBoxUserData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUserCredentials;
        private System.Windows.Forms.TextBox textBoxSecurityCode;
        private System.Windows.Forms.Label labelSecurityCode;
        private System.Windows.Forms.TextBox textBoxAuthorizationURL;
        private System.Windows.Forms.Label labelOAuth;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textBoxDataFolder;
        private System.Windows.Forms.Label labelDataFolder;
        private System.Windows.Forms.GroupBox groupBoxUserData;
        private System.Windows.Forms.Label labelTeamId;
        private System.Windows.Forms.Label labelTeamIdValue;
        private System.Windows.Forms.Label labelYouthTeamIdValue;
        private System.Windows.Forms.Label labelYouthTeamId;
        private System.Windows.Forms.Label labelActivationDateValue;
        private System.Windows.Forms.Label labelActivationDate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonOpenURL;
        private System.Windows.Forms.Label labelOAuthInstructions;
        private System.ComponentModel.BackgroundWorker bwOAuth;
    }
}