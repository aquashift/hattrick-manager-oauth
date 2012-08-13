using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HMEntities = HM.Entities.HattrickManager;
using HM.Resources.Constants;

namespace HM.UserInterface {
    public partial class FormUserSelection : FormBase {
        #region Properties

        public HMEntities.UserProfiles.UserProfiles userProfiles { get; set; }
        public HMEntities.UserProfiles.User selectedUser { get; set; }

        #endregion

        #region Events

        public FormUserSelection() {
            InitializeComponent();

            userProfiles = new Core.DataManager().ReadUserProfilesFile();

            ReloadUsers();

            if (listBoxUserProfiles.Items.Count > 0) {
                listBoxUserProfiles.SelectedIndex = 0;
            }

        }

        private void listBoxUserProfiles_SelectedIndexChanged(object sender, EventArgs e) {
            bool enable = (listBoxUserProfiles.SelectedIndex == -1 ? false : true);

            buttonOk.Enabled = enable;
            buttonEdit.Enabled = enable;
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            using (FormAddEditUser formAddEditUser = new FormAddEditUser()) {
                formAddEditUser.ShowDialog(this);

                if (formAddEditUser.DialogResult == DialogResult.OK) {
                    ReloadUsers();
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e) {
            HMEntities.UserProfiles.User selectedUser = new HM.Entities.HattrickManager.UserProfiles.User();
            int selectedIndex = listBoxUserProfiles.SelectedIndex;

            foreach (HMEntities.UserProfiles.User currentUser in userProfiles.userListField) {
                if (listBoxUserProfiles.SelectedItem.ToString() == currentUser.accessToken) {
                    selectedUser = currentUser;
                    break;
                }
            }

            using (FormAddEditUser formAddEditUser = new FormAddEditUser(selectedUser)) {
                formAddEditUser.ShowDialog(this);

                if (formAddEditUser.DialogResult == DialogResult.OK) {
                    ReloadUsers();
                    // restore selection
                    listBoxUserProfiles.SelectedIndex = selectedIndex;
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e) {
            string selectedLoginname = listBoxUserProfiles.SelectedItem.ToString();

            new Core.DataManager().WriteUserProfilesFile(this.userProfiles);

            foreach (HMEntities.UserProfiles.User currentUser in userProfiles.userListField) {
                if (currentUser.accessToken == selectedLoginname) {
                    this.selectedUser = currentUser;
                    break;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads data into form's controls
        /// </summary>
        private void ReloadUsers() {
            userProfiles = new Core.DataManager().ReadUserProfilesFile();
            listBoxUserProfiles.Items.Clear();

            foreach (HMEntities.UserProfiles.User userProfile in userProfiles.userListField) {
                listBoxUserProfiles.Items.Add(userProfile.accessToken);
            }
        }

        protected override void PopulateLanguage() {
            this.buttonAdd.Text = resourceManager.GetString(Localization.ui_userselection_buttonAdd);
            this.buttonCancel.Text = resourceManager.GetString(Localization.ui_userselection_buttonCancel);
            this.buttonEdit.Text = resourceManager.GetString(Localization.ui_userselection_buttonEdit);
            this.buttonOk.Text = resourceManager.GetString(Localization.ui_userselection_buttonOk);
            this.Text = resourceManager.GetString(Localization.ui_userselection_FormText);
            this.groupBoxUserProfiles.Text = resourceManager.GetString(Localization.ui_userselection_groupBoxUserProfiles);
        }

        #endregion
    }
}