namespace HM.UserInterface.CustomControls {
    partial class PlayerList {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlPlayerDetails = new System.Windows.Forms.TabControl();
            this.tabPageSkills = new System.Windows.Forms.TabPage();
            this.dataGridViewPlayerSkills = new System.Windows.Forms.DataGridView();
            this.tabPagePositions = new System.Windows.Forms.TabPage();
            this.dataGridViewPlayers = new System.Windows.Forms.DataGridView();
            this.splitContainerPlayerList = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelCategories = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCategoryName = new System.Windows.Forms.Button();
            this.checkedListBoxCategories = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanelDetails = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPlayerName = new System.Windows.Forms.Button();
            this.tabControlPlayerDetails.SuspendLayout();
            this.tabPageSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayerSkills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).BeginInit();
            this.splitContainerPlayerList.Panel1.SuspendLayout();
            this.splitContainerPlayerList.Panel2.SuspendLayout();
            this.splitContainerPlayerList.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanelCategories.SuspendLayout();
            this.tableLayoutPanelDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPlayerDetails
            // 
            this.tabControlPlayerDetails.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlPlayerDetails.Controls.Add(this.tabPageSkills);
            this.tabControlPlayerDetails.Controls.Add(this.tabPagePositions);
            this.tabControlPlayerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPlayerDetails.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlPlayerDetails.Location = new System.Drawing.Point(0, 30);
            this.tabControlPlayerDetails.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlPlayerDetails.Multiline = true;
            this.tabControlPlayerDetails.Name = "tabControlPlayerDetails";
            this.tabControlPlayerDetails.SelectedIndex = 0;
            this.tabControlPlayerDetails.Size = new System.Drawing.Size(243, 431);
            this.tabControlPlayerDetails.TabIndex = 0;
            // 
            // tabPageSkills
            // 
            this.tabPageSkills.Controls.Add(this.dataGridViewPlayerSkills);
            this.tabPageSkills.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageSkills.Location = new System.Drawing.Point(4, 4);
            this.tabPageSkills.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSkills.Name = "tabPageSkills";
            this.tabPageSkills.Size = new System.Drawing.Size(235, 403);
            this.tabPageSkills.TabIndex = 0;
            this.tabPageSkills.Text = "SKILLS";
            // 
            // dataGridViewPlayerSkills
            // 
            this.dataGridViewPlayerSkills.AllowUserToAddRows = false;
            this.dataGridViewPlayerSkills.AllowUserToDeleteRows = false;
            this.dataGridViewPlayerSkills.AllowUserToResizeRows = false;
            this.dataGridViewPlayerSkills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPlayerSkills.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewPlayerSkills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPlayerSkills.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewPlayerSkills.ColumnHeadersVisible = false;
            this.dataGridViewPlayerSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPlayerSkills.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewPlayerSkills.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewPlayerSkills.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPlayerSkills.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewPlayerSkills.MultiSelect = false;
            this.dataGridViewPlayerSkills.Name = "dataGridViewPlayerSkills";
            this.dataGridViewPlayerSkills.ReadOnly = true;
            this.dataGridViewPlayerSkills.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewPlayerSkills.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPlayerSkills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPlayerSkills.Size = new System.Drawing.Size(235, 403);
            this.dataGridViewPlayerSkills.TabIndex = 0;
            // 
            // tabPagePositions
            // 
            this.tabPagePositions.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPagePositions.Location = new System.Drawing.Point(4, 4);
            this.tabPagePositions.Margin = new System.Windows.Forms.Padding(0);
            this.tabPagePositions.Name = "tabPagePositions";
            this.tabPagePositions.Size = new System.Drawing.Size(235, 403);
            this.tabPagePositions.TabIndex = 1;
            this.tabPagePositions.Text = "POSITIONS";
            this.tabPagePositions.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPlayers
            // 
            this.dataGridViewPlayers.AllowUserToAddRows = false;
            this.dataGridViewPlayers.AllowUserToDeleteRows = false;
            this.dataGridViewPlayers.AllowUserToOrderColumns = true;
            this.dataGridViewPlayers.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewPlayers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPlayers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPlayers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPlayers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPlayers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPlayers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewPlayers.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPlayers.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewPlayers.MultiSelect = false;
            this.dataGridViewPlayers.Name = "dataGridViewPlayers";
            this.dataGridViewPlayers.RowHeadersVisible = false;
            this.dataGridViewPlayers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPlayers.ShowCellErrors = false;
            this.dataGridViewPlayers.ShowEditingIcon = false;
            this.dataGridViewPlayers.ShowRowErrors = false;
            this.dataGridViewPlayers.Size = new System.Drawing.Size(337, 461);
            this.dataGridViewPlayers.TabIndex = 11;
            this.dataGridViewPlayers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPlayers_CellClick);
            // 
            // splitContainerPlayerList
            // 
            this.splitContainerPlayerList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerPlayerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerPlayerList.Location = new System.Drawing.Point(0, 0);
            this.splitContainerPlayerList.Name = "splitContainerPlayerList";
            // 
            // splitContainerPlayerList.Panel1
            // 
            this.splitContainerPlayerList.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainerPlayerList.Panel2
            // 
            this.splitContainerPlayerList.Panel2.Controls.Add(this.tableLayoutPanelDetails);
            this.splitContainerPlayerList.Size = new System.Drawing.Size(736, 465);
            this.splitContainerPlayerList.SplitterDistance = 485;
            this.splitContainerPlayerList.TabIndex = 12;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanelCategories);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewPlayers);
            this.splitContainer1.Size = new System.Drawing.Size(481, 461);
            this.splitContainer1.SplitterDistance = 140;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanelCategories
            // 
            this.tableLayoutPanelCategories.ColumnCount = 1;
            this.tableLayoutPanelCategories.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCategories.Controls.Add(this.buttonCategoryName, 0, 0);
            this.tableLayoutPanelCategories.Controls.Add(this.checkedListBoxCategories, 0, 1);
            this.tableLayoutPanelCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCategories.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCategories.Name = "tableLayoutPanelCategories";
            this.tableLayoutPanelCategories.RowCount = 2;
            this.tableLayoutPanelCategories.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelCategories.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCategories.Size = new System.Drawing.Size(140, 461);
            this.tableLayoutPanelCategories.TabIndex = 1;
            // 
            // buttonCategoryName
            // 
            this.buttonCategoryName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCategoryName.FlatAppearance.BorderSize = 0;
            this.buttonCategoryName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCategoryName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCategoryName.ForeColor = System.Drawing.Color.Black;
            this.buttonCategoryName.Location = new System.Drawing.Point(0, 0);
            this.buttonCategoryName.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCategoryName.Name = "buttonCategoryName";
            this.buttonCategoryName.Size = new System.Drawing.Size(140, 30);
            this.buttonCategoryName.TabIndex = 2;
            this.buttonCategoryName.Text = "Categories";
            this.buttonCategoryName.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxCategories
            // 
            this.checkedListBoxCategories.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxCategories.CheckOnClick = true;
            this.checkedListBoxCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxCategories.FormattingEnabled = true;
            this.checkedListBoxCategories.Items.AddRange(new object[] {
            "All",
            "Squad A",
            "Squad B",
            "Uncategorised"});
            this.checkedListBoxCategories.Location = new System.Drawing.Point(3, 33);
            this.checkedListBoxCategories.Name = "checkedListBoxCategories";
            this.checkedListBoxCategories.Size = new System.Drawing.Size(134, 425);
            this.checkedListBoxCategories.TabIndex = 0;
            this.checkedListBoxCategories.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxCategories_MouseDown);
            // 
            // tableLayoutPanelDetails
            // 
            this.tableLayoutPanelDetails.ColumnCount = 1;
            this.tableLayoutPanelDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDetails.Controls.Add(this.tabControlPlayerDetails, 0, 1);
            this.tableLayoutPanelDetails.Controls.Add(this.buttonPlayerName, 0, 0);
            this.tableLayoutPanelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDetails.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelDetails.Name = "tableLayoutPanelDetails";
            this.tableLayoutPanelDetails.RowCount = 2;
            this.tableLayoutPanelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDetails.Size = new System.Drawing.Size(243, 461);
            this.tableLayoutPanelDetails.TabIndex = 0;
            // 
            // buttonPlayerName
            // 
            this.buttonPlayerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlayerName.FlatAppearance.BorderSize = 0;
            this.buttonPlayerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayerName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlayerName.ForeColor = System.Drawing.Color.Black;
            this.buttonPlayerName.Location = new System.Drawing.Point(0, 0);
            this.buttonPlayerName.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPlayerName.Name = "buttonPlayerName";
            this.buttonPlayerName.Size = new System.Drawing.Size(243, 30);
            this.buttonPlayerName.TabIndex = 1;
            this.buttonPlayerName.UseVisualStyleBackColor = true;
            // 
            // PlayerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerPlayerList);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PlayerList";
            this.Size = new System.Drawing.Size(736, 465);
            this.Load += new System.EventHandler(this.Lineup_Load);
            this.tabControlPlayerDetails.ResumeLayout(false);
            this.tabPageSkills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayerSkills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).EndInit();
            this.splitContainerPlayerList.Panel1.ResumeLayout(false);
            this.splitContainerPlayerList.Panel2.ResumeLayout(false);
            this.splitContainerPlayerList.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanelCategories.ResumeLayout(false);
            this.tableLayoutPanelDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPlayerDetails;
        private System.Windows.Forms.TabPage tabPagePositions;
        private System.Windows.Forms.DataGridView dataGridViewPlayers;
        private System.Windows.Forms.SplitContainer splitContainerPlayerList;
        private System.Windows.Forms.TabPage tabPageSkills;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDetails;
        private System.Windows.Forms.Button buttonPlayerName;
        private System.Windows.Forms.DataGridView dataGridViewPlayerSkills;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckedListBox checkedListBoxCategories;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCategories;
        private System.Windows.Forms.Button buttonCategoryName;




    }
}
