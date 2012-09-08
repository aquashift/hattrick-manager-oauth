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
        private User user;
        private EntityManager entityManager;

        #endregion

        public PlayerList(User user) {
            InitializeComponent();

            this.user = user;

            if (user != null) {
                this.entityManager = new EntityManager(user);
                this.players = entityManager.GetPlayersDetails();
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

            DataTable lineupDataTable = new DataTable();

            lineupDataTable.Columns.Add(Columns.PlayerID, typeof(Int32));
            lineupDataTable.Columns.Add(Columns.PlayerNumber, typeof(byte));
            lineupDataTable.Columns.Add(Columns.PlayerName, typeof(string));
            lineupDataTable.Columns.Add(Columns.PlayerFlag, typeof(Image));
            lineupDataTable.Columns.Add(Columns.LastPosition, typeof(Image));
            lineupDataTable.Columns.Add(Columns.Health, typeof(Image));
            lineupDataTable.Columns.Add(Columns.Warnings, typeof(Image));
            lineupDataTable.Columns.Add(Columns.Category, typeof(Image));
            lineupDataTable.Columns.Add(Columns.Age, typeof(string));
            lineupDataTable.Columns.Add(Columns.TSI, typeof(Int32));
            lineupDataTable.Columns.Add(Columns.Form, typeof(byte));
            lineupDataTable.Columns.Add(Columns.Stamina, typeof(byte));
            lineupDataTable.Columns.Add(Columns.Goalkeeping, typeof(byte));
            lineupDataTable.Columns.Add(Columns.Defending, typeof(byte));
            lineupDataTable.Columns.Add(Columns.Winger, typeof(byte));
            lineupDataTable.Columns.Add(Columns.Playmaking, typeof(byte));
            lineupDataTable.Columns.Add(Columns.Passing, typeof(byte));
            lineupDataTable.Columns.Add(Columns.Scoring, typeof(byte));
            lineupDataTable.Columns.Add(Columns.SetPieces, typeof(byte));

            foreach (HTEntities.Players.Player player in team.playerListField) {
                DataRow newDataRow = lineupDataTable.NewRow();

                newDataRow[Columns.PlayerID] = player.playerIdField;
                newDataRow[Columns.PlayerNumber] = player.playerNumberField;
                newDataRow[Columns.PlayerName] = player.getFullName();
                newDataRow[Columns.PlayerFlag] = HM.Resources.GenericFunctions.GetFlagByLeagueId(world.GetLeagueIDFromCountryID(player.countryIdField));
                newDataRow[Columns.LastPosition] = HM.Resources.GenericFunctions.GetPositionImage(player.lastMatchField.roleField);
                newDataRow[Columns.Health] = HM.Resources.GenericFunctions.GetInjuriesImage(player.injuryLevelField);
                newDataRow[Columns.Warnings] = HM.Resources.GenericFunctions.GetCardImage(player.cardsField);
                newDataRow[Columns.Category] = HM.Resources.GenericFunctions.GetCategoryImage(7);
                newDataRow[Columns.Age] = player.getFullAge();
                newDataRow[Columns.TSI] = player.tsiField.ToString();
                newDataRow[Columns.Form] = player.playerFormField;
                newDataRow[Columns.Stamina] = player.staminaSkillField;
                newDataRow[Columns.Goalkeeping] = player.keeperSkillField;
                newDataRow[Columns.Defending] = player.defenderSkillField;
                newDataRow[Columns.Winger] = player.wingerSkillField;
                newDataRow[Columns.Playmaking] = player.playmakerSkillField;
                newDataRow[Columns.Passing] = player.passingSkillField;
                newDataRow[Columns.Scoring] = player.scorerSkillField;
                newDataRow[Columns.SetPieces] = player.setPiecesSkillField;

                lineupDataTable.Rows.Add(newDataRow);
            }

            dataGridViewPlayers.DataSource = lineupDataTable;

            dataGridViewPlayers.Columns[Columns.PlayerID].Visible = false;
            dataGridViewPlayers.Columns[Columns.PlayerName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void PopulatePlayerPositions(int playerID) {
            /*
            HTEntities.Players.Player selectedPlayer = players.teamField.GetPlayer(playerID);
            double positionValue = 0;

            DataTable detailsDataTable = new DataTable();

            detailsDataTable.Columns.Add("Type", typeof(string));
            detailsDataTable.Columns.Add("Value", typeof(double));

            DataRow newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.Keeper), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Goalkeeper";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.Defender), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Defender";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.DefenderTowardsWing), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Defender Towards Wing";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.DefenderOffensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Offensive Defender";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.WingBack), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Wingback";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.WingBackTowardsMiddle), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Wingback Towards Middle";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.WingBackOffensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Offensive Wingback";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.Winger), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Winger";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.WingerDefensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Defensive Winger";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.WingerTowardsMiddle), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Winger Towards Middle";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.WingerOffensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Offensive Winger";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.InnerMidfield), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Inner Midfield";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.InnerMidfieldDefensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Defensive Midfield";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.InnerMidfieldTowardsWing), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Inner Midfield Towards Wing";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.InnerMidfieldOffensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Offensive Inner Midfield";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.Forward), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Forward";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.ForwardDefensive), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Defensive Forward";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            positionValue = HM.Entities.EntityFunctions.GetPlayerPositionRating(user.applicationSettingsField.GetPositionWeights(Resources.FieldPositionCode.ForwardTowardsWing), HM.Entities.EntityFunctions.GetPlayerSkills(selectedPlayer));
            newDataRow["Type"] = "Forward Towards Wing";
            newDataRow["Value"] = positionValue.ToString("F1");
            detailsDataTable.Rows.Add(newDataRow);

            detailsDataTable.DefaultView.Sort = "Value DESC";

            dataGridViewPlayerPositions.DataSource = detailsDataTable;

            try {
                dataGridViewPlayerPositions.Columns[0].MinimumWidth = 200;
            } catch (Exception e) {
            }

            dataGridViewPlayerPositions.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewPlayerPositions.Rows[0].DefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Bold);
            dataGridViewPlayerPositions.ClearSelection();
            */
        }

        private void PopulatePlayerDetails(int playerID) {
            HTEntities.Players.Player selectedPlayer = players.teamField.GetPlayer(playerID);
            double skillBonus = ((Convert.ToDouble(selectedPlayer.loyaltyField) / Convert.ToDouble(HM.Resources.PlayerSkill.Divine)) + Convert.ToInt32(selectedPlayer.motherClubField));
            int addBonus = 0;

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

                    HTEntities.Players.Player selectedPlayer = players.teamField.GetPlayer(playerID);
                    buttonPlayerName.Text = selectedPlayer.firstNameField + " " + selectedPlayer.lastNameField;

                    PopulatePlayerDetails(playerID);
                    PopulatePlayerPositions(playerID);
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
            splitContainerPlayerList.SplitterDistance = splitContainerPlayerList.Width - 275;
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