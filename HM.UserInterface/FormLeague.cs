using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HMEntities = HM.Entities.HattrickManager;
using HTEntities = HM.Entities.Hattrick;
using HM.Resources.Constants;
using HM.Resources;

namespace HM.UserInterface
{
    public partial class FormLeague : FormBase
    {
        #region Properties

        private HTEntities.LeagueDetails.LeagueDetails leagueDetails;
        private HTEntities.LeagueFixtures.LeagueFixtures leagueFixtures;
        private uint teamId;

        #endregion

        #region Constants

        private const string columnPositionName = "columnPosition";
        private const string columnChangeName = "columnChange";
        private const string columnTeamName = "columnTeam";
        private const string columnMatchesName = "columnMatches";
        private const string columnWonName = "columnWon";
        private const string columnDrawName = "columnDraw";
        private const string columnLostName = "columnLost";
        private const string columnGoalsForName = "columnGoalsFor";
        private const string columnGoalsAgainstName = "columnGoalsAgainst";
        private const string columnGoalDifferenceName = "columnGoalDifference";
        private const string columnPointsName = "columnPoints";
        private const string columnRoundName = "columnRound";
        private const string columnDateName = "columnDate";
        private const string columnHomeResultName = "columnHomeResult";
        private const string columnHomeTeamName = "columnHomeTeam";
        private const string columnScoreName = "columnScore";
        private const string columnAwayTeamName = "columnAwayTeam";
        private const string columnAwayResultName = "columnAwayResult";
        private const string columnTeamIDName = "columnTeamID";
        private const string columnAwayTeamIDName = "columnAwayTeamID";
        private const string columnHomeTeamIDName = "columnHomeTeamID";

        #endregion

        #region Control events

