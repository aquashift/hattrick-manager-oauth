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
                PopulatePlayerList();
                PopulateCategoryList();
                buildingUI = false;
            }
        }

        private void PopulateCategoryList() {
            int i = 0;

            tableLayoutPanelCategoriesList.RowCount = user.applicationSettingsField.playerCategoryListField.Count + 1;
            tableLayoutPanelCategoriesList.RowStyles.Clear();

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
                box.MouseDown += new MouseEventHandler(CategoryCheckItem_MouseDown);
                box.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
                box.Padding = new System.Windows.Forms.Padding(0);

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

        private void PopulatePlayerList() {
            HTEntities.Players.Team team = players.teamField;
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

            foreach (HTEntities.Players.Player player in team.playerListField) {
                HTEntities.Players.Player lastPlayer = new HTEntities.Players.Player();

                foreach (HTEntities.Players.Player p in lastPlayers.teamField.playerListField) {
                    if (p.playerIdField == player.playerIdField) {
                        lastPlayer = p;
                        break;
                    }
                }

                int colNum = 0;
                int rowNum = (dataGridViewPlayers.RowCount);
                dataGridViewPlayers.RowCount++;

                foreach (HM.Entities.HattrickManager.Settings.Column playerColumn in playerColumns) {
                    HM.Resources.TableColumns columnID = (HM.Resources.TableColumns)playerColumn.columnIDField;

                    if (playerColumn.displayTypeField == Resources.ColumnDisplayType.Value) {
                        dataGridViewPlayers.Rows[rowNum].Cells[colNum].Value = HM.Entities.EntityFunctions.GetPlayerValueNumber(player, columnID);
                        CompareLastWeek(dataGridViewPlayers.Rows[rowNum].Cells[colNum], HM.Entities.EntityFunctions.GetPlayerValueNumber(player, columnID), HM.Entities.EntityFunctions.GetPlayerValueNumber(lastPlayer, columnID));
                    } else if (playerColumn.displayTypeField == Resources.ColumnDisplayType.Name) {
                        dataGridViewPlayers.Rows[rowNum].Cells[colNum].Value = HM.Entities.EntityFunctions.GetPlayerValueName(player, columnID);
                    } else if (playerColumn.displayTypeField == Resources.ColumnDisplayType.Graphical) {
                        dataGridViewPlayers.Rows[rowNum].Cells[colNum].Value = HM.Entities.EntityFunctions.GetPlayerValueImage(player, columnID);
                    }

                    colNum++;
                }
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

        private ContextMenuStrip BuildCategoryMenu() {
            ContextMenuStrip menu = new ContextMenuStrip();

            return (menu);
        }

        #endregion

        #region events

        private void dataGridViewPlayers_CellClick(object sender, DataGridViewCellEventArgs e) {
            NewPlayerSelected();
        }

        private void dataGridViewPlayers_SelectionChanged(object sender, EventArgs e) {
            NewPlayerSelected();
        }

        private void CategoryCheckItem_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                ContextMenuStrip menu = BuildCategoryMenu();

                MenuItem[] menuItems = new MenuItem[] { new MenuItem("New Category"), new MenuItem("Delete Category"), new MenuItem("Rename Category"), new MenuItem("Colour")};

                ContextMenu buttonMenu = new ContextMenu(menuItems);

                buttonMenu.Show(this, e.Location, LeftRightAlignment.Right);
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
                List<HM.Entities.HattrickManager.Settings.Column> columns = user.applicationSettingsField.tableColumsListField[Resources.ColumnTables.Players];

                for (int i = 0; i < columns.Count; i++) {
                    if (columns[i].columnIDField == Convert.ToUInt16(e.Column.Tag)) {
                        columns[i].widthField = Convert.ToUInt16(e.Column.Width);
                        break;
                    }
                }
            }
        }

        private void dataGridViewPlayers_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e) {
            if (e.Column.Tag != null && !buildingUI) {
                List<HM.Entities.HattrickManager.Settings.Column> columns = user.applicationSettingsField.tableColumsListField[Resources.ColumnTables.Players];

                for (int i = 0; i < columns.Count; i++) {
                    if (columns[i].columnIDField == Convert.ToUInt16(e.Column.Tag)) {
                        columns[i].displayIndex = Convert.ToInt32(e.Column.DisplayIndex);
                        break;
                    }
                }
            }
        }

        #endregion
    }
}