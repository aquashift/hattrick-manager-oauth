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
            this.entityManager = new EntityManager(user);
            this.players = entityManager.GetPlayersDetails();
        }

        public PlayerList() {
            InitializeComponent();
        }

        #region Methods

        private void Lineup_Load(object sender, EventArgs e) {

            buttonPlayerName.BackgroundImage = HM.Resources.GenericFunctions.GetResourceImage("gray_grad");
            buttonPlayerName.BackgroundImageLayout = ImageLayout.Stretch;
            buttonPlayerName.ForeColor = Color.White;

            if (players != null) {
                PopulatePlayerList();
            }
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
                newDataRow[Columns.PlayerName] = player.firstNameField + " " + player.lastNameField;
                newDataRow[Columns.PlayerFlag] = HM.Resources.GenericFunctions.GetFlagByLeagueId(world.GetLeagueIDFromCountryID(player.countryIdField));
                newDataRow[Columns.LastPosition] = HM.Resources.GenericFunctions.GetPositionImage(player.lastMatchField.roleField);
                newDataRow[Columns.Health] = HM.Resources.GenericFunctions.GetInjuriesImage(player.injuryLevelField);
                newDataRow[Columns.Warnings] = HM.Resources.GenericFunctions.GetCardImage(player.cardsField);
                newDataRow[Columns.Category] = null;
                newDataRow[Columns.Age] = player.ageField.ToString() + "." + player.ageDaysField.ToString();
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

        private void PopulatePlayerDetails(int playerID) {
            HTEntities.Players.Player selectedPlayer = players.teamField.GetPlayer(playerID);

            buttonPlayerName.Text = selectedPlayer.firstNameField + " " + selectedPlayer.lastNameField;

            DataTable detailsDataTable = new DataTable();

            detailsDataTable.Columns.Add("Type", typeof(string));
            detailsDataTable.Columns.Add("Value", typeof(string));

            DataRow newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Speciality";
            newDataRow["Value"] = selectedPlayer.specialtyField;
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Experience";
            newDataRow["Value"] = selectedPlayer.experienceField;
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Leadership";
            newDataRow["Value"] =  selectedPlayer.leadershipField;
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Agreeability";
            newDataRow["Value"] = selectedPlayer.agreeabilityField;
            detailsDataTable.Rows.Add(newDataRow);
            
            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Aggressiveness";
            newDataRow["Value"] = selectedPlayer.aggressivenessField;
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "";
            newDataRow["Value"] = "";
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "TSI";
            newDataRow["Value"] = selectedPlayer.tsiField;
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Form";
            newDataRow["Value"] = selectedPlayer.playerFormField;
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Stamina";
            newDataRow["Value"] = selectedPlayer.staminaSkillField;
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "";
            newDataRow["Value"] = "";

            detailsDataTable.Rows.Add(newDataRow);
            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Goalkeeping";
            newDataRow["Value"] = selectedPlayer.keeperSkillField;
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Defending";
            newDataRow["Value"] = selectedPlayer.defenderSkillField;
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Winger";
            newDataRow["Value"] = selectedPlayer.wingerSkillField;
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Playmaking";
            newDataRow["Value"] = selectedPlayer.playmakerSkillField;
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Passing";
            newDataRow["Value"] = selectedPlayer.passingSkillField;
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Scoring";
            newDataRow["Value"] = selectedPlayer.scorerSkillField;
            detailsDataTable.Rows.Add(newDataRow);

            newDataRow = detailsDataTable.NewRow();
            newDataRow["Type"] = "Set Pieces";
            newDataRow["Value"] = selectedPlayer.setPiecesSkillField;
            detailsDataTable.Rows.Add(newDataRow);

            dataGridViewPlayerSkills.DataSource = detailsDataTable;

            //dataGridViewPlayerSkills.Columns[0].DefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
            dataGridViewPlayerSkills.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        #endregion

        #region events

        private void dataGridViewPlayers_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (dataGridViewPlayers.SelectedRows[0] != null) {
                int playerID = Convert.ToInt32(dataGridViewPlayers.SelectedRows[0].Cells[0].Value);

                PopulatePlayerDetails(playerID);
            }
        }

        #endregion
    }
}
