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

            LoadControls();
        }

        private void LoadControls() {
            HTEntities.Players.Team team = players.teamField;

            DataTable lineupDataTable = new DataTable();

            lineupDataTable.Columns.Add(Columns.PlayerID, typeof(Int32));
            lineupDataTable.Columns.Add(Columns.PlayerNumber, typeof(byte));
            lineupDataTable.Columns.Add(Columns.PlayerName, typeof(string));
            lineupDataTable.Columns.Add(Columns.PlayerFlag, typeof(Image)); 
            lineupDataTable.Columns.Add(Columns.LastPosition, typeof(string));
            lineupDataTable.Columns.Add(Columns.BestPosition, typeof(string));
            lineupDataTable.Columns.Add(Columns.Age, typeof(string));
            lineupDataTable.Columns.Add(Columns.Form, typeof(byte));
            lineupDataTable.Columns.Add(Columns.Stamina, typeof(byte));

            foreach (HTEntities.Players.Player player in team.playerListField) {
                DataRow newDataRow = lineupDataTable.NewRow();

                newDataRow[Columns.PlayerID] = player.playerIdField;
                newDataRow[Columns.PlayerNumber] = player.playerNumberField;
                newDataRow[Columns.PlayerName] = player.firstNameField + " " + player.lastNameField;
                newDataRow[Columns.PlayerFlag] = HM.Resources.GenericFunctions.GetFlagByLeagueId(player.countryIdField);
                newDataRow[Columns.LastPosition] = "";
                newDataRow[Columns.BestPosition] = "";
                newDataRow[Columns.Age] = player.ageField.ToString();
                newDataRow[Columns.Form] = player.playerFormField;
                newDataRow[Columns.Stamina] = player.staminaSkillField;

                lineupDataTable.Rows.Add(newDataRow);
            }

            dataGridViewPlayers.DataSource = lineupDataTable;
        }
    }
}
