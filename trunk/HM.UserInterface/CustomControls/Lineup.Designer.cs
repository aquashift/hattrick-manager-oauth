namespace HM.UserInterface.CustomControls {
    partial class Lineup {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerTop = new System.Windows.Forms.SplitContainer();
            this.dataGridViewPlayers = new System.Windows.Forms.DataGridView();
            this.tabControlPlayerDetails = new System.Windows.Forms.TabControl();
            this.tabPageSkills = new System.Windows.Forms.TabPage();
            this.dataGridViewPlayerSkills = new System.Windows.Forms.DataGridView();
            this.tabPagePositions = new System.Windows.Forms.TabPage();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.splitContainerTop.Panel1.SuspendLayout();
            this.splitContainerTop.Panel2.SuspendLayout();
            this.splitContainerTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).BeginInit();
            this.tabControlPlayerDetails.SuspendLayout();
            this.tabPageSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayerSkills)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerTop);
            this.splitContainerMain.Size = new System.Drawing.Size(901, 605);
            this.splitContainerMain.SplitterDistance = 394;
            this.splitContainerMain.SplitterWidth = 5;
            this.splitContainerMain.TabIndex = 0;
            // 
            // splitContainerTop
            // 
            this.splitContainerTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTop.Name = "splitContainerTop";
            // 
            // splitContainerTop.Panel1
            // 
            this.splitContainerTop.Panel1.Controls.Add(this.dataGridViewPlayers);
            // 
            // splitContainerTop.Panel2
            // 
            this.splitContainerTop.Panel2.Controls.Add(this.tabControlPlayerDetails);
            this.splitContainerTop.Size = new System.Drawing.Size(901, 394);
            this.splitContainerTop.SplitterDistance = 696;
            this.splitContainerTop.SplitterWidth = 5;
            this.splitContainerTop.TabIndex = 0;
            // 
            // dataGridViewPlayers
            // 
            this.dataGridViewPlayers.AllowUserToAddRows = false;
            this.dataGridViewPlayers.AllowUserToDeleteRows = false;
            this.dataGridViewPlayers.AllowUserToResizeRows = false;
            this.dataGridViewPlayers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPlayers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPlayers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPlayers.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.dataGridViewPlayers.Size = new System.Drawing.Size(692, 390);
            this.dataGridViewPlayers.TabIndex = 10;
            this.dataGridViewPlayers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPlayers_CellClick);
            // 
            // tabControlPlayerDetails
            // 
            this.tabControlPlayerDetails.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlPlayerDetails.Controls.Add(this.tabPageSkills);
            this.tabControlPlayerDetails.Controls.Add(this.tabPagePositions);
            this.tabControlPlayerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPlayerDetails.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlPlayerDetails.Location = new System.Drawing.Point(0, 0);
            this.tabControlPlayerDetails.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlPlayerDetails.Multiline = true;
            this.tabControlPlayerDetails.Name = "tabControlPlayerDetails";
            this.tabControlPlayerDetails.SelectedIndex = 0;
            this.tabControlPlayerDetails.Size = new System.Drawing.Size(196, 390);
            this.tabControlPlayerDetails.TabIndex = 0;
            // 
            // tabPageSkills
            // 
            this.tabPageSkills.Controls.Add(this.dataGridViewPlayerSkills);
            this.tabPageSkills.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageSkills.Location = new System.Drawing.Point(4, 4);
            this.tabPageSkills.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSkills.Name = "tabPageSkills";
            this.tabPageSkills.Size = new System.Drawing.Size(188, 362);
            this.tabPageSkills.TabIndex = 0;
            this.tabPageSkills.Text = "SKILLS";
            // 
            // dataGridViewPlayerSkills
            // 
            this.dataGridViewPlayerSkills.AllowUserToAddRows = false;
            this.dataGridViewPlayerSkills.AllowUserToDeleteRows = false;
            this.dataGridViewPlayerSkills.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewPlayerSkills.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewPlayerSkills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPlayerSkills.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewPlayerSkills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPlayerSkills.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dataGridViewPlayerSkills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPlayerSkills.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPlayerSkills.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewPlayerSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPlayerSkills.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewPlayerSkills.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPlayerSkills.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewPlayerSkills.MultiSelect = false;
            this.dataGridViewPlayerSkills.Name = "dataGridViewPlayerSkills";
            this.dataGridViewPlayerSkills.ReadOnly = true;
            this.dataGridViewPlayerSkills.RowHeadersVisible = false;
            this.dataGridViewPlayerSkills.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewPlayerSkills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewPlayerSkills.ShowCellErrors = false;
            this.dataGridViewPlayerSkills.ShowEditingIcon = false;
            this.dataGridViewPlayerSkills.ShowRowErrors = false;
            this.dataGridViewPlayerSkills.Size = new System.Drawing.Size(188, 362);
            this.dataGridViewPlayerSkills.TabIndex = 11;
            // 
            // tabPagePositions
            // 
            this.tabPagePositions.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPagePositions.Location = new System.Drawing.Point(4, 4);
            this.tabPagePositions.Margin = new System.Windows.Forms.Padding(0);
            this.tabPagePositions.Name = "tabPagePositions";
            this.tabPagePositions.Size = new System.Drawing.Size(188, 362);
            this.tabPagePositions.TabIndex = 1;
            this.tabPagePositions.Text = "POSITIONS";
            this.tabPagePositions.UseVisualStyleBackColor = true;
            // 
            // Lineup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Lineup";
            this.Size = new System.Drawing.Size(901, 605);
            this.Load += new System.EventHandler(this.Lineup_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerTop.Panel1.ResumeLayout(false);
            this.splitContainerTop.Panel2.ResumeLayout(false);
            this.splitContainerTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).EndInit();
            this.tabControlPlayerDetails.ResumeLayout(false);
            this.tabPageSkills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayerSkills)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerTop;
        private System.Windows.Forms.DataGridView dataGridViewPlayers;
        private System.Windows.Forms.TabControl tabControlPlayerDetails;
        private System.Windows.Forms.TabPage tabPageSkills;
        private System.Windows.Forms.TabPage tabPagePositions;
        private System.Windows.Forms.DataGridView dataGridViewPlayerSkills;




    }
}
