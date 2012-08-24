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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewPlayers = new System.Windows.Forms.DataGridView();
            this.checkedListBoxPlayerGroups = new System.Windows.Forms.CheckedListBox();
            this.ColumnPlayerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlayerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlayerFlag = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnPlayerLastPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlayerBestPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlayerAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlayerForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlayerStamina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewPlayers, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkedListBoxPlayerGroups, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 387);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // dataGridViewPlayers
            // 
            this.dataGridViewPlayers.AllowUserToAddRows = false;
            this.dataGridViewPlayers.AllowUserToDeleteRows = false;
            this.dataGridViewPlayers.AllowUserToResizeRows = false;
            this.dataGridViewPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPlayers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewPlayers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPlayerID,
            this.ColumnPlayerNumber,
            this.ColumnPlayerName,
            this.ColumnPlayerFlag,
            this.ColumnPlayerLastPos,
            this.ColumnPlayerBestPos,
            this.ColumnPlayerAge,
            this.ColumnPlayerForm,
            this.ColumnPlayerStamina});
            this.dataGridViewPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPlayers.Location = new System.Drawing.Point(155, 5);
            this.dataGridViewPlayers.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridViewPlayers.Name = "dataGridViewPlayers";
            this.dataGridViewPlayers.RowHeadersVisible = false;
            this.dataGridViewPlayers.Size = new System.Drawing.Size(294, 222);
            this.dataGridViewPlayers.TabIndex = 6;
            // 
            // checkedListBoxPlayerGroups
            // 
            this.checkedListBoxPlayerGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxPlayerGroups.FormattingEnabled = true;
            this.checkedListBoxPlayerGroups.Items.AddRange(new object[] {
            "All",
            "A Squad",
            "B Squad"});
            this.checkedListBoxPlayerGroups.Location = new System.Drawing.Point(5, 5);
            this.checkedListBoxPlayerGroups.Margin = new System.Windows.Forms.Padding(5);
            this.checkedListBoxPlayerGroups.Name = "checkedListBoxPlayerGroups";
            this.checkedListBoxPlayerGroups.Size = new System.Drawing.Size(140, 222);
            this.checkedListBoxPlayerGroups.TabIndex = 7;
            // 
            // ColumnPlayerID
            // 
            this.ColumnPlayerID.DataPropertyName = "PlayerID";
            this.ColumnPlayerID.HeaderText = "ID";
            this.ColumnPlayerID.Name = "ColumnPlayerID";
            this.ColumnPlayerID.Visible = false;
            // 
            // ColumnPlayerNumber
            // 
            this.ColumnPlayerNumber.DataPropertyName = "PlayerNumber";
            this.ColumnPlayerNumber.HeaderText = "#";
            this.ColumnPlayerNumber.Name = "ColumnPlayerNumber";
            // 
            // ColumnPlayerName
            // 
            this.ColumnPlayerName.DataPropertyName = "PlayerName";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColumnPlayerName.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnPlayerName.HeaderText = "Name";
            this.ColumnPlayerName.Name = "ColumnPlayerName";
            this.ColumnPlayerName.ReadOnly = true;
            // 
            // ColumnPlayerFlag
            // 
            this.ColumnPlayerFlag.DataPropertyName = "PlayerFlag";
            this.ColumnPlayerFlag.HeaderText = "Nationality";
            this.ColumnPlayerFlag.Name = "ColumnPlayerFlag";
            this.ColumnPlayerFlag.ToolTipText = "Nationality";
            // 
            // ColumnPlayerLastPos
            // 
            this.ColumnPlayerLastPos.DataPropertyName = "LastPosition";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColumnPlayerLastPos.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnPlayerLastPos.HeaderText = "Last Position";
            this.ColumnPlayerLastPos.Name = "ColumnPlayerLastPos";
            // 
            // ColumnPlayerBestPos
            // 
            this.ColumnPlayerBestPos.DataPropertyName = "BestPosition";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColumnPlayerBestPos.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnPlayerBestPos.HeaderText = "Best Position";
            this.ColumnPlayerBestPos.Name = "ColumnPlayerBestPos";
            // 
            // ColumnPlayerAge
            // 
            this.ColumnPlayerAge.DataPropertyName = "Age";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnPlayerAge.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnPlayerAge.HeaderText = "Age";
            this.ColumnPlayerAge.Name = "ColumnPlayerAge";
            this.ColumnPlayerAge.ReadOnly = true;
            // 
            // ColumnPlayerForm
            // 
            this.ColumnPlayerForm.DataPropertyName = "Form";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnPlayerForm.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnPlayerForm.HeaderText = "Form";
            this.ColumnPlayerForm.Name = "ColumnPlayerForm";
            // 
            // ColumnPlayerStamina
            // 
            this.ColumnPlayerStamina.DataPropertyName = "Stamina";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnPlayerStamina.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnPlayerStamina.HeaderText = "Stamina";
            this.ColumnPlayerStamina.Name = "ColumnPlayerStamina";
            // 
            // Lineup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Lineup";
            this.Size = new System.Drawing.Size(654, 387);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridViewPlayers;
        private System.Windows.Forms.CheckedListBox checkedListBoxPlayerGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlayerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlayerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlayerName;
        private System.Windows.Forms.DataGridViewImageColumn ColumnPlayerFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlayerLastPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlayerBestPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlayerAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlayerForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlayerStamina;
    }
}
