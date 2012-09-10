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
                PopulatePlayerList();
            }
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
            HTEntities.WorldDetails.WorldDetails world = entityManager.GetWorldDetails();
            HTEntities.Players.Team team = players.teamField;

            dataGridViewPlayers.RowCount = 0;
            dataGridViewPlayers.ColumnCount = 0;
            dataGridViewPlayers.ColumnHeadersVisible = true;
            dataGridViewPlayers.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);

            dataGridViewPlayers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.PlayerID;
            dataGridViewPlayers.Columns[Columns.PlayerID].ValueType = typeof(Int32);
            dataGridViewPlayers.Columns[Columns.PlayerID].Visible = false;

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.PlayerNumber;
            dataGridViewPlayers.Columns[Columns.PlayerNumber].ValueType = typeof(Int32);

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.PlayerName;
            dataGridViewPlayers.Columns[Columns.PlayerName].ValueType = typeof(string);
            dataGridViewPlayers.Columns[Columns.PlayerName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewPlayers.Columns.Add(new DataGridViewImageColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.PlayerFlag;
            dataGridViewPlayers.Columns[Columns.PlayerFlag].ValueType = typeof(Image);

            dataGridViewPlayers.Columns.Add(new DataGridViewImageColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.LastPosition;
            dataGridViewPlayers.Columns[Columns.LastPosition].ValueType = typeof(Image);

            dataGridViewPlayers.Columns.Add(new DataGridViewImageColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.Health;
            dataGridViewPlayers.Columns[Columns.Health].ValueType = typeof(Image);

            dataGridViewPlayers.Columns.Add(new DataGridViewImageColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.Warnings;
            dataGridViewPlayers.Columns[Columns.Warnings].ValueType = typeof(Image);

            dataGridViewPlayers.Columns.Add(new DataGridViewImageColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.Category;
            dataGridViewPlayers.Columns[Columns.Category].ValueType = typeof(Image);

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.Age;
            dataGridViewPlayers.Columns[Columns.Age].ValueType = typeof(string);

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.TSI;
            dataGridViewPlayers.Columns[Columns.TSI].ValueType = typeof(Int32);

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.Form;
            dataGridViewPlayers.Columns[Columns.Form].ValueType = typeof(Int32);

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.Stamina;
            dataGridViewPlayers.Columns[Columns.Stamina].ValueType = typeof(Int32);

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.Goalkeeping;
            dataGridViewPlayers.Columns[Columns.Goalkeeping].ValueType = typeof(Int32);

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.Defending;
            dataGridViewPlayers.Columns[Columns.Defending].ValueType = typeof(Int32);

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.Winger;
            dataGridViewPlayers.Columns[Columns.Winger].ValueType = typeof(Int32);

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.Playmaking;
            dataGridViewPlayers.Columns[Columns.Playmaking].ValueType = typeof(Int32);

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.Passing;
            dataGridViewPlayers.Columns[Columns.Passing].ValueType = typeof(Int32);

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.Scoring;
            dataGridViewPlayers.Columns[Columns.Scoring].ValueType = typeof(Int32);

            dataGridViewPlayers.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewPlayers.Columns[dataGridViewPlayers.ColumnCount - 1].Name = Columns.SetPieces;
            dataGridViewPlayers.Columns[Columns.SetPieces].ValueType = typeof(Int32);

            foreach (HTEntities.Players.Player player in team.playerListField) {
                HTEntities.Players.Player lastPlayer = new HTEntities.Players.Player();

                foreach (HTEntities.Players.Player p in lastPlayers.teamField.playerListField) {
                    if (p.playerIdField == player.playerIdField) {
                        lastPlayer = p;
                        break;
                    }
                }
                int rowNum = (dataGridViewPlayers.RowCount);
                dataGridViewPlayers.RowCount++;

                dataGridViewPlayers.Rows[rowNum].Cells[Columns.PlayerID].Value = player.playerIdField;

                dataGridViewPlayers.Rows[rowNum].Cells[Columns.PlayerNumber].Value = player.playerNumberField;
                dataGridViewPlayers.Rows[rowNum].Cells[Columns.PlayerName].Value = player.getFullName();
                dataGridViewPlayers.Rows[rowNum].Cells[Columns.PlayerFlag].Value = HM.Resources.GenericFunctions.GetFlagByLeagueId(world.GetLeagueIDFromCountryID(player.countryIdField));
                dataGridViewPlayers.Rows[rowNum].Cells[Columns.LastPosition].Value = HM.Resources.GenericFunctions.GetPositionImage(player.lastMatchField.roleField);
                dataGridViewPlayers.Rows[rowNum].Cells[Columns.Health].Value = HM.Resources.GenericFunctions.GetInjuriesImage(player.injuryLevelField);
                dataGridViewPlayers.Rows[rowNum].Cells[Columns.Warnings].Value = HM.Resources.GenericFunctions.GetCardImage(player.cardsField);
                dataGridViewPlayers.Rows[rowNum].Cells[Columns.Category].Value = HM.Resources.GenericFunctions.GetCategoryImage(1);

                dataGridViewPlayers.Rows[rowNum].Cells[Columns.Age].Value = player.getFullAge();

                dataGridViewPlayers.Rows[rowNum].Cells[Columns.TSI].Value = player.tsiField;

                if (player.tsiField < lastPlayer.tsiField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.TSI].Style.BackColor = Color.LightPink;
                } else if (player.tsiField > lastPlayer.tsiField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.TSI].Style.BackColor = Color.PaleGreen;
                }

                dataGridViewPlayers.Rows[rowNum].Cells[Columns.Form].Value = (int)player.playerFormField;

                if (player.playerFormField < lastPlayer.playerFormField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Form].Style.BackColor = Color.LightPink;
                } else if (player.playerFormField > lastPlayer.playerFormField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Form].Style.BackColor = Color.PaleGreen;
                }

                dataGridViewPlayers.Rows[rowNum].Cells[Columns.Stamina].Value = (int)player.staminaSkillField;

                if (player.staminaSkillField < lastPlayer.staminaSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Stamina].Style.BackColor = Color.LightPink;
                } else if (player.staminaSkillField > lastPlayer.staminaSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Stamina].Style.BackColor = Color.PaleGreen;
                }

                dataGridViewPlayers.Rows[rowNum].Cells[Columns.Goalkeeping].Value = (int)player.keeperSkillField;

                if (player.keeperSkillField < lastPlayer.keeperSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Goalkeeping].Style.BackColor = Color.LightPink;
                } else if (player.keeperSkillField > lastPlayer.keeperSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Goalkeeping].Style.BackColor = Color.PaleGreen;
                }

                dataGridViewPlayers.Rows[rowNum].Cells[Columns.Defending].Value = (int)player.defenderSkillField;

                if (player.defenderSkillField < lastPlayer.defenderSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Defending].Style.BackColor = Color.LightPink;
                } else if (player.defenderSkillField > lastPlayer.defenderSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Defending].Style.BackColor = Color.PaleGreen;
                }

                dataGridViewPlayers.Rows[rowNum].Cells[Columns.Winger].Value = (int)player.wingerSkillField;

                if (player.wingerSkillField < lastPlayer.wingerSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Winger].Style.BackColor = Color.LightPink;
                } else if (player.wingerSkillField > lastPlayer.wingerSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Winger].Style.BackColor = Color.PaleGreen;
                }

                dataGridViewPlayers.Rows[rowNum].Cells[Columns.Playmaking].Value = (int)player.playmakerSkillField;

                if (player.playmakerSkillField < lastPlayer.playmakerSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Playmaking].Style.BackColor = Color.LightPink;
                } else if (player.playmakerSkillField > lastPlayer.playmakerSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Playmaking].Style.BackColor = Color.PaleGreen;
                }

                dataGridViewPlayers.Rows[rowNum].Cells[Columns.Passing].Value = (int)player.passingSkillField;

                if (player.passingSkillField < lastPlayer.passingSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Passing].Style.BackColor = Color.LightPink;
                } else if (player.passingSkillField > lastPlayer.passingSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Passing].Style.BackColor = Color.PaleGreen;
                }

                dataGridViewPlayers.Rows[rowNum].Cells[Columns.Scoring].Value = (int)player.scorerSkillField;

                if (player.scorerSkillField < lastPlayer.scorerSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Scoring].Style.BackColor = Color.LightPink;
                } else if (player.scorerSkillField > lastPlayer.scorerSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.Scoring].Style.BackColor = Color.PaleGreen;
                }

                dataGridViewPlayers.Rows[rowNum].Cells[Columns.SetPieces].Value = (int)player.setPiecesSkillField;

                if (player.setPiecesSkillField < lastPlayer.setPiecesSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.SetPieces].Style.BackColor = Color.LightPink;
                } else if (player.setPiecesSkillField > lastPlayer.setPiecesSkillField) {
                    dataGridViewPlayers.Rows[rowNum].Cells[Columns.SetPieces].Style.BackColor = Color.PaleGreen;
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

        #endregion

        #region events

        private void dataGridViewPlayers_CellClick(object sender, DataGridViewCellEventArgs e) {
            NewPlayerSelected();
        }

        private void dataGridViewPlayers_SelectionChanged(object sender, EventArgs e) {
            NewPlayerSelected();
        }

        private void checkedListBoxCategories_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
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

        #endregion
    }
}