        public FormLeague(HTEntities.LeagueDetails.LeagueDetails leagueDetails, HTEntities.LeagueFixtures.LeagueFixtures leagueFixtures, uint teamId)
        {
            this.teamId = teamId;
            this.leagueDetails = leagueDetails;
            this.leagueFixtures = leagueFixtures;
            InitializeComponent();
            this.dataGridViewPositions.Columns[columnPositionName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPositions.Columns[columnChangeName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPositions.Columns[columnTeamName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewPositions.Columns[columnMatchesName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPositions.Columns[columnWonName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPositions.Columns[columnDrawName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPositions.Columns[columnLostName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPositions.Columns[columnGoalsForName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPositions.Columns[columnGoalsAgainstName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPositions.Columns[columnGoalDifferenceName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPositions.Columns[columnPointsName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewFixtures.Columns[columnRoundName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewFixtures.Columns[columnDateName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewFixtures.Columns[columnHomeResultName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewFixtures.Columns[columnHomeTeamName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewFixtures.Columns[columnScoreName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewFixtures.Columns[columnAwayTeamName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewFixtures.Columns[columnAwayResultName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            LoadControls();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewPositions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int index = dataGridViewPositions.Columns[columnTeamIDName].Index;

            foreach (DataGridViewRow row in dataGridViewPositions.Rows)
            {
                if (Convert.ToUInt32(row.Cells[index].Value) == teamId)
                {
                    row.DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, (float)8.25, FontStyle.Bold);
                    break;
                }
            }
        }

        private void dataGridViewFixtures_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int indexAwayTeamID = dataGridViewFixtures.Columns[columnAwayTeamIDName].Index;
            int indexHomeTeamID = dataGridViewFixtures.Columns[columnHomeTeamIDName].Index;
            int indexHomeTeam = dataGridViewFixtures.Columns[columnHomeTeamName].Index;
            int indexAwayTeam = dataGridViewFixtures.Columns[columnAwayTeamName].Index;

            foreach (DataGridViewRow row in dataGridViewFixtures.Rows)
            {
                if (Convert.ToUInt32(row.Cells[indexHomeTeamID].Value) == teamId)
                {
                    row.Cells[indexHomeTeam].Style.Font = new Font(FontFamily.GenericSansSerif, (float)8.25, FontStyle.Bold);
                }
                if (Convert.ToUInt32(row.Cells[indexAwayTeamID].Value) == teamId)
                {
                    row.Cells[indexAwayTeam].Style.Font = new Font(FontFamily.GenericSansSerif, (float)8.25, FontStyle.Bold);
                }
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (((DataGridView)sender).SelectedCells.Count > 0)
            {
                ((DataGridView)sender).ClearSelection();
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Fills the form's controls with the selected language
        /// </summary>
        protected override void PopulateLanguage()
        {
            this.buttonClose.Text = resourceManager.GetString(Localization.ui_league_buttonClose);
            this.dataGridViewPositions.Columns[columnChangeName].HeaderText = string.Empty;
            this.dataGridViewPositions.Columns[columnDrawName].HeaderText = resourceManager.GetString(Localization.ui_league_columnDraw);
            this.dataGridViewPositions.Columns[columnGoalDifferenceName].HeaderText = resourceManager.GetString(Localization.ui_league_columnGoalDifference);
            this.dataGridViewPositions.Columns[columnGoalsAgainstName].HeaderText = resourceManager.GetString(Localization.ui_league_columnGoalsAgainst);
            this.dataGridViewPositions.Columns[columnGoalsForName].HeaderText = resourceManager.GetString(Localization.ui_league_columnGoalsFor);
            this.dataGridViewPositions.Columns[columnLostName].HeaderText = resourceManager.GetString(Localization.ui_league_columnLost);
            this.dataGridViewPositions.Columns[columnMatchesName].HeaderText = resourceManager.GetString(Localization.ui_league_columnMatches);
            this.dataGridViewPositions.Columns[columnPointsName].HeaderText = resourceManager.GetString(Localization.ui_league_columnPoints);
            this.dataGridViewPositions.Columns[columnPositionName].HeaderText = string.Empty;
            this.dataGridViewPositions.Columns[columnTeamName].HeaderText = resourceManager.GetString(Localization.ui_league_columnTeam);
            this.dataGridViewPositions.Columns[columnWonName].HeaderText = resourceManager.GetString(Localization.ui_league_columnWon);
            this.dataGridViewFixtures.Columns[columnRoundName].HeaderText = resourceManager.GetString(Localization.ui_league_columnRound);
            this.dataGridViewFixtures.Columns[columnDateName].HeaderText = resourceManager.GetString(Localization.ui_league_columnDate);
            this.dataGridViewFixtures.Columns[columnHomeResultName].HeaderText = string.Empty;
            this.dataGridViewFixtures.Columns[columnHomeTeamName].HeaderText = resourceManager.GetString(Localization.ui_league_columnHomeTeam);
            this.dataGridViewFixtures.Columns[columnScoreName].HeaderText = resourceManager.GetString(Localization.ui_league_columnScore);
            this.dataGridViewFixtures.Columns[columnAwayTeamName].HeaderText = resourceManager.GetString(Localization.ui_league_columnAwayTeam);
            this.dataGridViewFixtures.Columns[columnAwayResultName].HeaderText = string.Empty;
            this.Text = resourceManager.GetString(Localization.ui_league_FormText);
            this.labelLevel.Text = resourceManager.GetString(Localization.ui_league_labelLevel);
            this.labelRound.Text = resourceManager.GetString(Localization.ui_league_labelRound);
            this.labelSeries.Text = resourceManager.GetString(Localization.ui_league_labelSeries);
            this.tabPageLeagueDetails.Text = resourceManager.GetString(Localization.ui_league_tabPageLeagueDetails);
            this.tabPageLeagueFixtures.Text = resourceManager.GetString(Localization.ui_league_tabPageLeagueFixtures);
        }

        #endregion

        #region Private methods

        private void LoadControls()
        {
            this.labelLevelValue.Text = string.Format(resourceManager.GetString(Localization.ui_league_labelLevelValue), leagueDetails.leagueLevelField, leagueDetails.maxLevelField);
            this.labelRoundValue.Text = string.Format(resourceManager.GetString(Localization.ui_league_labelRoundValue), leagueDetails.matchRoundField, leagueFixtures.seasonField);
            this.labelSeriesValue.Text = string.Format(resourceManager.GetString(Localization.ui_league_labelSeriesValue), leagueDetails.leagueLevelUnitNameField, leagueDetails.leagueLevelUnitIdField);
            LoadDetailsGrid();
            LoadFixturesGrid();
        }

        private void LoadDetailsGrid()
        {
            DataTable detailsDataTable = new DataTable();
            detailsDataTable.Columns.Add(Columns.Position, typeof(byte));
            detailsDataTable.Columns.Add(Columns.PositionChange, typeof(Image));
            detailsDataTable.Columns.Add(Columns.TeamName, typeof(string));
            detailsDataTable.Columns.Add(Columns.Matches, typeof(byte));
            detailsDataTable.Columns.Add(Columns.Won, typeof(byte));
            detailsDataTable.Columns.Add(Columns.Draw, typeof(byte));
            detailsDataTable.Columns.Add(Columns.Lost, typeof(byte));
            detailsDataTable.Columns.Add(Columns.GoalsFor, typeof(int));
            detailsDataTable.Columns.Add(Columns.GoalsAgainst, typeof(int));
            detailsDataTable.Columns.Add(Columns.GoalDifference, typeof(int));
            detailsDataTable.Columns.Add(Columns.Points, typeof(byte));
            detailsDataTable.Columns.Add(Columns.TeamID, typeof(uint));

            foreach (HTEntities.LeagueDetails.Team team in leagueDetails.teamField)
            {
                DataRow newDataRow = detailsDataTable.NewRow();

                newDataRow[Columns.Position] = team.positionField;
                newDataRow[Columns.PositionChange] = GenericFunctions.GetPositionChange(team.positionChangeField);
                newDataRow[Columns.TeamName] = team.teamNameField;
                newDataRow[Columns.Matches] = team.matchesField;
                newDataRow[Columns.Won] = 0;
                newDataRow[Columns.Draw] = 0;
                newDataRow[Columns.Lost] = 0;
                newDataRow[Columns.GoalsFor] = team.goalsForField;
                newDataRow[Columns.GoalsAgainst] = team.goalsAgainstField;
                newDataRow[Columns.GoalDifference] = team.goalsForField - team.goalsAgainstField;
                newDataRow[Columns.Points] = team.pointsField;
                newDataRow[Columns.TeamID] = team.teamIdField;

                detailsDataTable.Rows.Add(newDataRow);
            }

            dataGridViewPositions.DataSource = detailsDataTable;
        }

        private void LoadFixturesGrid()
        {
            DataTable fixturesDataTable = new DataTable();
            fixturesDataTable.Columns.Add(Columns.Round, typeof(byte));
            fixturesDataTable.Columns.Add(Columns.MatchDate, typeof(string));
            fixturesDataTable.Columns.Add(Columns.HomeResult, typeof(Image));
            fixturesDataTable.Columns.Add(Columns.HomeTeamID, typeof(uint));
            fixturesDataTable.Columns.Add(Columns.HomeTeam, typeof(string));
            fixturesDataTable.Columns.Add(Columns.Score, typeof(string));
            fixturesDataTable.Columns.Add(Columns.AwayTeamID, typeof(uint));
            fixturesDataTable.Columns.Add(Columns.AwayTeam, typeof(string));
            fixturesDataTable.Columns.Add(Columns.AwayResult, typeof(Image));

            foreach (HTEntities.LeagueFixtures.Match match in leagueFixtures.matchListField)
            {
                DataRow newDataRow = fixturesDataTable.NewRow();

                newDataRow[Columns.Round] = match.matchRoundField;
                newDataRow[Columns.MatchDate] = match.matchDateField.ToString(General.DateTimeFormat);
                newDataRow[Columns.HomeTeamID] = match.homeTeamField.homeTeamIdField;
                newDataRow[Columns.HomeTeam] = match.homeTeamField.homeTeamNameField;
                newDataRow[Columns.Score] = string.Format(General.Score, match.homeGoalsField, match.awayGoalsField);
                newDataRow[Columns.AwayTeamID] = match.awayTeamField.awayTeamIdField;
                newDataRow[Columns.AwayTeam] = match.awayTeamField.awayTeamNameField;

                if (match.matchDateField < leagueFixtures.fetchedDateField)
                {
                    newDataRow[Columns.HomeResult] = GenericFunctions.GetResultImage(match.homeGoalsField, match.awayGoalsField, TeamLocation.Home);
                    newDataRow[Columns.AwayResult] = GenericFunctions.GetResultImage(match.homeGoalsField, match.awayGoalsField, TeamLocation.Away);
                }
                else
                {
                    newDataRow[Columns.HomeResult] = HM.Resources.Properties.Resources.Grey;
                    newDataRow[Columns.AwayResult] = HM.Resources.Properties.Resources.Grey;
                }

                fixturesDataTable.Rows.Add(newDataRow);
            }

            dataGridViewFixtures.DataSource = fixturesDataTable;
        }

        #endregion
    }
}
