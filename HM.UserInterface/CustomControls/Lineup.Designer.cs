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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerTop = new System.Windows.Forms.SplitContainer();
            this.dataGridViewPlayers = new System.Windows.Forms.DataGridView();
            this.tabControlPlayerDetails = new System.Windows.Forms.TabControl();
            this.tabPageSkills = new System.Windows.Forms.TabPage();
            this.tabPagePositions = new System.Windows.Forms.TabPage();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.splitContainerTop.Panel1.SuspendLayout();
            this.splitContainerTop.Panel2.SuspendLayout();
            this.splitContainerTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).BeginInit();
            this.tabControlPlayerDetails.SuspendLayout();
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
            // 
            // tabControlPlayerDetails
            // 
            this.tabControlPlayerDetails.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlPlayerDetails.Controls.Add(this.tabPageSkills);
            this.tabControlPlayerDetails.Controls.Add(this.tabPagePositions);
            this.tabControlPlayerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPlayerDetails.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlPlayerDetails.Location = new System.Drawing.Point(0, 0);
            this.tabControlPlayerDetails.Multiline = true;
            this.tabControlPlayerDetails.Name = "tabControlPlayerDetails";
            this.tabControlPlayerDetails.SelectedIndex = 0;
            this.tabControlPlayerDetails.Size = new System.Drawing.Size(196, 390);
            this.tabControlPlayerDetails.TabIndex = 0;
            // 
            // tabPageSkills
            // 
            this.tabPageSkills.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPageSkills.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageSkills.Location = new System.Drawing.Point(4, 4);
            this.tabPageSkills.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSkills.Name = "tabPageSkills";
            this.tabPageSkills.Size = new System.Drawing.Size(188, 362);
            this.tabPageSkills.TabIndex = 0;
            this.tabPageSkills.Text = "SKILLS";
            this.tabPageSkills.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerTop;
        private System.Windows.Forms.DataGridView dataGridViewPlayers;
        private System.Windows.Forms.TabControl tabControlPlayerDetails;
        private System.Windows.Forms.TabPage tabPageSkills;
        private System.Windows.Forms.TabPage tabPagePositions;




    }
}
