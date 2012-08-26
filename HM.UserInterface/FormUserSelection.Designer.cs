namespace HM.UserInterface
{
    partial class FormUserSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserSelection));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBoxUserProfiles = new System.Windows.Forms.GroupBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listBoxUserProfiles = new System.Windows.Forms.ListBox();
            this.groupBoxUserProfiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(176, 134);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(99, 28);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(282, 134);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(99, 28);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBoxUserProfiles
            // 
            this.groupBoxUserProfiles.Controls.Add(this.buttonEdit);
            this.groupBoxUserProfiles.Controls.Add(this.buttonAdd);
            this.groupBoxUserProfiles.Controls.Add(this.listBoxUserProfiles);
            this.groupBoxUserProfiles.Location = new System.Drawing.Point(14, 14);
            this.groupBoxUserProfiles.Name = "groupBoxUserProfiles";
            this.groupBoxUserProfiles.Size = new System.Drawing.Size(374, 113);
            this.groupBoxUserProfiles.TabIndex = 3;
            this.groupBoxUserProfiles.TabStop = false;
            this.groupBoxUserProfiles.Text = "groupBoxUserProfiles";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(268, 62);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(99, 28);
            this.buttonEdit.TabIndex = 7;
            this.buttonEdit.Text = "buttonEdit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(268, 28);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(99, 28);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "buttonAdd";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // listBoxUserProfiles
            // 
            this.listBoxUserProfiles.FormattingEnabled = true;
            this.listBoxUserProfiles.ItemHeight = 15;
            this.listBoxUserProfiles.Location = new System.Drawing.Point(7, 20);
            this.listBoxUserProfiles.Name = "listBoxUserProfiles";
            this.listBoxUserProfiles.Size = new System.Drawing.Size(254, 79);
            this.listBoxUserProfiles.TabIndex = 5;
            this.listBoxUserProfiles.SelectedIndexChanged += new System.EventHandler(this.listBoxUserProfiles_SelectedIndexChanged);
            // 
            // FormUserSelection
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(402, 175);
            this.Controls.Add(this.groupBoxUserProfiles);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUserSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUserSelection";
            this.groupBoxUserProfiles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBoxUserProfiles;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ListBox listBoxUserProfiles;
        private System.Windows.Forms.Button buttonAdd;
    }
}