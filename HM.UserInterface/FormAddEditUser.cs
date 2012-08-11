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
using HM.Core;
using HM.Resources.Constants;
using HM.Resources;
using HM.Resources.CustomEvents;

namespace HM.UserInterface {
    public partial class FormAddEditUser : FormBase {
        #region Properties

        private HMEntities.UserProfiles.User userProfile;
        private FormMode formMode;
        private bool validatedLoginname;
        private bool validatedSecurityCode;
        private bool validatedCredentials;

        #endregion

        #region Control's events

        public FormAddEditUser() {
            InitializeComponent();
            formMode = FormMode.Add;
            validatedLoginname = false;
            validatedSecurityCode = false;
            validatedCredentials = false;
            userProfile = new HM.Entities.HattrickManager.UserProfiles.User();
            validatedCredentials = false;
        }

        public FormAddEditUser(HMEntities.UserProfiles.User selectedUser) {
            InitializeComponent();
            formMode = FormMode.Edit;
            validatedLoginname = true;
            validatedSecurityCode = true;
            validatedCredentials = false;
            this.userProfile = selectedUser;
            this.buttonTest.Enabled = true;
            LoadControls();
        }

        private void buttonBrowse_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()) {
                folderBrowserDialog.Description = resourceManager.GetString(Localization.ui_addedituser_browseFormDescription);
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog.ShowNewFolderButton = true;
                folderBrowserDialog.ShowDialog(this);

                string selectedPath = folderBrowserDialog.SelectedPath;
                if (selectedPath.Length != 0) {
                    textBoxDataFolder.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void buttonTest_Click(object sender, EventArgs e) {
            HTEntities.TeamDetails.TeamDetails teamDetails = new HTEntities.TeamDetails.TeamDetails();

            userProfile.loginNameField = textBoxLoginname.Text;
            userProfile.securityCodeField = textBoxSecurityCode.Text;

            Core.DownloadManager downloadManager = new DownloadManager(userProfile);

            this.Enabled = false;

            validatedCredentials = downloadManager.DownloadUserBasicData(out teamDetails);

            this.Enabled = true;

            if (validatedCredentials) {
                LoadUserBasicData(teamDetails);
            }

            ToggleControls();
        }

        private void textBoxLoginname_KeyUp(object sender, KeyEventArgs e) {
            bool validated = textBoxLoginname.TextLength > 0 ? true : false;

            validatedLoginname = validated;
            validatedCredentials = false;

            ToggleControls();
        }

        private void textBoxSecurityCode_KeyUp(object sender, KeyEventArgs e) {
            bool validated = textBoxSecurityCode.TextLength > 0 ? true : false;

            validatedSecurityCode = validated;
            validatedCredentials = false;

            ToggleControls();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Sets controls with the corresponding text
        /// </summary>
        protected override void PopulateLanguage() {
            this.buttonBrowse.Text = resourceManager.GetString(Localization.ui_addedituser_buttonBrowse);
            this.buttonCancel.Text = resourceManager.GetString(Localization.ui_addedituser_buttonCancel);
            this.buttonOk.Text = resourceManager.GetString(Localization.ui_addedituser_buttonOk);
            this.buttonTest.Text = resourceManager.GetString(Localization.ui_addedituser_buttonTest);
            this.checkBoxStoreSecurityCode.Text = resourceManager.GetString(Localization.ui_addedituser_checkBoxStoreSecurityCode);
            this.groupBoxUserCredentials.Text = resourceManager.GetString(Localization.ui_addedituser_groupBoxUserCredentials);
            this.groupBoxUserData.Text = resourceManager.GetString(Localization.ui_addedituser_groupBoxUserData);
            this.labelActivationDate.Text = resourceManager.GetString(Localization.ui_addedituser_labelActivationDate);
            this.labelDataFolder.Text = resourceManager.GetString(Localization.ui_addedituser_labelDataFolder);
            this.labelLoginname.Text = resourceManager.GetString(Localization.ui_addedituser_labelLoginname);
            this.labelSecurityCode.Text = resourceManager.GetString(Localization.ui_addedituser_labelSecurityCode);
            this.labelTeamId.Text = resourceManager.GetString(Localization.ui_addedituser_labelTeamId);
            this.labelYouthTeamId.Text = resourceManager.GetString(Localization.ui_addedituser_labelYouthTeamId);

            if (formMode == FormMode.Add) {
                this.Text = resourceManager.GetString(Localization.ui_addedituser_FormText_Add);
            } else {
                this.Text = resourceManager.GetString(Localization.ui_addedituser_FormText_Edit);
            }
        }

        /// <summary>
        /// Loads controls with user's data
        /// </summary>
        private void LoadControls() {
            this.textBoxLoginname.Text = userProfile.loginNameField;
            this.checkBoxStoreSecurityCode.Checked = userProfile.storeSecurityCodeField;
            if (checkBoxStoreSecurityCode.Checked) {
                this.textBoxSecurityCode.Text = userProfile.securityCodeField;
            }
            this.textBoxDataFolder.Text = userProfile.dataFolderField;
            this.labelActivationDateValue.Text = userProfile.activationDateField.ToString(General.DateTimeFormat);
            this.labelTeamIdValue.Text = userProfile.teamIdField.ToString();
            this.labelYouthTeamIdValue.Text = userProfile.youthTeamIdField.ToString();
        }

        private void ToggleControls() {
            buttonTest.Enabled = (validatedLoginname && validatedSecurityCode);
            buttonOk.Enabled = (validatedCredentials);

            bool enableControls = labelActivationDateValue.Text != string.Empty ? true : false;

            groupBoxUserData.Enabled = enableControls;
            labelActivationDate.Enabled = enableControls;
            labelActivationDateValue.Enabled = enableControls;
            labelTeamId.Enabled = enableControls;
            labelTeamIdValue.Enabled = enableControls;
            labelYouthTeamId.Enabled = enableControls;
            labelYouthTeamIdValue.Enabled = enableControls;
        }

        private void LoadUserBasicData(HTEntities.TeamDetails.TeamDetails teamDetails) {
            this.labelActivationDateValue.Text = teamDetails.userField.activationDateField.ToString(General.DateTimeFormat);
            this.labelTeamIdValue.Text = teamDetails.teamField.teamIdField.ToString();
            this.labelYouthTeamIdValue.Text = teamDetails.teamField.youthTeamIdField.ToString();

            this.userProfile.teamIdField = teamDetails.teamField.teamIdField;
            this.userProfile.activationDateField = teamDetails.userField.activationDateField;
            this.userProfile.youthTeamIdField = teamDetails.teamField.youthTeamIdField;

            UpdateUserProfile();
        }

        /// <summary>
        /// Copies data from form to user profile
        /// </summary>
        private void UpdateUserProfile() {
            this.userProfile.loginNameField = this.textBoxLoginname.Text;
            this.userProfile.securityCodeField = this.textBoxSecurityCode.Text;
            this.userProfile.storeSecurityCodeField = this.checkBoxStoreSecurityCode.Checked;
            this.userProfile.dataFolderField = this.textBoxDataFolder.Text;
        }

        #endregion

        private void buttonOk_Click(object sender, EventArgs e) {
            UpdateUserProfile();
            EntityManager.SaveUser(userProfile);
        }
    }
}