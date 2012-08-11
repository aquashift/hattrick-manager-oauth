using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HM.Entities.Hattrick.Club;
using HM.Resources.Constants;
using HM.Core;
using HM.Entities.HattrickManager.UserProfiles;

namespace HM.UserInterface
{
    public partial class FormClub : FormBase
    {
        #region Constants

        private const int specialistsCost = 18000;

        #endregion

        #region Properties

        private Club club;
        private User user;

        #endregion

        public FormClub(Club club, User user)
        {
            InitializeComponent();
            this.club = club;
            this.user = user;
            LoadClubData();
        }

        private void LoadClubData()
        {
            this.labelTeamIDValue.Text = club.teamField.teamIdField.ToString();
            this.labelTeamNameValue.Text = club.teamField.teamNameField;
            this.labelAssistantsValue.Text = club.teamField.specialistsField.assistantTrainersField.ToString();
            this.labelPsychologistsValue.Text = club.teamField.specialistsField.psychologistsField.ToString();
            this.labelSpokespersonsValue.Text = club.teamField.specialistsField.pressSpokesmenField.ToString();
            this.labelPhysiotherapistsValue.Text = club.teamField.specialistsField.physiotherapistsField.ToString();
            this.labelDoctorsValue.Text = club.teamField.specialistsField.doctorsField.ToString();
            this.labelTotalValue.Text = Convert.ToString(club.teamField.specialistsField.assistantTrainersField +
                                                         club.teamField.specialistsField.physiotherapistsField +
                                                         club.teamField.specialistsField.pressSpokesmenField +
                                                         club.teamField.specialistsField.psychologistsField +
                                                         club.teamField.specialistsField.doctorsField);
            this.labelAssistantTrainersCost.Text = Core.CurrencyManager.Convert(this.user, specialistsCost * club.teamField.specialistsField.assistantTrainersField);
            this.labelPsychologistsCost.Text = Core.CurrencyManager.Convert(this.user, specialistsCost * club.teamField.specialistsField.psychologistsField);
            this.labelPressSpokesmenCost.Text = Core.CurrencyManager.Convert(this.user, specialistsCost * club.teamField.specialistsField.pressSpokesmenField);
            this.labelPhysiotherapistsCost.Text = Core.CurrencyManager.Convert(this.user, specialistsCost * club.teamField.specialistsField.physiotherapistsField);
            this.labelDoctorsCost.Text = Core.CurrencyManager.Convert(this.user, specialistsCost * club.teamField.specialistsField.doctorsField);
            this.labelInvestmentsValue.Text = Core.CurrencyManager.Convert(this.user, club.teamField.youthSquadField.investmentField);
            this.labelYouthLevelValue.Text = string.Format(General.Skill, resourceManager.GetString(string.Format(Localization.ht_youth_level, club.teamField.youthSquadField.youthLevelField.ToString().PadLeft(2, General.Zero))), club.teamField.youthSquadField.youthLevelField);
            this.labelTotalCost.Text = Core.CurrencyManager.Convert(this.user, (club.teamField.specialistsField.assistantTrainersField +
                                                                                club.teamField.specialistsField.physiotherapistsField +
                                                                                club.teamField.specialistsField.pressSpokesmenField +
                                                                                club.teamField.specialistsField.psychologistsField +
                                                                                club.teamField.specialistsField.doctorsField) * specialistsCost);
            this.checkBoxHasPromoted.Checked = club.teamField.youthSquadField.hasPromotedField;
        }

        protected override void PopulateLanguage()
        {
            this.Text = resourceManager.GetString(Localization.ui_club_FormText);
            this.groupBoxInfo.Text = resourceManager.GetString(Localization.ui_club_groupBoxInfo);
            this.labelTeamID.Text = resourceManager.GetString(Localization.ui_club_labelTeamID);
            this.groupBoxStaff.Text = resourceManager.GetString(Localization.ui_club_groupBoxStaff);
            this.groupBoxYouth.Text = resourceManager.GetString(Localization.ui_club_groupBoxYouth);
            this.labelTeamName.Text = resourceManager.GetString(Localization.ui_club_labelTeamName);
            this.labelAssistants.Text = resourceManager.GetString(Localization.ui_club_labelAssistants);
            this.labelPsychologists.Text = resourceManager.GetString(Localization.ui_club_labelPsychologists);
            this.labelSpokespersons.Text = resourceManager.GetString(Localization.ui_club_labelSpokespersons);
            this.labelPhysiotherapists.Text = resourceManager.GetString(Localization.ui_club_labelPhysiotherapists);
            this.labelDoctors.Text = resourceManager.GetString(Localization.ui_club_labelDoctors);
            this.labelTotal.Text = resourceManager.GetString(Localization.ui_club_labelTotal);
            this.labelInvestments.Text = resourceManager.GetString(Localization.ui_club_labelInvestments);
            this.labelYouthLevel.Text = resourceManager.GetString(Localization.ui_club_labelYouthLevel);
            this.labelHasPromoted.Text = resourceManager.GetString(Localization.ui_club_labelHasPromoted);
            this.buttonClose.Text = resourceManager.GetString(Localization.ui_club_buttonClose);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
