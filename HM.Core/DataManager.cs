using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HTEntities = HM.Entities.Hattrick;
using HMEntities = HM.Entities.HattrickManager;
using HM.Resources;
using HM.Resources.Constants;

namespace HM.Core {
    public class DataManager {
        #region Properties

        HMEntities.UserProfiles.User currentUser;
        private DataAccess.DataManager dataManager;
        private string commonFolder;

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commonFolder">Common files folder</param>
        public DataManager() {
            this.commonFolder = Path.Combine(Directory.GetCurrentDirectory(), FolderNames.CommonDataFolder);
            dataManager = new HM.DataAccess.DataManager(commonFolder);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commonFolder">Common files folder</param>
        public DataManager(HMEntities.UserProfiles.User currentUser) {
            this.commonFolder = Path.Combine(Directory.GetCurrentDirectory(), FolderNames.CommonDataFolder);
            this.currentUser = currentUser;
            dataManager = new HM.DataAccess.DataManager(commonFolder);
        }

        public void SaveUserSettings() {
            dataManager.SaveUserSettings(currentUser);
        }

        public void SavePlayerCategories(List<HTEntities.Players.Player> players) {
            dataManager.SavePlayerCategories(players, currentUser);
        }

        /// <summary>
        /// Reads the specified file and return it's content in a HattrickBase entity
        /// </summary>
        /// <param name="fileName">File to read</param>
        /// <param name="fileType">File type</param>
        /// <returns>HattrickBase entity load with file's content</returns>
        public HTEntities.HattrickBase ReadFile(string fileName, FileType fileType) {
            try {
                string folder;

                if (fileType == FileType.WorldDetails) {
                    folder = commonFolder;
                } else {
                    folder = Path.Combine(Path.Combine(currentUser.dataFolderField, currentUser.teamIdField.ToString()), GenericFunctions.GetFolderNameByFileType(fileType));
                }

                fileName = Path.Combine(folder, fileName);

                return dataManager.ReadFile(GetFileStream(fileName), fileType);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Reads the UserProfiles file and return it's content
        /// </summary>
        /// <returns>UserProfiles entity load with file's content</returns>
        public HMEntities.UserProfiles.UserProfiles ReadUserProfilesFile() {
            try {
                string fileName = Path.Combine(commonFolder, FileNames.UserProfiles);
                if (File.Exists(fileName)) {
                    return dataManager.ReadUserProfilesFile(GetFileStream(fileName));
                } else {
                    return new HM.Entities.HattrickManager.UserProfiles.UserProfiles();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Reads the UserSettings file and return it's content
        /// </summary>
        /// <returns>HattrickSettings for the selected user</returns>
        public HMEntities.Settings.HattrickSettings ReadUserSettingsFile(HM.Entities.HattrickManager.UserProfiles.User selectedUser) {
            try {
                HMEntities.Settings.HattrickSettings settings = new HMEntities.Settings.HattrickSettings();
                string path = System.IO.Path.Combine(selectedUser.dataFolderField, selectedUser.teamIdField.ToString());
                path = System.IO.Path.Combine(path, FolderNames.UserSettings);

                string fileName = Path.Combine(path, FileNames.UserSettings);

                if (File.Exists(fileName)) {
                    settings = dataManager.ReadUserSettingsFile(GetFileStream(fileName));
                } else {
                    settings = dataManager.ReadUserSettingsFile(HM.Resources.GenericFunctions.GetDefaultSettings(HM.Resources.SettingTypes.All));
                }

                return (settings);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public Dictionary<uint, uint> ReadPlayerCategoriesFile(HM.Entities.HattrickManager.UserProfiles.User selectedUser) {
            Dictionary<uint, uint> playerCategories = new Dictionary<uint, uint>();
            string path = System.IO.Path.Combine(selectedUser.dataFolderField, selectedUser.teamIdField.ToString());
            path = System.IO.Path.Combine(path, FolderNames.HattrickInternal);

            string fileName = System.IO.Path.Combine(path, FileNames.PlayerData);

            if (System.IO.File.Exists(fileName)) {
                playerCategories = dataManager.ReadPlayerCategoriesFile(GetFileStream(fileName));
            }
            
            return (playerCategories);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the specified file's Stream object
        /// </summary>
        /// <param name="fileName">File to read</param>
        /// <returns>Stream with file's content</returns>
        private Stream GetFileStream(string fileName) {
            try {
                return new FileStream(@fileName, FileMode.Open, FileAccess.Read);
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion
    }
}