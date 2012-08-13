using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;
using HM.Resources.Constants;
using HMEntities = HM.Entities.HattrickManager;
using HTEntities = HM.Entities.Hattrick;
using HM.Resources.CustomEvents;

namespace HM.Core {
    public class DownloadManager {
        #region Libraries imports

        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        #endregion

        #region Events

        public event ChppDownloadProgressChangedEventHandler ChppDownloadProgressChanged;

        protected virtual void OnChppDownloadProgressChanged(ChppDownloadProgressChangedEventArgs eventArgs) {
            if (ChppDownloadProgressChanged != null) {
                ChppDownloadProgressChanged(eventArgs);
            }
        }

        #endregion

        #region Properties

        private ChppInterface.ChppManager chppManager;

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="currentUser">Current active user</param>
        /// <param name="commonFolder">Common files download folder</param>
        public DownloadManager(HMEntities.UserProfiles.User currentUser) {
            this.chppManager = new HM.ChppInterface.ChppManager(currentUser);
            chppManager.ChppDownloadProgressChanged += new ChppDownloadProgressChangedEventHandler(OnChppDownloadProgressChanged);
        }

        /// <summary>
        /// Performs file download process
        /// </summary>
        public void Download(bool downloadFullMatchesArchive) {
            try {
                if (IsConnected()) {
                    this.chppManager.Download(downloadFullMatchesArchive);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Checks that there is an active internet connection using Windows API
        /// </summary>
        /// <returns>Returns true if the computer is connected to the internet, false if not</returns>
        private static bool IsConnected() {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

        /*
        /// <summary>
        /// Checks if the user has seted a security code
        /// </summary>
        /// <returns>true if he has/false if he hasn't</returns>
        public bool CheckSecurityCode() {
            try {
                if (IsConnected()) {
                    return chppManager.CheckSecurityCode();
                }
                return false;
            } catch (Exception ex) {
                throw ex;
            }
        }
        */

        public bool DownloadUserBasicData(out HTEntities.TeamDetails.TeamDetails teamDetails) {
            try {
                bool result = false;
                teamDetails = new HTEntities.TeamDetails.TeamDetails();

                if (IsConnected()) {
                    result = chppManager.DownloadUserData(out teamDetails);
                }

                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion
    }
}