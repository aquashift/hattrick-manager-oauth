using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HM.Core;
using HTEntities = HM.Entities.Hattrick;
using HM.Resources.Constants;
using HM.Entities.HattrickManager.UserProfiles;

namespace HM.UserInterface.CustomControls {
    public partial class PlayerList : UserControl {
        #region Properties

        private DataManager dataManager;
        private HTEntities.Players.Players players;
        private HTEntities.Players.Players lastPlayers;
        private User user;
        private EntityManager entityManager;
        private bool buildingUI;

        #endregion

        public PlayerList(User user) {
            InitializeComponent();

            this.user = user;

            if (user != null) {
                this.entityManager = new EntityManager(user);
                this.dataManager = new DataManager(user);
                this.players = entityManager.GetPlayersDetails();
                this.lastPlayers = entityManager.GetLastWeekPlayersDetails();
            }
        }

        public PlayerList() {
            InitializeComponent();
        }

        #region Methods

        private void Lineup_Load(object sender, EventArgs e) {
            Setup_Resources();

            if (players != null) {
                buildingUI = true;
                SetupPlayerListColumns();
                PopulatePlayerList();
                PopulateCategoryList();
                buildingUI = false;
            }
        }

        private void PopulateCategoryList() {
            int i = 0;

            tableLayoutPanelCategoriesList.Controls.Clear();
            tableLayoutPanelCategoriesList.RowCount = user.applicationSettingsField.playerCategoryListField.Count + 1;
            tableLayoutPanelCategoriesList.RowStyles.Clear();

            user.applicationSettingsField.playerCategoryListField.Sort(delegate(HM.Entities.HattrickManager.Settings.Category c1, HM.Entities.HattrickManager.Settings.Category c2) { return c1.categoryIdField.CompareTo(c2.categoryIdField); });

            foreach (HM.Entities.HattrickManager.Settings.Category category in user.applicationSettingsField.playerCategoryListField) {
                CheckBox box = new CheckBox();

                box.Text = " " + category.categoryNameField;
                box.Image = HM.Resources.GenericFunctions.GetCategoryImage((int)category.categoryColourField);
                box.ImageAlign = ContentAlignment.TopLeft;
                box.TextImageRelation = TextImageRelation.ImageBeforeText;
                box.TextAlign = ContentAlignment.MiddleLeft;
                box.AllowDrop = true;
                box.Name = category.categoryIdField.ToString();
                box.Dock = DockStyle.Fill;
                box.Checked = category.categoryCheckedField;
                box.DragDrop += new DragEventHandler(AddPlayerToCategory);
                box.DragEnter += new DragEventHandler(CheckAddPlayerToCategory);

                if (i == 0) {
                    box.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
                } else {
                    box.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
                }

                box.Padding = new System.Windows.Forms.Padding(0);
                box.Tag = category.categoryIdField;
                box.CheckedChanged += new EventHandler(SaveCategoryChecked);

                if (!category.categoryProtectedField) {
                    box.MouseDown += new MouseEventHandler(CategoryCheckItem_MouseDown);
                }

                tableLayoutPanelCategoriesList.Controls.Add(box, 0, i++);
                tableLayoutPanelCategoriesList.RowStyles.Add(new RowStyle(SizeType.Absolute, 22));
            }

            tableLayoutPanelCategoriesList.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        private void Setup_Resources() {
            buttonPlayerName.BackgroundImage = HM.Resources.GenericFunctions.GetResourceImage("gray_grad");
            buttonPlayerName.BackgroundImageLayout = ImageLayout.Stretch;
            buttonPlayerName.ForeColor = Color.White;

            buttonCategoryName.BackgroundImage = HM.Resources.GenericFunctions.GetResourceImage("gray_grad");
            buttonCategoryName.BackgroundImageLayout = ImageLayout.Stretch;
            buttonCategoryName.ForeColor = Color.White;
        }

        private void SetupPlayerListColumns() {
            List<HM.Entities.HattrickManager.Settings.Column> playerColumns = user.applicationSettingsField.tableColumsListField[Resources.ColumnTables.Players];
            dataGridViewPlayers.RowCount = 0;
            dataGridViewPlayers.ColumnCount = 0;
            dataGridViewPlayers.ColumnHeadersVisible = true;
            dataGridViewPlayers.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);

            dataGridViewPlayers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (HM.Entities.HattrickManager.Settings.Column playerColumn in playerColumns) {
                int colID = dataGridViewPlayers.ColumnCount;

                if (playerColumn.displayTypeField == Resources.ColumnDisplayType.Graphical) {
                    dataGridViewPlayers.Columns.Add(new DataGridViewImageColumn());
                    dataGridViewPlayers.Columns[colID].ValueType = typeof(Image);
                } else if (playerColumn.displayTypeField == Resources.ColumnDisplayType.Value) {
                    dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridViewPlayers.Columns[colID].ValueType = typeof(Int32);
                } else {
                    dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridViewPlayers.Columns[colID].ValueType = typeof(string);
                }

                dataGridViewPlayers.Columns[colID].Name = playerColumn.titleField;
                dataGridViewPlayers.Columns[colID].Visible = playerColumn.displayColumnField;
                dataGridViewPlayers.Columns[colID].Width = Convert.ToInt32(playerColumn.widthField);
                dataGridViewPlayers.Columns[colID].Tag = playerColumn.columnIDField;

                switch (playerColumn.alignmentField) {
                    case Resources.ColumnAlignment.Center:
                        dataGridViewPlayers.Columns[colID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case Resources.ColumnAlignment.Left:
                        dataGridViewPlayers.Columns[colID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case Resources.ColumnAlignment.Right:
                        dataGridViewPlayers.Columns[colID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                }
            }

            for (int i = 0; i < playerColumns.Count; i++) {
                dataGridViewPlayers.Columns[i].DisplayIndex = playerColumns[i].displayIndex;
            }
        }

        private void PopulatePlayerList() {
            HTEntities.Players.Team team = players.teamField;
            List<HM.Entities.HattrickManager.Settings.Column> playerColumns = user.applicationSettingsField.tableColumsListField[Resources.ColumnTables.Players];
            dataGridViewPlayers.RowCount = 0;
            int sortCol = -1;
            ListSortDirection sortDir = ListSortDirection.Descending;

            foreach (HTEntities.Players.Player player in team.playerListField) {
                HTEntities.Players.Player playerLastWeek = lastPlayers.teamField.playerListField.Find(lp => lp.playerIdField == player.playerIdField);
                int colNum = 0;
                int rowNum = (dataGridViewPlayers.RowCount);

                dataGridViewPlayers.RowCount++;

                foreach (HM.Entities.HattrickManager.Settings.Column playerColumn in playerColumns) {
                    HM.Resources.TableColumns columnID = (HM.Resources.TableColumns)playerColumn.columnIDField;
                    HM.Resources.Constants.TableColumn columnDefault = HM.Resources.Constants.Columns.PlayerTableColumns.Find(tc => (uint)tc.columnIDfield == playerColumn.columnIDField);

                    if (playerColumn.sortedColumnField == -1) {
                        sortCol = colNum;
                        sortDir = ListSortDirection.Descending;
                    } else if (playerColumn.sortedColumnField == 1) {
                        sortCol = colNum;
                        sortDir = ListSortDirection.Ascending;
                    }

                    if (playerColumn.displayTypeField == Resources.ColumnDisplayType.Value) {
                        dataGridViewPlayers.Rows[rowNum].Cells[colNum].Value = HM.Entities.EntityFunctions.GetPlayerValueNumber(user, player, columnID);
                    } else if (playerColumn.displayTypeField == Resources.ColumnDisplayType.Name) {
                        dataGridViewPlayers.Rows[rowNum].Cells[colNum].Value = HM.Entities.EntityFunctions.GetPlayerValueName(user, player, columnID);
                    } else if (playerColumn.displayTypeField == Resources.ColumnDisplayType.Graphical) {
                        dataGridViewPlayers.Rows[rowNum].Cells[colNum].Value = HM.Entities.EntityFunctions.GetPlayerValueImage(user, player, columnID);
                    }

                    if (columnDefault.canComparefield && playerLastWeek.playerIdField == player.playerIdField) {
                        CompareLastWeek(dataGridViewPlayers.Rows[rowNum].Cells[colNum], HM.Entities.EntityFunctions.GetPlayerValueNumber(user, player, columnID), HM.Entities.EntityFunctions.GetPlayerValueNumber(user, playerLastWeek, columnID));
                    }

                    colNum++;
                }
            }

            if (sortCol != -1) {
                dataGridViewPlayers.Sort(dataGridViewPlayers.Columns[sortCol], sortDir);
            }
        }

        private void PopulatePlayerPositions(int playerID) {
            HTEntities.Players.Player selectedPlayer = players.teamField.GetPlayer(playerID);

            labelForwardValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.Forward), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");
            labelForwardDefensiveValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.ForwardDefensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");
            labelForwardWingValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.ForwardTowardsWing), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");

            labelInnerMidValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.InnerMidfield), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");
            labelInnerMidOffensiveValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.InnerMidfieldOffensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");
            labelInnerMidDefensiveValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.InnerMidfieldDefensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");
            labelInnerMidWingValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.InnerMidfieldTowardsWing), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");

            labelWingValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.Winger), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");
            labelWingOffensiveValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.WingerOffensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");
            labelWingDefensiveValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.WingerDefensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");
            labelWingMiddleValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.WingerTowardsMiddle), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");

            labelWingDefValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.Wingback), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");
            labelWingDefOffensiveValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.WingbackOffensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");
            labelWingDefDefensiveValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.WingbackDefensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");
            labelWingDefMiddleValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.WingbackTowardsMiddle), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");

            labelCentralDefValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.Defender), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");
            labelCentralDefOffensiveValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.DefenderOffensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");
            labelCentralDefWingValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.DefenderTowardsWing), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");

            labelKeeperValue.Text = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.Keeper), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer)).ToString("F2");

            int highestPosition = 0;
            double highestValue = 0.0;

            for (int i = 2; i < tableLayoutPanelPositions.RowCount - 1; i++) {
                if (Convert.ToDouble(tableLayoutPanelPositions.GetControlFromPosition(1, i).Text) > highestValue) {
                    highestPosition = i;
                    highestValue = Convert.ToDouble(tableLayoutPanelPositions.GetControlFromPosition(1, i).Text);
                }
            }

            labelBestPosition.Text = tableLayoutPanelPositions.GetControlFromPosition(0, highestPosition).Text;
            labelBestValue.Text = highestValue.ToString("F2");

            pictureBoxBestLogo.Image = HM.Resources.GenericFunctions.GetPositionImage(labelBestPosition.Text);
        }

        private void PopulatePlayerDetails(int playerID) {
            HTEntities.Players.Player selectedPlayer = players.teamField.GetPlayer(playerID);
            double skillBonus = Convert.ToDouble(selectedPlayer.loyaltyField) / Convert.ToDouble(HM.Resources.PlayerSkill.Divine);
            int addBonus = 0;

            if (selectedPlayer.motherClubField) {
                skillBonus += 0.5;
            }

            if (checkBoxApplyBonus.Checked) {
                addBonus = Convert.ToInt32(skillBonus);
            }

            labelFormValue.Text = HM.Entities.EntityFunctions.GetPlayerFormName(selectedPlayer.playerFormField);
            labelStaminaValue.Text = HM.Entities.EntityFunctions.GetPlayerSkillName(selectedPlayer.staminaSkillField);
            labelGoalKeepingValue.Text = HM.Entities.EntityFunctions.GetPlayerSkillName(selectedPlayer.keeperSkillField, Convert.ToInt32(addBonus));
            labelDefendingValue.Text = HM.Entities.EntityFunctions.GetPlayerSkillName(selectedPlayer.defenderSkillField, Convert.ToInt32(addBonus));
            labelPlaymakingValue.Text = HM.Entities.EntityFunctions.GetPlayerSkillName(selectedPlayer.playmakerSkillField, Convert.ToInt32(addBonus));
            labelWingerValue.Text = HM.Entities.EntityFunctions.GetPlayerSkillName(selectedPlayer.wingerSkillField, Convert.ToInt32(addBonus));
            labelPassingValue.Text = HM.Entities.EntityFunctions.GetPlayerSkillName(selectedPlayer.passingSkillField, Convert.ToInt32(addBonus));
            labelScoringValue.Text = HM.Entities.EntityFunctions.GetPlayerSkillName(selectedPlayer.scorerSkillField, Convert.ToInt32(addBonus));
            labelSetPiecesValue.Text = HM.Entities.EntityFunctions.GetPlayerSkillName(selectedPlayer.setPiecesSkillField, Convert.ToInt32(addBonus));
            labelExperienceValue.Text = HM.Entities.EntityFunctions.GetPlayerSkillName(selectedPlayer.experienceField);
            labelLeadershipValue.Text = HM.Entities.EntityFunctions.GetPlayerLeadershipName(selectedPlayer.leadershipField);
            labelLoyaltyValue.Text = HM.Entities.EntityFunctions.GetPlayerSkillName(selectedPlayer.loyaltyField);
            pictureBoxMotherclub.Image = HM.Resources.GenericFunctions.GetMotherClubImage(selectedPlayer.motherClubField);
            labelSkillBonusValue.Text = skillBonus.ToString("F1");

            labelSpecialityValue.Text = selectedPlayer.specialtyField != HM.Resources.PlayerSpecialty.NoSpecialty ? HM.Resources.GenericFunctions.SplitStringOnCaps(selectedPlayer.specialtyField.ToString()) : "-";
            labelWarningsValue.Text = selectedPlayer.cardsField.ToString();
            labelHealthValue.Text = HM.Entities.EntityFunctions.GetPlayerHealthString(selectedPlayer.injuryLevelField);
            labelTSIValue.Text = selectedPlayer.tsiField.ToString();
            labelSalaryValue.Text = Core.CurrencyManager.Convert(user, selectedPlayer.salaryField);

            labelAgreeabilityValue.Text = HM.Resources.GenericFunctions.SplitStringOnCaps(selectedPlayer.agreeabilityField.ToString());
            labelHonestyValue.Text = HM.Resources.GenericFunctions.SplitStringOnCaps(selectedPlayer.honestyField.ToString());
            labelAgressivenessValue.Text = HM.Resources.GenericFunctions.SplitStringOnCaps(selectedPlayer.aggressivenessField.ToString());
        }

        private void NewPlayerSelected() {
            if (dataGridViewPlayers != null && dataGridViewPlayers.SelectedRows.Count > 0) {
                if (dataGridViewPlayers.SelectedRows[0] != null) {
                    int playerID = Convert.ToInt32(dataGridViewPlayers.SelectedRows[0].Cells[0].Value);

                    if (playerID != 0) {
                        HTEntities.Players.Player selectedPlayer = players.teamField.GetPlayer(playerID);

                        buttonPlayerName.Text = selectedPlayer.firstNameField + " " + selectedPlayer.lastNameField;

                        PopulatePlayerDetails(playerID);
                        PopulatePlayerPositions(playerID);
                    }
                }
            }
        }

        private void CompareLastWeek(DataGridViewCell cell, int thisWeek, int lastWeek) {
            if (thisWeek > lastWeek) {
                cell.Style.BackColor = Color.PaleGreen;
            } else if (thisWeek < lastWeek) {
                cell.Style.BackColor = Color.LightPink;
            }
        }

        private ContextMenuStrip BuildCategoryMenu(CheckBox RClickedBox) {
            HM.Entities.HattrickManager.Settings.Category category = user.applicationSettingsField.playerCategoryListField.Find(pc => pc.categoryIdField == Convert.ToUInt16(RClickedBox.Tag));
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.ShowImageMargin = false;
            menu.DropShadowEnabled = true;
            menu.Font = new Font("Calibri", 9, FontStyle.Regular);
            menu.Tag = RClickedBox.Tag;

            ToolStripMenuItem colours = new ToolStripMenuItem("Colour");

            colours.DropDownItems.AddRange(HM.Resources.GenericFunctions.GetCategoryImageList(category.categoryColourField));

            foreach (ToolStripMenuItem item in colours.DropDownItems) {
                item.Click += new EventHandler(ChangeCategoryColour);
            }

            menu.Items.AddRange(new ToolStripItem[] {
                new ToolStripMenuItem("New Category", null, AddNewCategory_Click),
                new ToolStripMenuItem("Delete Category", null, DeleteCategory_Click),
                new ToolStripMenuItem("Rename Category", null, RenameCategory),
                new ToolStripSeparator(),
                colours,
                new ToolStripSeparator(),
                new ToolStripMenuItem("Clear Category", null, ClearCategory_Click)
            });

            return (menu);
        }

        private void AddNewCategory() {
            string promptValue = HM.Resources.CustomClasses.TextPrompt.ShowDialog("Category Name", string.Empty, "New Category");

            if (promptValue != string.Empty) {
                HM.Entities.HattrickManager.Settings.Category newCategory = new Entities.HattrickManager.Settings.Category();

                newCategory.categoryNameField = promptValue;
                newCategory.categoryProtectedField = false;
                newCategory.categoryColourField = 2;
                newCategory.categoryIdField = user.applicationSettingsField.GetNextCategoryID();

                user.applicationSettingsField.playerCategoryListField.Add(newCategory);

                PopulateCategoryList();
            }

        }

        private void DeleteCategory(uint categoryID) {
            if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                HM.Entities.HattrickManager.Settings.Category category = user.applicationSettingsField.playerCategoryListField.Find(pc => pc.categoryIdField == categoryID);

                user.applicationSettingsField.playerCategoryListField.Remove(category);

                PopulateCategoryList();
            }

        }

        private void ClearCategory(uint categoryID) {

        }

        private void RenameCategory(uint categoryID) {
            HM.Entities.HattrickManager.Settings.Category category = user.applicationSettingsField.playerCategoryListField.Find(pc => pc.categoryIdField == categoryID);

            string promptValue = HM.Resources.CustomClasses.TextPrompt.ShowDialog("Category Name", category.categoryNameField, "Rename Category");

            if (promptValue != string.Empty) {
                category.categoryNameField = promptValue;
                PopulateCategoryList();
            }
        }

        private void ChangeCategoryColour(uint categoryID, int colourID) {
            HM.Entities.HattrickManager.Settings.Category category = user.applicationSettingsField.playerCategoryListField.Find(pc => pc.categoryIdField == categoryID);

            category.categoryColourField = colourID;
            PopulateCategoryList();
            PopulatePlayerList();
        }

        private void AddPlayerToCategory(object sender, DragEventArgs e) {
            CheckBox selectedCategory = (CheckBox)sender;
            UInt32 playerID = Convert.ToUInt32(e.Data.GetData(typeof(UInt32)));
            HTEntities.Players.Player player = players.teamField.playerListField.Find(p => p.playerIdField == playerID);

            player.hmCategoryIdField = Convert.ToUInt16(selectedCategory.Tag);

            PopulatePlayerList();

            dataManager.SavePlayerCategories(players.teamField.playerListField);
        }

        private void CheckAddPlayerToCategory(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(UInt32))) {
                e.Effect = DragDropEffects.Copy;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void SaveCategoryCheckChange(uint categoryID, bool itemChecked, TableLayoutPanel panel) {
            HM.Entities.HattrickManager.Settings.Category category = user.applicationSettingsField.playerCategoryListField.Find(pc => pc.categoryIdField == categoryID);
            category.categoryCheckedField = itemChecked;

            if (category.categoryNameField == "All") {
                for (int i = 1; i < panel.Controls.Count; i++) {
                    CheckBox box = (CheckBox)panel.Controls[i];

                    if (itemChecked) {
                        box.Checked = true;
                    } else {
                        box.Checked = false;
                    }
                }
            } else {
                if (!itemChecked) {
                    CheckBox all = (CheckBox)panel.Controls[0];

                    if (all.Checked) {
                        all.CheckedChanged -= SaveCategoryChecked;
                        all.Checked = false;
                        all.CheckedChanged += new EventHandler(SaveCategoryChecked);
                    }
                }
                
            }
        }

        private void SetPlayerListSortedColumn(DataGridViewColumn column, SortOrder direction) {
            foreach (HM.Entities.HattrickManager.Settings.Column col in user.applicationSettingsField.tableColumsListField[Resources.ColumnTables.Players]) {
                if (col.sortedColumnField != 0) {
                    col.sortedColumnField = 0;
                }

                if (col.columnIDField == Convert.ToUInt16(column.Tag)) {
                    if (direction == SortOrder.Descending) {
                        col.sortedColumnField = -1;
                    } else {
                        col.sortedColumnField = 1;
                    }
                }
            }
        }

        #endregion

        #region events

        private void AddNewCategory_Click(object sender, EventArgs e) {
            AddNewCategory();
        }

        private void DeleteCategory_Click(object sender, EventArgs e) {
            ToolStripItem item = (ToolStripItem)sender;
            DeleteCategory(Convert.ToUInt16(item.Owner.Tag));
        }

        private void ClearCategory_Click(object sender, EventArgs e) {
            ToolStripItem item = (ToolStripItem)sender;
            ClearCategory(Convert.ToUInt16(item.Owner.Tag));
        }

        private void RenameCategory(object sender, EventArgs e) {
            ToolStripItem item = (ToolStripItem)sender;
            RenameCategory(Convert.ToUInt16(item.Owner.Tag));
        }

        private void ChangeCategoryColour(object sender, EventArgs e) {
            ToolStripItem item = (ToolStripItem)sender;
            ChangeCategoryColour(Convert.ToUInt16(item.OwnerItem.Owner.Tag), Convert.ToUInt16(item.Tag));
        }

        private void SaveCategoryChecked(object sender, EventArgs e) {
            CheckBox item = (CheckBox)sender;
            SaveCategoryCheckChange(Convert.ToUInt16(item.Tag), item.Checked, (TableLayoutPanel)item.Parent);
        }

        private void dataGridViewPlayers_CellClick(object sender, DataGridViewCellEventArgs e) {
            NewPlayerSelected();
        }

        private void dataGridViewPlayers_SelectionChanged(object sender, EventArgs e) {
            NewPlayerSelected();
        }

        private void CategoryCheckItem_MouseDown(object sender, MouseEventArgs e) {
            CheckBox box = (CheckBox)sender;

            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                ContextMenuStrip menu = BuildCategoryMenu(box);

                menu.Show(this, e.Location, ToolStripDropDownDirection.Right);
            }
        }

        private void splitContainerPlayerList_Resize(object sender, EventArgs e) {
            if (splitContainerPlayerList.Width > 275) {
                splitContainerPlayerList.SplitterDistance = splitContainerPlayerList.Width - 275;
            }
        }

        private void splitContainerLeft_Resize(object sender, EventArgs e) {
            splitContainerLeft.SplitterDistance = 150;
        }

        private void checkBoxApplyBonus_CheckedChanged(object sender, EventArgs e) {
            NewPlayerSelected();
        }

        private void dataGridViewPlayers_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e) {
            if (e.Column.Tag != null && !buildingUI) {
                HM.Entities.HattrickManager.Settings.Column column = user.applicationSettingsField.tableColumsListField[Resources.ColumnTables.Players].Find(col => col.columnIDField == Convert.ToUInt16(e.Column.Tag));

                column.widthField = Convert.ToUInt16(e.Column.Width);
            }
        }

        private void dataGridViewPlayers_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e) {
            if (e.Column.Tag != null && !buildingUI) {
                HM.Entities.HattrickManager.Settings.Column column = user.applicationSettingsField.tableColumsListField[Resources.ColumnTables.Players].Find(col => col.columnIDField == Convert.ToUInt16(e.Column.Tag));

                column.displayIndex = Convert.ToInt32(e.Column.DisplayIndex);
            }
        }

        private void dataGridViewPlayers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex >= 0) {
                uint playerID = Convert.ToUInt32(dataGridViewPlayers.Rows[e.RowIndex].Cells[0].Value);

                dataGridViewPlayers.DoDragDrop(playerID, DragDropEffects.Copy);
            }
        }

        private void dataGridViewPlayers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            DataGridView item = (DataGridView)sender;

            SetPlayerListSortedColumn(item.SortedColumn, item.SortOrder);
        }

        #endregion
    }
}