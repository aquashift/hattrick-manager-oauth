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
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace HM.UserInterface {
    public partial class FormAddEditUser : FormBase {
        #region Properties

        private HMEntities.UserProfiles.User userProfile;
        private FormMode formMode;
        private IToken requestToken;

        #endregion

        #region Control's events

        private void FormAddEditUser_Load(object sender, EventArgs e) {
            textBoxAuthorizationURL.Text = GetRequestTokenURL();
        }

        public FormAddEditUser() {
            InitializeComponent();
            formMode = FormMode.Add;
            userProfile = new HM.Entities.HattrickManager.UserProfiles.User();
        }

        public FormAddEditUser(HMEntities.UserProfiles.User selectedUser) {
            InitializeComponent();
            formMode = FormMode.Edit;
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
            IToken accessToken = ExchangeRequestTokenForAccessToken(textBoxSecurityCode.Text);

            userProfile.accessToken = accessToken.Token;
            userProfile.accessTokenSecret = accessToken.TokenSecret;

            Core.DownloadManager downloadManager = new DownloadManager(userProfile);

            this.Enabled = false;

            downloadManager.DownloadUserBasicData(out teamDetails);

            this.Enabled = true;

            LoadUserBasicData(teamDetails);

            ToggleControls();
        }

        private void buttonOpenURL_Click(object sender, EventArgs e) {
            if (textBoxAuthorizationURL.Text != "") {
                try {
                    System.Diagnostics.Process.Start(textBoxAuthorizationURL.Text);
                } catch {
                    textBoxAuthorizationURL.Text = "";
                }
            }
        }

        private void textBoxSecurityCode_TextChanged(object sender, EventArgs e) {
            if (textBoxSecurityCode.Text != "") {
                buttonTest.Enabled = true;
            } else {
                buttonTest.Enabled = false;
            }
        }

        private void textBoxAuthorizationURL_TextChanged(object sender, EventArgs e) {
            if (textBoxAuthorizationURL.Text != "") {
                buttonOpenURL.Enabled = true;
            } else {
                buttonOpenURL.Enabled = false;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e) {
            UpdateUserProfile();
            EntityManager.SaveUser(userProfile);
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
            this.groupBoxUserCredentials.Text = resourceManager.GetString(Localization.ui_addedituser_groupBoxUserCredentials);
            this.groupBoxUserData.Text = resourceManager.GetString(Localization.ui_addedituser_groupBoxUserData);
            this.labelActivationDate.Text = resourceManager.GetString(Localization.ui_addedituser_labelActivationDate);
            this.labelDataFolder.Text = resourceManager.GetString(Localization.ui_addedituser_labelDataFolder);
            this.labelOAuth.Text = resourceManager.GetString(Localization.ui_addedituser_labelOAuth);
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
            //this.textBoxAuthorizationURL.Text = userProfile.authorizationField;
            this.textBoxDataFolder.Text = userProfile.dataFolderField;
            this.labelActivationDateValue.Text = userProfile.activationDateField.ToString(General.DateTimeFormat);
            this.labelTeamIdValue.Text = userProfile.teamIdField.ToString();
            this.labelYouthTeamIdValue.Text = userProfile.youthTeamIdField.ToString();
        }

        private void ToggleControls() {
            buttonOk.Enabled = true;

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
            //this.userProfile.authorizationField = this.textBoxAuthorizationURL.Text;
            this.userProfile.dataFolderField = this.textBoxDataFolder.Text;
        }

        #endregion

        #region oAuth

        private String GetRequestTokenURL() {
            String AuthorizationURL = String.Empty;
            OAuthSession oauthSession = GetOAuthSession(Chpp.ConsumerKey, Chpp.ConsumerSecret);

            try {
                requestToken = oauthSession.GetRequestToken("GET");
                AuthorizationURL = oauthSession.GetUserAuthorizationUrlForToken(requestToken);
            } catch {
                AuthorizationURL = String.Empty;
            }

            return (AuthorizationURL);
        }

        private IToken ExchangeRequestTokenForAccessToken(String verifier) {
            OAuthSession oauthSession = GetOAuthSession(Chpp.ConsumerKey, Chpp.ConsumerSecret);
            IToken accessToken = oauthSession.ExchangeRequestTokenForAccessToken(requestToken, verifier);

            return (accessToken);
        }

        private OAuthSession GetOAuthSession(String key, String secret) {
            OAuthConsumerContext consumerContext = new OAuthConsumerContext();

            consumerContext.ConsumerKey = key;
            consumerContext.ConsumerSecret = secret;
            consumerContext.SignatureMethod = SignatureMethod.HmacSha1;

            return (new OAuthSession(consumerContext, Chpp.RequestTokenURL, Chpp.AuthorizeURL, Chpp.AccessTokenURL));
        }

        #endregion
    }
}