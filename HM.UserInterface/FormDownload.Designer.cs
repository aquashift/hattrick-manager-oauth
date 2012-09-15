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
            this.dataGridViewDownload = new System.Windows.Forms.DataGridView();
            this.checkBoxDownloadExistingFiles = new System.Windows.Forms.CheckBox();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProgress = new HM.Resources.DataGridViewProgressColumn();
            this.groupBoxDownload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDownload)).BeginInit();
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
            this.groupBoxDownload.Controls.Add(this.dataGridViewDownload);
            this.groupBoxDownload.Controls.Add(this.checkBoxDownloadExistingFiles);
            this.groupBoxDownload.Controls.Add(this.progressBarDownload);
            this.groupBoxDownload.Controls.Add(this.buttonDownload);
            this.groupBoxDownload.Location = new System.Drawing.Point(14, 14);
            this.groupBoxDownload.Name = "groupBoxDownload";
            this.groupBoxDownload.Size = new System.Drawing.Size(377, 316);
            this.groupBoxDownload.TabIndex = 2;
            this.groupBoxDownload.TabStop = false;
            this.groupBoxDownload.Text = "groupBoxDownload";
            // 
            // dataGridViewDownload
            // 
            this.dataGridViewDownload.AllowUserToAddRows = false;
            this.dataGridViewDownload.AllowUserToDeleteRows = false;
            this.dataGridViewDownload.AllowUserToResizeColumns = false;
            this.dataGridViewDownload.AllowUserToResizeRows = false;
            this.dataGridViewDownload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDownload.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnProgress});
            this.dataGridViewDownload.Location = new System.Drawing.Point(7, 22);
            this.dataGridViewDownload.Name = "dataGridViewDownload";
            this.dataGridViewDownload.ReadOnly = true;
            this.dataGridViewDownload.RowHeadersVisible = false;
            this.dataGridViewDownload.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewDownload.Size = new System.Drawing.Size(363, 215);
            this.dataGridViewDownload.TabIndex = 22;
            // 
            // checkBoxDownloadExistingFiles
            // 
            this.checkBoxDownloadExistingFiles.Location = new System.Drawing.Point(7, 275);
            this.checkBoxDownloadExistingFiles.Name = "checkBoxDownloadExistingFiles";
            this.checkBoxDownloadExistingFiles.Size = new System.Drawing.Size(257, 28);
            this.checkBoxDownloadExistingFiles.TabIndex = 21;
            this.checkBoxDownloadExistingFiles.Text = "checkBoxDownloadExistingFiles";
            this.checkBoxDownloadExistingFiles.UseVisualStyleBackColor = true;
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
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "Download";
            this.ColumnName.MinimumWidth = 20;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnProgress
            // 
            this.ColumnProgress.DataPropertyName = "Progress";
            this.ColumnProgress.HeaderText = "Progress";
            this.ColumnProgress.MinimumWidth = 60;
            this.ColumnProgress.Name = "ColumnProgress";
            this.ColumnProgress.ReadOnly = true;
            this.ColumnProgress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnProgress.Width = 60;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDownload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBoxDownload;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.CheckBox checkBoxDownloadExistingFiles;
        private System.Windows.Forms.DataGridView dataGridViewDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private Resources.DataGridViewProgressColumn ColumnProgress;
    }
}