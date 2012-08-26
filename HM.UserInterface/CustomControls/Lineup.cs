using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HTEntities = HM.Entities.Hattrick;
using HM.Resources.Constants;
using HM.Entities.HattrickManager.UserProfiles;

namespace HM.UserInterface.CustomControls {
    public partial class Lineup : UserControl {
        #region Properties

        private HTEntities.Players.Players players;
        private User user;

        #endregion

        public Lineup(HTEntities.Players.Players players, User user) {
            InitializeComponent();

            this.players = players;
            this.user = user;


        }

        private void Lineup_Load(object sender, EventArgs e) {

            LoadControls();
        }

        private void LoadControls() {
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
                newDataRow[Columns.PlayerFlag] = null; //HM.Resources.GenericFunctions.GetFlagByLeagueId(player.countryIdField);
                newDataRow[Columns.LastPosition] = HM.Resources.GenericFunctions.GetPositionImage(player.lastMatchField.roleField);
                newDataRow[Columns.Health] = HM.Resources.GenericFunctions.GetInjuriesImage(player.injuryLevelField);
                newDataRow[Columns.Warnings] = HM.Resources.GenericFunctions.GetCardImage(player.cardsField);
                newDataRow[Columns.Category] = null;
                newDataRow[Columns.Age] = player.ageField.ToString();
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
        }
    }
}
