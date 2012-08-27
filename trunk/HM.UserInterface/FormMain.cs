using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HM.Core;
using HM.Entities.HattrickManager.UserProfiles;
using HM.Resources;
using HM.Resources.Constants;
using HMEntities = HM.Entities.HattrickManager;
using HTEntities = HM.Entities.Hattrick;

namespace HM.UserInterface {
    public partial class FormMain : FormBase {
        #region Properties

        private DataManager dataManager;
        private EntityManager entityManager;
        private HMEntities.UserProfiles.UserProfiles userProfiles;
        private HMEntities.UserProfiles.User currentUser;
        private bool selectedUser = false;

        #endregion

        #region Events

        public FormMain() {
            InitializeComponent();

            using (FormUserSelection formUserSelection = new FormUserSelection()) {
                formUserSelection.ShowDialog(this);

                if (formUserSelection.DialogResult == DialogResult.OK) {
                    this.userProfiles = formUserSelection.userProfiles;
                    this.currentUser = formUserSelection.selectedUser;
                    this.selectedUser = true;

                    this.dataManager = new DataManager(currentUser);
                    this.entityManager = new EntityManager(currentUser);
                }
            }
        }

        private void buttonAchievements_Click(object sender, EventArgs e) {
            using (FormAchievements formAchievemets = new FormAchievements(entityManager.GetAchievements())) {
                formAchievemets.ShowDialog(this);
            }
        }

        private void buttonArena_Click(object sender, EventArgs e) {
            using (FormArena formArena = new FormArena(entityManager.GetArenaDetails(), currentUser)) {
                formArena.ShowDialog(this);
            }
        }

        private void buttonClub_Click(object sender, EventArgs e) {
            using (FormClub formClub = new FormClub(entityManager.GetClub(), currentUser)) {
                formClub.ShowDialog(this);
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e) {
            using (FormDownload formDownload = new FormDownload(this.currentUser)) {
                formDownload.ShowDialog(this);
            }
        }

        private void buttonEconomy_Click(object sender, EventArgs e) {
            HTEntities.TeamDetails.TeamDetails teamDetails = entityManager.GetTeamDetails();
            HTEntities.WorldDetails.League league = null;

            foreach (HTEntities.WorldDetails.League currentLeague in entityManager.GetWorldDetails().leagueListField) {
                if (currentLeague.leagueIdField == teamDetails.teamField.leagueField.leagueIdField) {
                    league = currentLeague;
                    break;
                }
            }

            using (FormEconomy formEconomy = new FormEconomy(entityManager.GetEconomy(), league, currentUser)) {
                formEconomy.ShowDialog(this);
            }
        }

        private void buttonLeague_Click(object sender, EventArgs e) {
            using (FormLeague formLeague = new FormLeague(entityManager.GetLeagueDetails(), entityManager.GetLeagueFixtures(), currentUser.teamIdField)) {
                formLeague.ShowDialog(this);
            }
        }

        private void SetLineupControl() {
            panelMainContent.Controls.Clear();

            CustomControls.Lineup lineup = new CustomControls.Lineup(entityManager.GetPlayersDetails(), currentUser);

            lineup.Dock = DockStyle.Fill;

            panelMainContent.Controls.Add(lineup);
        }

        private void buttonLineup_Click(object sender, EventArgs e) {
            SetLineupControl();
        }

        private void buttonMatches_Click(object sender, EventArgs e) {
        }

        private void buttonWorldDetails_Click(object sender, EventArgs e) {
            using (FormWorldDetails formWorldDetails = new FormWorldDetails(entityManager.GetWorldDetails(), entityManager.GetTeamDetails().teamField.leagueField.leagueIdField)) {
                formWorldDetails.ShowDialog(this);
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FormMain_Load(object sender, EventArgs e) {
            if (!selectedUser) {
                this.Close();
            }

            SetToolbarButtons();
            SetLineupControl();
        }

        #endregion

        #region Methods

        private void SetToolbarButtons() {
            for (int i = 0; i < toolStripMain.Items.Count; i++) {
                ToolStripItem item = toolStripMain.Items[i];

                item.Image = HM.Resources.GenericFunctions.GetToolbarImage(item.Text);
            }
        }

        protected override void PopulateLanguage() {
            this.Text = resourceManager.GetString(Localization.ui_main_FormText);

            // Menu
            this.menuFile.Text = resourceManager.GetString(Localization.ui_main_menuFile);
            this.menuItemDownload.Text = resourceManager.GetString(Localization.ui_main_menuItemDownload);
            this.menuItemSettings.Text = resourceManager.GetString(Localization.ui_main_menuItemSettings);
            this.menuItemQuit.Text = resourceManager.GetString(Localization.ui_main_menuItemQuit);
            this.menuTools.Text = resourceManager.GetString(Localization.ui_main_menuTools);
            this.menuItemAchievements.Text = resourceManager.GetString(Localization.ui_main_menuItemAchievements);
            this.menuItemMatches.Text = resourceManager.GetString(Localization.ui_main_menuItemMatches);
            this.menuItemLeague.Text = resourceManager.GetString(Localization.ui_main_menuItemLeague);
            this.menuItemEconomy.Text = resourceManager.GetString(Localization.ui_main_menuItemEconomy);
            this.menuItemTraining.Text = resourceManager.GetString(Localization.ui_main_menuItemTraining);
            this.menuItemArena.Text = resourceManager.GetString(Localization.ui_main_menuItemArena);
            this.menuItemClub.Text = resourceManager.GetString(Localization.ui_main_menuItemClub);
            this.menuItemTopScorers.Text = resourceManager.GetString(Localization.ui_main_menuItemTopScorers);
            this.menuItemWorldDetails.Text = resourceManager.GetString(Localization.ui_main_menuItemWorldDetails);
        }

        #endregion
    }
}