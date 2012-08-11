using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HM.Resources;
using System.Resources;
using System.Globalization;
using System.Threading;
using HM.Resources.Constants;

namespace HM.UserInterface
{
    public partial class FormWorldDetails : FormBase
    {
        #region Properties

        private HM.Entities.Hattrick.WorldDetails.WorldDetails _worldDetails = new HM.Entities.Hattrick.WorldDetails.WorldDetails();

        #endregion

        #region Methods

        public FormWorldDetails(HM.Entities.Hattrick.WorldDetails.WorldDetails worldDetails)
        {
            InitializeComponent();

            _worldDetails = worldDetails;
            _worldDetails.leagueListField.Sort(HM.Entities.Hattrick.WorldDetails.League.englishNameComparison);

            LoadControls();
        }

        public FormWorldDetails(HM.Entities.Hattrick.WorldDetails.WorldDetails worldDetails,
            uint initialLeagueId)
            : this(worldDetails)
        {
            comboBoxLeague.SelectedIndex =
                worldDetails.leagueListField.FindIndex(l => l.leagueIdField == initialLeagueId);
        }

        /// <summary>
        /// Fills the form's controls with the selected language
        /// </summary>
        protected override void PopulateLanguage()
        {
            this.buttonClose.Text = resourceManager.GetString(Localization.ui_worlddetails_buttonClose);
            this.Text = resourceManager.GetString(Localization.ui_worlddetails_FormText);
            this.groupBoxLeagueEvents.Text = resourceManager.GetString(Localization.ui_worlddetails_groupBoxLeagueEvents);
            this.groupBoxLeagueInfo.Text = resourceManager.GetString(Localization.ui_worlddetails_groupBoxLeagueInfo);
            this.labelActiveUsers.Text = resourceManager.GetString(Localization.ui_worlddetails_labelActiveUsers);
            this.labelCupMatchDate.Text = resourceManager.GetString(Localization.ui_worlddetails_labelCupMatchDate);
            this.labelCupName.Text = resourceManager.GetString(Localization.ui_worlddetails_labelCupName);
            this.labelCurrencyName.Text = resourceManager.GetString(Localization.ui_worlddetails_labelCurrencyName);
            this.labelCurrencyRate.Text = resourceManager.GetString(Localization.ui_worlddetails_labelCurrencyRate);
            this.labelEconomyDate.Text = resourceManager.GetString(Localization.ui_worlddetails_labelEconomyDate);
            this.labelEnglishName.Text = resourceManager.GetString(Localization.ui_worlddetails_labelEnglishName);
            this.labelLeague.Text = resourceManager.GetString(Localization.ui_worlddetails_labelLeague);
            this.labelLeagueLevels.Text = resourceManager.GetString(Localization.ui_worlddetails_labelLeagueLevels);
            this.labelLeagueSeason.Text = resourceManager.GetString(Localization.ui_worlddetails_labelLeagueSeason);
            this.labelMatchRound.Text = resourceManager.GetString(Localization.ui_worlddetails_labelMatchRound);
            this.labelSeriesMatchDate.Text = resourceManager.GetString(Localization.ui_worlddetails_labelSeriesMatchDate);
            this.labelTrainingDate.Text = resourceManager.GetString(Localization.ui_worlddetails_labelTrainingDate);
            this.labelWaitingUsers.Text = resourceManager.GetString(Localization.ui_worlddetails_labelWaitingUsers);
            this.labelZoneName.Text = resourceManager.GetString(Localization.ui_worlddetails_labelZoneName);
        }

        /// <summary>
        /// Loads the controls
        /// </summary>
        private void LoadControls()
        {
            comboBoxLeague.DataSource = _worldDetails.leagueListField;
            comboBoxLeague.DisplayMember = "englishNameField";
        }

        /// <summary>
        /// Sets selected league data to the controls
        /// </summary>
        /// <param name="selectedLeague">Selected league id</param>
        private void SetSelectedLeagueInfo(HM.Entities.Hattrick.WorldDetails.League selectedLeague)
        {
            pictureBoxFlag.Image = GenericFunctions.GetFlagByLeagueId(selectedLeague.leagueIdField);
            linkLabelLeague.Text = selectedLeague.leagueNameField;
            labelEnglishNameValue.Text = selectedLeague.englishNameField;
            labelZoneNameValue.Text = selectedLeague.zoneNameField;
            labelCurrencyNameValue.Text = selectedLeague.countryField.currencyNameField;
            labelCurrencyRateValue.Text = selectedLeague.countryField.currencyRateField.ToString();
            labelLeagueSeasonValue.Text = selectedLeague.seasonField.ToString();
            labelMatchRoundValue.Text = selectedLeague.matchRoundField.ToString();
            labelLeagueLevelsValue.Text = selectedLeague.numberOfLevelsField.ToString();
            labelActiveUsersValue.Text = selectedLeague.activeUsersField.ToString("N0");
            labelWaitingUsersValue.Text = selectedLeague.waitingUsersField.ToString("N0");
            labelCupNameValue.Text = selectedLeague.cupField.cupNameField.ToString();
            labelTrainingDateValue.Text = GetEventTimeString(selectedLeague.trainingDateField);
            labelEconomyDateValue.Text = GetEventTimeString(selectedLeague.economyDateField);
            labelCupMatchDateValue.Text = GetEventTimeString(selectedLeague.cupMatchDateField);
            labelSeriesMatchDateValue.Text = GetEventTimeString(selectedLeague.seriesMatchDateField);
        }

        /// <summary>
        /// Formats HT event (e.g., training update) date to a string. 
        /// </summary>
        /// <param name="eventDate">Date to format</param>
        /// <returns>String in "weekday, time" format, in CurrentUICulture.</returns>
        private string GetEventTimeString(DateTime eventDate)
        {
            // TODO. Either move date format to Resources, or make it culture-dependant
            return eventDate.ToString(General.LongDateFormat, Thread.CurrentThread.CurrentUICulture);
        }

        #endregion

        #region Events

        private void comboBoxLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSelectedLeagueInfo((HM.Entities.Hattrick.WorldDetails.League)comboBoxLeague.SelectedValue);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelLeague_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // TODO. Move link to Resources
            System.Diagnostics.Process.Start("http://maps.google.com/?q=" + linkLabelLeague.Text);
        }

        #endregion
    }
}
