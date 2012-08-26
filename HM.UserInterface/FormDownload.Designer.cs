namespace HM.UserInterface
{
    partial class FormDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDownload));
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxDownload = new System.Windows.Forms.GroupBox();
            this.checkBoxDownloadFullMatchesArchive = new System.Windows.Forms.CheckBox();
            this.listBoxDownload = new System.Windows.Forms.ListBox();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.groupBoxDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(285, 337);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(99, 28);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBoxDownload
            // 
            this.groupBoxDownload.Controls.Add(this.checkBoxDownloadFullMatchesArchive);
            this.groupBoxDownload.Controls.Add(this.listBoxDownload);
            this.groupBoxDownload.Controls.Add(this.progressBarDownload);
            this.groupBoxDownload.Controls.Add(this.buttonDownload);
            this.groupBoxDownload.Location = new System.Drawing.Point(14, 14);
            this.groupBoxDownload.Name = "groupBoxDownload";
            this.groupBoxDownload.Size = new System.Drawing.Size(377, 316);
            this.groupBoxDownload.TabIndex = 2;
            this.groupBoxDownload.TabStop = false;
            this.groupBoxDownload.Text = "groupBoxDownload";
            // 
            // checkBoxDownloadFullMatchesArchive
            // 
            this.checkBoxDownloadFullMatchesArchive.Location = new System.Drawing.Point(7, 275);
            this.checkBoxDownloadFullMatchesArchive.Name = "checkBoxDownloadFullMatchesArchive";
            this.checkBoxDownloadFullMatchesArchive.Size = new System.Drawing.Size(257, 28);
            this.checkBoxDownloadFullMatchesArchive.TabIndex = 21;
            this.checkBoxDownloadFullMatchesArchive.Text = "checkBoxDownloadFullMatchesArchive";
            this.checkBoxDownloadFullMatchesArchive.UseVisualStyleBackColor = true;
            // 
            // listBoxDownload
            // 
            this.listBoxDownload.FormattingEnabled = true;
            this.listBoxDownload.ItemHeight = 15;
            this.listBoxDownload.Location = new System.Drawing.Point(7, 22);
            this.listBoxDownload.Name = "listBoxDownload";
            this.listBoxDownload.Size = new System.Drawing.Size(362, 214);
            this.listBoxDownload.TabIndex = 20;
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Location = new System.Drawing.Point(7, 243);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(363, 24);
            this.progressBarDownload.TabIndex = 19;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(271, 275);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(99, 28);
            this.buttonDownload.TabIndex = 18;
            this.buttonDownload.Text = "buttonDownload";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // FormDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 378);
            this.Controls.Add(this.groupBoxDownload);
            this.Controls.Add(this.buttonClose);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDownload";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormDownload";
            this.groupBoxDownload.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBoxDownload;
        private System.Windows.Forms.ListBox listBoxDownload;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.CheckBox checkBoxDownloadFullMatchesArchive;
    }
}