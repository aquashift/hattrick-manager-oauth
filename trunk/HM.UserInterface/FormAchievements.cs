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
using HM.Resources;

namespace HM.UserInterface
{
    public partial class FormAchievements : FormBase
    {
        #region Properties

        private HTEntities.Achievements.Achievements achievements;
        private DataTable achievementsDataTable;

        #endregion

        #region Constants

        private const string columnTextName = "columnText";
        private const string columnTypeIDName = "columnTypeID";
        private const string columnCategoryIDName = "columnCategoryID";
        private const string columnEventDateName = "columnEventDate";
        private const string columnMultiLevelName = "columnMultiLevel";
        private const string columnNumberOfEventsName = "columnNumberOfEvents";
        private const string columnPointsName = "columnPoints";

        #endregion

        #region Controls events

        public FormAchievements(HTEntities.Achievements.Achievements achievements)
        {
            InitializeComponent();

            achievementsDataTable = new DataTable();

            achievementsDataTable.Columns.Add(Columns.Text, typeof(string));
            achievementsDataTable.Columns.Add(Columns.TypeID, typeof(uint));
            achievementsDataTable.Columns.Add(Columns.CategoryID, typeof(string));
            achievementsDataTable.Columns.Add(Columns.EventDate, typeof(DateTime));
            achievementsDataTable.Columns.Add(Columns.Points, typeof(int));
            achievementsDataTable.Columns.Add(Columns.MultiLevel, typeof(bool));
            achievementsDataTable.Columns.Add(Columns.NumberOfEvents, typeof(uint));

            this.achievements = achievements;

            LoadControls();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxAchievementsCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Fills the form's controls with the selected language
        /// </summary>
        protected override void PopulateLanguage()
        {
            this.buttonClose.Text = resourceManager.GetString(Localization.ui_achievements_buttonClose);
            this.dataGridViewAchievements.Columns[columnTextName].HeaderText = resourceManager.GetString(Localization.ui_achievements_columnText);
            this.dataGridViewAchievements.Columns[columnTypeIDName].HeaderText = resourceManager.GetString(Localization.ui_achievements_columnTypeID);
            this.dataGridViewAchievements.Columns[columnCategoryIDName].HeaderText = resourceManager.GetString(Localization.ui_achievements_columnCategoryID);
            this.dataGridViewAchievements.Columns[columnEventDateName].HeaderText = resourceManager.GetString(Localization.ui_achievements_columnEventDate);
            this.dataGridViewAchievements.Columns[columnMultiLevelName].HeaderText = resourceManager.GetString(Localization.ui_achievements_columnMultiLevel);
            this.dataGridViewAchievements.Columns[columnNumberOfEventsName].HeaderText = resourceManager.GetString(Localization.ui_achievements_columnNumberOfEvents);
            this.dataGridViewAchievements.Columns[columnPointsName].HeaderText = resourceManager.GetString(Localization.ui_achievements_columnPoints);
            this.Text = resourceManager.GetString(Localization.ui_achievements_FormText);
            this.labelCategory.Text = resourceManager.GetString(Localization.ui_achievements_labelCategory);
            this.labelPoints.Text = resourceManager.GetString(Localization.ui_achievements_labelPoints);
        }

        #endregion

        #region Private methos

        private void LoadControls()
        {
            LoadCombo();
            LoadGrid();
            labelTotalPoints.Text = string.Format(resourceManager.GetString(Localization.ui_achievements_labelTotalPoints), achievements.userPointsField, achievements.maxPointsField);
        }

        private void LoadCombo()
        {
            DataTable categoryIdDataTable = new DataTable();
            categoryIdDataTable.Columns.Add(Columns.Display, typeof(string));
            categoryIdDataTable.Columns.Add(Columns.Value, typeof(AchievementCategory));

            for (int i = 0; i < 5; i++)
            {
                DataRow newDataRow = categoryIdDataTable.NewRow();

                newDataRow[Columns.Display] = GetAchievementCategoryText((AchievementCategory)i);
                newDataRow[Columns.Value] = (AchievementCategory)i;

                categoryIdDataTable.Rows.Add(newDataRow);
            }

            comboBoxAchievementsCategory.DisplayMember = Columns.Display;
            comboBoxAchievementsCategory.ValueMember = Columns.Value;

            comboBoxAchievementsCategory.DataSource = categoryIdDataTable;
        }

        private void LoadGrid()
        {
            AchievementCategory selectedFilter = (AchievementCategory)comboBoxAchievementsCategory.SelectedValue;

            achievementsDataTable.Rows.Clear();

            foreach (HTEntities.Achievements.Achievement currentAchievement in achievements.achievementListField)
            {
                if ((currentAchievement.categoryIdField == selectedFilter) || (selectedFilter == AchievementCategory.Unavailable))
                {
                    DataRow newDataRow = achievementsDataTable.NewRow();

                    newDataRow[Columns.Text] = GenericFunctions.RemoveTagsFromString(currentAchievement.achievementTextField);
                    newDataRow[Columns.TypeID] = currentAchievement.achievementTypeIdField;
                    newDataRow[Columns.CategoryID] = GetAchievementCategoryText(currentAchievement.categoryIdField);
                    newDataRow[Columns.EventDate] = currentAchievement.eventDateField;
                    newDataRow[Columns.Points] = currentAchievement.pointsField;
                    newDataRow[Columns.MultiLevel] = currentAchievement.multilevelField;
                    newDataRow[Columns.NumberOfEvents] = currentAchievement.numberOfEventsField;

                    achievementsDataTable.Rows.Add(newDataRow);
                }
            }

            dataGridViewAchievements.DataSource = achievementsDataTable;
        }

        private string GetAchievementCategoryText(AchievementCategory category)
        {
            string resourceId = string.Empty;

            switch (category)
            {
                case AchievementCategory.Unavailable:
                    resourceId = Localization.ht_achievementcategory_Undefined;
                    break;
                case AchievementCategory.Ranking:
                    resourceId = Localization.ht_achievementcategory_Ranking;
                    break;
                case AchievementCategory.Team:
                    resourceId = Localization.ht_achievementcategory_Team;
                    break;
                case AchievementCategory.Matches:
                    resourceId = Localization.ht_achievementcategory_Matches;
                    break;
                case AchievementCategory.Manager:
                    resourceId = Localization.ht_achievementcategory_Manager;
                    break;
                case AchievementCategory.SpecialAward:
                    resourceId = Localization.ht_achievementcategory_SpecialAward;
                    break;
            }

            return resourceManager.GetString(resourceId);
        }

        #endregion
    }
}