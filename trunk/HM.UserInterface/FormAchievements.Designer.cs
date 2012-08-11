namespace HM.UserInterface
{
    partial class FormAchievements
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAchievements));
            this.dataGridViewAchievements = new System.Windows.Forms.DataGridView();
            this.columnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnEventDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMultiLevel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnNumberOfEvents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelTotalPoints = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelCategory = new System.Windows.Forms.Label();
            this.comboBoxAchievementsCategory = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAchievements)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAchievements
            // 
            this.dataGridViewAchievements.AllowUserToAddRows = false;
            this.dataGridViewAchievements.AllowUserToDeleteRows = false;
            this.dataGridViewAchievements.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridViewAchievements.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAchievements.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewAchievements.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewAchievements.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewAchievements.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewAchievements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewAchievements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnText,
            this.columnTypeID,
            this.columnCategoryID,
            this.columnEventDate,
            this.columnPoints,
            this.columnMultiLevel,
            this.columnNumberOfEvents});
            this.dataGridViewAchievements.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAchievements.Location = new System.Drawing.Point(12, 39);
            this.dataGridViewAchievements.MultiSelect = false;
            this.dataGridViewAchievements.Name = "dataGridViewAchievements";
            this.dataGridViewAchievements.ReadOnly = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAchievements.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewAchievements.RowHeadersVisible = false;
            this.dataGridViewAchievements.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewAchievements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAchievements.Size = new System.Drawing.Size(820, 245);
            this.dataGridViewAchievements.TabIndex = 0;
            // 
            // columnText
            // 
            this.columnText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnText.DataPropertyName = "Text";
            this.columnText.HeaderText = "columnText";
            this.columnText.Name = "columnText";
            this.columnText.ReadOnly = true;
            // 
            // columnTypeID
            // 
            this.columnTypeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnTypeID.DataPropertyName = "TypeID";
            this.columnTypeID.HeaderText = "columnTypeID";
            this.columnTypeID.Name = "columnTypeID";
            this.columnTypeID.ReadOnly = true;
            this.columnTypeID.Visible = false;
            // 
            // columnCategoryID
            // 
            this.columnCategoryID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnCategoryID.DataPropertyName = "CategoryID";
            this.columnCategoryID.HeaderText = "columnCategoryID";
            this.columnCategoryID.Name = "columnCategoryID";
            this.columnCategoryID.ReadOnly = true;
            this.columnCategoryID.Width = 119;
            // 
            // columnEventDate
            // 
            this.columnEventDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnEventDate.DataPropertyName = "EventDate";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            this.columnEventDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnEventDate.HeaderText = "columnEventDate";
            this.columnEventDate.Name = "columnEventDate";
            this.columnEventDate.ReadOnly = true;
            this.columnEventDate.Width = 117;
            // 
            // columnPoints
            // 
            this.columnPoints.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnPoints.DataPropertyName = "Points";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.columnPoints.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnPoints.HeaderText = "columnPoints";
            this.columnPoints.Name = "columnPoints";
            this.columnPoints.ReadOnly = true;
            this.columnPoints.Width = 95;
            // 
            // columnMultiLevel
            // 
            this.columnMultiLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnMultiLevel.DataPropertyName = "MultiLevel";
            this.columnMultiLevel.HeaderText = "columnMultiLevel";
            this.columnMultiLevel.Name = "columnMultiLevel";
            this.columnMultiLevel.ReadOnly = true;
            this.columnMultiLevel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnMultiLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnMultiLevel.Width = 114;
            // 
            // columnNumberOfEvents
            // 
            this.columnNumberOfEvents.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnNumberOfEvents.DataPropertyName = "NumberOfEvents";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.columnNumberOfEvents.DefaultCellStyle = dataGridViewCellStyle4;
            this.columnNumberOfEvents.HeaderText = "columnNumberOfEvents";
            this.columnNumberOfEvents.Name = "columnNumberOfEvents";
            this.columnNumberOfEvents.ReadOnly = true;
            this.columnNumberOfEvents.Width = 147;
            // 
            // labelPoints
            // 
            this.labelPoints.Location = new System.Drawing.Point(12, 290);
            this.labelPoints.Margin = new System.Windows.Forms.Padding(3);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(100, 21);
            this.labelPoints.TabIndex = 1;
            this.labelPoints.Text = "labelPoints";
            this.labelPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTotalPoints
            // 
            this.labelTotalPoints.Location = new System.Drawing.Point(118, 290);
            this.labelTotalPoints.Margin = new System.Windows.Forms.Padding(3);
            this.labelTotalPoints.Name = "labelTotalPoints";
            this.labelTotalPoints.Size = new System.Drawing.Size(206, 21);
            this.labelTotalPoints.TabIndex = 3;
            this.labelTotalPoints.Text = "labelTotalPoints";
            this.labelTotalPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(747, 305);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(85, 24);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelCategory
            // 
            this.labelCategory.Location = new System.Drawing.Point(12, 12);
            this.labelCategory.Margin = new System.Windows.Forms.Padding(3);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(100, 21);
            this.labelCategory.TabIndex = 5;
            this.labelCategory.Text = "labelCategory";
            this.labelCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxAchievementsCategory
            // 
            this.comboBoxAchievementsCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAchievementsCategory.FormattingEnabled = true;
            this.comboBoxAchievementsCategory.Location = new System.Drawing.Point(120, 12);
            this.comboBoxAchievementsCategory.Name = "comboBoxAchievementsCategory";
            this.comboBoxAchievementsCategory.Size = new System.Drawing.Size(177, 21);
            this.comboBoxAchievementsCategory.TabIndex = 6;
            this.comboBoxAchievementsCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxAchievementsCategory_SelectedIndexChanged);
            // 
            // FormAchievements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 341);
            this.Controls.Add(this.comboBoxAchievementsCategory);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelTotalPoints);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.dataGridViewAchievements);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAchievements";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormAchievements";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAchievements)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAchievements;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelTotalPoints;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ComboBox comboBoxAchievementsCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnText;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnEventDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPoints;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnMultiLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNumberOfEvents;
    }
}