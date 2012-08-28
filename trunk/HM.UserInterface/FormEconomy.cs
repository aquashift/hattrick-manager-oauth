using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HTEntities = HM.Entities.Hattrick;
using HM.Resources.Constants;
using HM.Entities.HattrickManager.UserProfiles;

namespace HM.UserInterface {
    public partial class FormEconomy : FormBase {
        #region Properties

        private HTEntities.Economy.Economy economy;
        private User user;

        #endregion

        #region Controls events

        public FormEconomy(HTEntities.Economy.Economy economy, HTEntities.WorldDetails.League league, User user) {
            InitializeComponent();
            this.economy = economy;
            this.user = user;
            LoadControls();
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Fills the form's controls with the selected language
        /// </summary>
        protected override void PopulateLanguage() {
            this.Text = resourceManager.GetString(Localization.ui_economy_FormText);
            this.labelCosts.Text = resourceManager.GetString(Localization.ui_economy_labelCosts);
            this.labelCostsArena.Text = resourceManager.GetString(Localization.ui_economy_labelCostsArena);
            this.labelCostsFinancial.Text = resourceManager.GetString(Localization.ui_economy_labelCostsFinancial);
            this.labelCostsPlayers.Text = resourceManager.GetString(Localization.ui_economy_labelCostsPlayers);
            this.labelCostsStaff.Text = resourceManager.GetString(Localization.ui_economy_labelCostsStaff);
            this.labelCostsSum.Text = resourceManager.GetString(Localization.ui_economy_labelCostsSum);
            this.labelCostsTemporary.Text = resourceManager.GetString(Localization.ui_economy_labelCostsTemporary);
            this.labelCostsYouth.Text = resourceManager.GetString(Localization.ui_economy_labelCostsYouth);
            this.labelExpectedWeeksTotal.Text = resourceManager.GetString(Localization.ui_economy_labelExpectedWeeksTotal);
            this.labelIncome.Text = resourceManager.GetString(Localization.ui_economy_labelIncome);
            this.labelIncomeFinancial.Text = resourceManager.GetString(Localization.ui_economy_labelIncomeFinancial);
            this.labelIncomeSpectators.Text = resourceManager.GetString(Localization.ui_economy_labelIncomeSpectators);
            this.labelIncomeSponsors.Text = resourceManager.GetString(Localization.ui_economy_labelIncomeSponsors);
            this.labelIncomeSum.Text = resourceManager.GetString(Localization.ui_economy_labelIncomeSum);
            this.labelIncomeTemporary.Text = resourceManager.GetString(Localization.ui_economy_labelIncomeTemporary);
            this.labelLastCosts.Text = resourceManager.GetString(Localization.ui_economy_labelCosts);
            this.labelLastCostsArena.Text = resourceManager.GetString(Localization.ui_economy_labelCostsArena);
            this.labelLastCostsFinancial.Text = resourceManager.GetString(Localization.ui_economy_labelCostsFinancial);
            this.labelLastCostsPlayers.Text = resourceManager.GetString(Localization.ui_economy_labelCostsPlayers);
            this.labelLastCostsStaff.Text = resourceManager.GetString(Localization.ui_economy_labelCostsStaff);
            this.labelLastCostsSum.Text = resourceManager.GetString(Localization.ui_economy_labelCostsSum);
            this.labelLastCostsTemporary.Text = resourceManager.GetString(Localization.ui_economy_labelCostsTemporary);
            this.labelLastCostsYouth.Text = resourceManager.GetString(Localization.ui_economy_labelCostsYouth);
            this.labelLastWeeksTotal.Text = resourceManager.GetString(Localization.ui_economy_labelLastWeeksTotal);
            this.labelLastIncome.Text = resourceManager.GetString(Localization.ui_economy_labelIncome);
            this.labelLastIncomeFinancial.Text = resourceManager.GetString(Localization.ui_economy_labelIncomeFinancial);
            this.labelLastIncomeSpectators.Text = resourceManager.GetString(Localization.ui_economy_labelIncomeSpectators);
            this.labelLastIncomeSponsors.Text = resourceManager.GetString(Localization.ui_economy_labelIncomeSponsors);
            this.labelLastIncomeSum.Text = resourceManager.GetString(Localization.ui_economy_labelIncomeSum);
            this.labelLastIncomeTemporary.Text = resourceManager.GetString(Localization.ui_economy_labelIncomeTemporary);
            this.groupBoxEconomy.Text = resourceManager.GetString(Localization.ui_economy_groupBoxEconomy);
            this.groupBoxThisWeek.Text = resourceManager.GetString(Localization.ui_economy_groupBoxThisWeek);
            this.groupBoxLastWeek.Text = resourceManager.GetString(Localization.ui_economy_groupBoxLastWeek);
            this.buttonClose.Text = resourceManager.GetString(Localization.ui_economy_buttonClose);
            this.labelCash.Text = resourceManager.GetString(Localization.ui_economy_labelCash);
            this.labelFanclubSize.Text = resourceManager.GetString(Localization.ui_economy_labelFanclubSize);
            this.labelSponsorsMood.Text = resourceManager.GetString(Localization.ui_economy_labelSponsorsMood);
            this.labelSupportersMood.Text = resourceManager.GetString(Localization.ui_economy_labelSupportersMood);
        }

        #endregion

        #region Private methods

        private void LoadControls() {
            this.labelCostsArenaValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.costsArenaField);
            this.labelCostsFinancialValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.costsFinancialField);
            this.labelCostsPlayersValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.costsPlayersField);
            this.labelCostsStaffValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.costsStaffField);
            this.labelCostsSumValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.costsSumField);
            this.labelCostsTemporaryValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.costsTemporaryField);
            this.labelCostsYouthValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.costsYouthField);
            this.labelExpectedWeeksTotalValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.expectedWeeksTotalField);
            this.labelIncomeFinancialValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.incomeFinancialField);
            this.labelIncomeSpectatorsValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.incomeSpectatorsField);
            this.labelIncomeSponsorsValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.incomeSponsorsField);
            this.labelIncomeSumValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.incomeSumField);
            this.labelIncomeTemporaryValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.incomeTemporaryField);
            this.labelLastCostsArenaValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.lastCostsArenaField);
            this.labelLastCostsFinancialValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.lastCostsFinancialField);
            this.labelLastCostsPlayersValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.lastCostsPlayersField);
            this.labelLastCostsStaffValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.lastCostsStaffField);
            this.labelLastCostsSumValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.lastCostsSumField);
            this.labelLastCostsTemporaryValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.lastCostsTemporaryField);
            this.labelLastCostsYouthValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.lastCostsYouthField);
            this.labelLastIncomeFinancialValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.lastIncomeFinancialField);
            this.labelLastIncomeSpectatorsValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.lastIncomeSpectatorsField);
            this.labelLastIncomeSponsorsValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.lastIncomeSponsorsField);
            this.labelLastIncomeSumValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.lastIncomeSumField);
            this.labelLastIncomeTemporaryValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.lastIncomeTemporaryField);
            this.labelLastWeeksTotalValue.Text = Core.CurrencyManager.Convert(user, economy.teamField.lastWeeksTotalField);
            this.labelCashValue.Text = string.Format(General.Cash, Core.CurrencyManager.Convert(user, economy.teamField.cashField), Core.CurrencyManager.Convert(user, economy.teamField.expectedCashField));
            this.labelFanClubSizeValue.Text = economy.teamField.fanClubSizeField.ToString(General.NoDecimalFormat);

            if (economy.teamField.sponsorsPopularityField.availableField) {
                int sponsorsLevel = (Int32)economy.teamField.sponsorsPopularityField.sponsorsPopularityField;
                string localizationString = string.Format(Localization.ht_sponsors_mood_available, (sponsorsLevel.ToString().PadLeft(2, General.Zero)), sponsorsLevel);
                this.labelSponsorsMoodValue.Text = string.Format(this.labelSponsorsMoodValue.Text, resourceManager.GetString(localizationString), sponsorsLevel);
            } else {
                this.labelSponsorsMoodValue.Text = resourceManager.GetString(Localization.ht_sponsors_mood_unavailable);
            }

            if (economy.teamField.supportersPopularityField.availableField) {
                int supportersLevel = (Int32)economy.teamField.supportersPopularityField.supportersPopularityField;
                string localizationString = string.Format(Localization.ht_supporters_mood_available, (supportersLevel.ToString().PadLeft(2, General.Zero)), supportersLevel);
                this.labelSupportersMoodValue.Text = string.Format(this.labelSupportersMoodValue.Text, resourceManager.GetString(localizationString), supportersLevel);
            } else {
                this.labelSupportersMoodValue.Text = resourceManager.GetString(Localization.ht_sponsors_mood_unavailable);
            }

            if (economy.teamField.expectedWeeksTotalField != 0) {
                if (economy.teamField.expectedWeeksTotalField > 0) {
                    this.labelExpectedWeeksTotalValue.ForeColor = Color.Green;
                } else {
                    this.labelExpectedWeeksTotalValue.ForeColor = Color.Red;
                }
            }

            if (economy.teamField.lastWeeksTotalField != 0) {
                if (economy.teamField.lastWeeksTotalField > 0) {
                    this.labelLastWeeksTotalValue.ForeColor = Color.Green;
                } else {
                    this.labelLastWeeksTotalValue.ForeColor = Color.Red;
                }
            }
        }

        #endregion
    }
}