using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HTEntities = HM.Entities.Hattrick.ArenaDetails;
using HMEntities = HM.Entities.HattrickManager.UserProfiles;
using HM.Resources.Constants;

namespace HM.UserInterface {
    public partial class FormArena : FormBase {
        #region Properties

        private HTEntities.ArenaDetails arenaDetails;
        private HMEntities.User user;

        #endregion

        #region Events

        public FormArena(HTEntities.ArenaDetails arenaDetails, HMEntities.User user) {
            this.arenaDetails = arenaDetails;
            this.user = user;
            InitializeComponent();
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
            this.buttonClose.Text = resourceManager.GetString(Localization.ui_arena_buttonClose);
            this.groupBoxArena.Text = resourceManager.GetString(Localization.ui_arena_groupBoxArena);
            this.groupBoxSeats.Text = resourceManager.GetString(Localization.ui_arena_groupBoxSeats);
            this.Text = resourceManager.GetString(Localization.ui_arena_FormText);
            this.labelArenaName.Text = resourceManager.GetString(Localization.ui_arena_labelArenaName);
            this.labelBasic.Text = resourceManager.GetString(Localization.ui_arena_labelBasic);
            this.labelCurrent.Text = resourceManager.GetString(Localization.ui_arena_labelCurrent);
            this.labelDifference.Text = resourceManager.GetString(Localization.ui_arena_labelDifference);
            this.labelExpanded.Text = resourceManager.GetString(Localization.ui_arena_labelExpanded);
            this.labelMaintenance.Text = resourceManager.GetString(Localization.ui_arena_labelMaintenance);
            this.labelMaxIncome.Text = resourceManager.GetString(Localization.ui_arena_labelMaxIncome);
            this.labelRegion.Text = resourceManager.GetString(Localization.ui_arena_labelRegion);
            this.labelSeatsCurrent.Text = resourceManager.GetString(Localization.ui_arena_labelSeats);
            this.labelSeatsDifference.Text = resourceManager.GetString(Localization.ui_arena_labelSeats);
            this.labelSeatsExpanded.Text = resourceManager.GetString(Localization.ui_arena_labelSeats);
            this.labelPercentageCurrent.Text = resourceManager.GetString(Localization.ui_arena_labelPercentage);
            this.labelPercentageExpanded.Text = resourceManager.GetString(Localization.ui_arena_labelPercentage);
            this.labelRoof.Text = resourceManager.GetString(Localization.ui_arena_labelRoof);
            this.labelTerraces.Text = resourceManager.GetString(Localization.ui_arena_labelTerraces);
            this.labelTotal.Text = resourceManager.GetString(Localization.ui_arena_labelTotal);
            this.labelVip.Text = resourceManager.GetString(Localization.ui_arena_labelVip);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loads all the controls
        /// </summary>
        private void LoadControls() {
            //Obtaining and calculating values
            int terracesCurrent = Convert.ToInt32(this.arenaDetails.currentCapacityField.terracesField);
            int basicCurrent = Convert.ToInt32(this.arenaDetails.currentCapacityField.basicField);
            int roofCurrent = Convert.ToInt32(this.arenaDetails.currentCapacityField.roofField);
            int vipCurrent = Convert.ToInt32(this.arenaDetails.currentCapacityField.vipField);
            int totalCurrent = Convert.ToInt32(this.arenaDetails.currentCapacityField.totalField);
            int terracesExpanded;
            int basicExpanded;
            int roofExpanded;
            int vipExpanded;
            int totalExpanded;
            int terracesDifference;
            int basicDifference;
            int roofDifference;
            int vipDifference;
            int totalDifference;
            decimal terracesPercentageCurrent;
            decimal basicPercentageCurrent;
            decimal roofPercentageCurrent;
            decimal vipPercentageCurrent;
            decimal terracesPercentageExpanded;
            decimal basicPercentageExpanded;
            decimal roofPercentageExpanded;
            decimal vipPercentageExpanded;
            decimal maintenanceCurrent = terracesCurrent * DefaultValues.ArenaTerracesCost
                                       + basicCurrent * DefaultValues.ArenaBasicCost
                                       + roofCurrent * DefaultValues.ArenaRoofCost
                                       + vipCurrent * DefaultValues.ArenaVipCost;
            decimal maintenanceExpanded;
            decimal maxIncomeCurrent = terracesCurrent * DefaultValues.ArenaTerracesIncome
                                     + basicCurrent * DefaultValues.ArenaBasicIncome
                                     + roofCurrent * DefaultValues.ArenaRoofIncome
                                     + vipCurrent * DefaultValues.ArenaVipIncome;
            decimal maxIncomeExpanded;

            if (this.arenaDetails.expandedCapacityField.availableField) {
                terracesExpanded = Convert.ToInt32(this.arenaDetails.expandedCapacityField.terracesField);
                basicExpanded = Convert.ToInt32(this.arenaDetails.expandedCapacityField.basicField);
                roofExpanded = Convert.ToInt32(this.arenaDetails.expandedCapacityField.roofField);
                vipExpanded = Convert.ToInt32(this.arenaDetails.expandedCapacityField.vipField);
                totalExpanded = terracesExpanded + basicExpanded + roofExpanded + vipExpanded;
            } else {
                terracesExpanded = terracesCurrent;
                basicExpanded = basicCurrent;
                roofExpanded = roofCurrent;
                vipExpanded = vipCurrent;
                totalExpanded = totalCurrent;
            }

            terracesDifference = terracesExpanded - terracesCurrent;
            basicDifference = basicExpanded - basicCurrent;
            roofDifference = roofExpanded - roofCurrent;
            vipDifference = vipExpanded - vipCurrent;
            totalDifference = totalExpanded - totalCurrent;

            terracesPercentageCurrent = ((Convert.ToDecimal(terracesCurrent) / Convert.ToDecimal(totalCurrent)) * 100);
            basicPercentageCurrent = ((Convert.ToDecimal(basicCurrent) / Convert.ToDecimal(totalCurrent)) * 100);
            roofPercentageCurrent = ((Convert.ToDecimal(roofCurrent) / Convert.ToDecimal(totalCurrent)) * 100);
            vipPercentageCurrent = ((Convert.ToDecimal(vipCurrent) / Convert.ToDecimal(totalCurrent)) * 100);

            terracesPercentageExpanded = ((Convert.ToDecimal(terracesExpanded) / Convert.ToDecimal(totalExpanded)) * 100);
            basicPercentageExpanded = ((Convert.ToDecimal(basicExpanded) / Convert.ToDecimal(totalExpanded)) * 100);
            roofPercentageExpanded = ((Convert.ToDecimal(roofExpanded) / Convert.ToDecimal(totalExpanded)) * 100);
            vipPercentageExpanded = ((Convert.ToDecimal(vipExpanded) / Convert.ToDecimal(totalExpanded)) * 100);

            maintenanceExpanded = terracesExpanded * DefaultValues.ArenaTerracesCost
                                + basicExpanded * DefaultValues.ArenaBasicCost
                                + roofExpanded * DefaultValues.ArenaRoofCost
                                + vipExpanded * DefaultValues.ArenaVipCost;
            maxIncomeExpanded = terracesExpanded * DefaultValues.ArenaTerracesIncome
                              + basicExpanded * DefaultValues.ArenaBasicIncome
                              + roofExpanded * DefaultValues.ArenaRoofIncome
                              + vipExpanded * DefaultValues.ArenaVipIncome;

            //Loading controls
            labelArenaNameValue.Text = string.Format(General.ValueId, this.arenaDetails.arenaNameField, this.arenaDetails.arenaIdField);
            labelRegionValue.Text = string.Format(General.ValueId, this.arenaDetails.regionField.regionNameField, this.arenaDetails.regionField.regionIdField);
            labelTerracesCurrent.Text = terracesCurrent.ToString(General.NoDecimalFormat);
            labelBasicCurrent.Text = basicCurrent.ToString(General.NoDecimalFormat);
            labelRoofCurrent.Text = roofCurrent.ToString(General.NoDecimalFormat);
            labelVipCurrent.Text = vipCurrent.ToString(General.NoDecimalFormat);
            labelTotalCurrent.Text = totalCurrent.ToString(General.NoDecimalFormat);
            labelTerracesExpanded.Text = terracesExpanded.ToString(General.NoDecimalFormat);
            labelBasicExpanded.Text = basicExpanded.ToString(General.NoDecimalFormat);
            labelRoofExpanded.Text = roofExpanded.ToString(General.NoDecimalFormat);
            labelVipExpanded.Text = vipExpanded.ToString(General.NoDecimalFormat);
            labelTotalExpanded.Text = totalExpanded.ToString(General.NoDecimalFormat);
            labelTerracesDifference.Text = terracesDifference.ToString(General.NoDecimalFormat);
            labelBasicDifference.Text = basicDifference.ToString(General.NoDecimalFormat);
            labelRoofDifference.Text = roofDifference.ToString(General.NoDecimalFormat);
            labelVipDifference.Text = vipDifference.ToString(General.NoDecimalFormat);
            labelTotalDifference.Text = totalDifference.ToString(General.NoDecimalFormat);
            labelTerracesPercentageCurrent.Text = string.Format(General.Percentage, terracesPercentageCurrent.ToString(General.TwoDecimalsFormat));
            labelBasicPercentageCurrent.Text = string.Format(General.Percentage, basicPercentageCurrent.ToString(General.TwoDecimalsFormat));
            labelRoofPercentageCurrent.Text = string.Format(General.Percentage, roofPercentageCurrent.ToString(General.TwoDecimalsFormat));
            labelVipPercentageCurrent.Text = string.Format(General.Percentage, vipPercentageCurrent.ToString(General.TwoDecimalsFormat));
            labelTerracesPercentageExpanded.Text = string.Format(General.Percentage, terracesPercentageExpanded.ToString(General.TwoDecimalsFormat));
            labelBasicPercentageExpanded.Text = string.Format(General.Percentage, basicPercentageExpanded.ToString(General.TwoDecimalsFormat));
            labelRoofPercentageExpanded.Text = string.Format(General.Percentage, roofPercentageExpanded.ToString(General.TwoDecimalsFormat));
            labelVipPercentageExpanded.Text = string.Format(General.Percentage, vipPercentageExpanded.ToString(General.TwoDecimalsFormat));
            labelMaintenanceCurrent.Text = Core.CurrencyManager.Convert(user, Convert.ToInt32(maintenanceCurrent));
            labelMaintenanceExpanded.Text = Core.CurrencyManager.Convert(user, Convert.ToInt32(maintenanceExpanded));
            labelMaxIncomeCurrent.Text = Core.CurrencyManager.Convert(user, Convert.ToInt32(maxIncomeCurrent));
            labelMaxIncomeExpanded.Text = Core.CurrencyManager.Convert(user, Convert.ToInt32(maxIncomeExpanded));
        }

        #endregion
    }
}