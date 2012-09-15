using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;
using HM.Resources;
using HM.Resources.Constants;
using HMEntities = HM.Entities.HattrickManager;
using HTEntities = HM.Entities.Hattrick;
using HM.Resources.CustomEvents;

namespace HM.ChppInterface {
    public class ChppManager {
        #region Events

        public event ChppDownloadProgressChangedEventHandler ChppDownloadProgressChanged;

        protected virtual void OnChppDownloadProgressChanged(ChppDownloadProgressChangedEventArgs eventArgs) {
            if (ChppDownloadProgressChanged != null) {
                ChppDownloadProgressChanged(eventArgs);
            }
        }

        #endregion

        #region Properties

        private HMEntities.UserProfiles.User currentUser;
        private DataAccess.DataManager dataManager;
        private string currentDate;
        private int filesDownloaded;
        private int totalFilesToDownload;
        private string path;
        private OAuthInterface oAuth;
        private bool downloadExistingFiles;

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="currentUser">Current active user</param>
        /// <param name="commonFolder">Common files download folder</param>
        public ChppManager(HMEntities.UserProfiles.User currentUser) {
            this.oAuth = new OAuthInterface();
            this.currentUser = currentUser;
            this.dataManager = new HM.DataAccess.DataManager(System.IO.Path.Combine(Directory.GetCurrentDirectory(), FolderNames.CommonDataFolder));
            this.currentDate = DateTime.Now.ToString(HM.Resources.Constants.Chpp.HMDateFormat);
            this.filesDownloaded = 0;
            this.totalFilesToDownload = 0;
            this.path = System.IO.Path.Combine(currentUser.dataFolderField, currentUser.teamIdField.ToString());
            this.downloadExistingFiles = false;
        }

        /// <summary>
        /// Performs file download process
        /// </summary>
        public void Download(bool downloadExisting) {
            try {
                DownloadAll(downloadExisting);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public bool DownloadUserData(out HTEntities.TeamDetails.TeamDetails teamDetails) {
            try {
                bool result = false;
                teamDetails = new HM.Entities.Hattrick.TeamDetails.TeamDetails();

                try {
                    result = true;
                    teamDetails = DownloadUserBasicData();
                } catch {
                    result = false;
                }

                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion

        #region Private Methods

        private void DownloadAll(bool downloadExisting) {
            this.downloadExistingFiles = downloadExisting;
            totalFilesToDownload += 12;

            DownloadArenaDetails();
            DownloadAchievements();
            DownloadClub();
            DownloadEconomy();
            DownloadFans();
            DownloadLeagueDetails();
            DownloadLeagueFixtures();
            DownloadMatches();
            DownloadPlayersData();
            DownloadTeamDetails();
            DownloadTraining();
            DownloadWorldDetails();
        }

        private void DownloadPlayersData() {
            List<HTEntities.Players.Player> playerList = DownloadPlayers();

            foreach (HTEntities.Players.Player currentPlayer in playerList) {
                DownloadPlayerDetails(currentPlayer.playerIdField.ToString());
                DownloadTransfersPlayers(currentPlayer.playerIdField.ToString());
            }
        }

        private void DownloadMatchesArchiveAll() {
            List<HTEntities.MatchesArchive.Match> matchList = new List<HM.Entities.Hattrick.MatchesArchive.Match>();

            DateTime[,] monthDates = GenericFunctions.GetMonthDates(currentUser.activationDateField, DateTime.Now);

            // Replace first and last dates in the array with known start and end dates
            monthDates[0, 0] = currentUser.activationDateField;
            monthDates[monthDates.GetLength(0) - 1, 1] = DateTime.Now;

            for (int i = 0; i < monthDates.GetLength(0); i++) {
                DateTime startDate = monthDates[i, 0];
                DateTime endDate = monthDates[i, 1];
                List<HM.Entities.Hattrick.MatchesArchive.Match> matches = DownloadMatchesArchive(startDate, endDate, false);
                matchList.AddRange(matches);
            }

            foreach (HTEntities.MatchesArchive.Match match in matchList) {
                string path = System.IO.Path.Combine(currentUser.dataFolderField, FolderNames.MatchDetails);
                string fileName = String.Format(FileNames.MatchDetails, match.matchIdField.ToString());

                DownloadMatchDetails(match.matchIdField.ToString());
                DownloadMatchLineup(match.matchIdField.ToString(), match.homeTeamField.homeTeamIdField.ToString());
                DownloadMatchLineup(match.matchIdField.ToString(), match.awayTeamField.awayTeamIdField.ToString());
            }
        }

        private void DownloadMatchesArchiveCurrent() {
            List<HTEntities.MatchesArchive.Match> matchList = new List<HM.Entities.Hattrick.MatchesArchive.Match>();

            List<HM.Entities.Hattrick.MatchesArchive.Match> matches = DownloadMatchesArchive(false);
            matchList.AddRange(matches);

            foreach (HTEntities.MatchesArchive.Match match in matchList) {
                string path = System.IO.Path.Combine(currentUser.dataFolderField, FolderNames.MatchDetails);
                string fileName = String.Format(FileNames.MatchDetails, match.matchIdField.ToString());

                DownloadMatchDetails(match.matchIdField.ToString());
                DownloadMatchLineup(match.matchIdField.ToString(), match.homeTeamField.homeTeamIdField.ToString());
                DownloadMatchLineup(match.matchIdField.ToString(), match.awayTeamField.awayTeamIdField.ToString());
            }
        }

        /// <summary>
        /// Downloads Achievements file
        /// </summary>
        private void DownloadAchievements() {
            try {
                String xmlData = oAuth.AccessProtectedResource(currentUser, QueryString.Achievements);

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.Achievements);
                string fileName = FileNames.Achievements;

                dataManager.WriteFile(xmlData, currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_achievements));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads ArenaDetails file
        /// </summary>
        private void DownloadArenaDetails() {
            try {
                String xmlData = oAuth.AccessProtectedResource(currentUser, QueryString.ArenaDetails);

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.ArenaDetails);
                string fileName = FileNames.ArenaDetails;

                dataManager.WriteFile(xmlData, currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_arenadetails));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads Club file
        /// </summary>
        private void DownloadClub() {
            try {
                String xmlData = oAuth.AccessProtectedResource(currentUser, QueryString.Club);

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.Club);
                string fileName = String.Format(FileNames.Club, currentDate);

                dataManager.WriteFile(xmlData, currentFilePath, fileName);

                //Update LatestFileField
                currentUser.applicationSettingsField.UpdateLastFile(FileType.Club, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_club));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads Economy file
        /// </summary>
        private void DownloadEconomy() {
            try {
                String xmlData = oAuth.AccessProtectedResource(currentUser, QueryString.Economy);

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.Economy);
                string fileName = String.Format(FileNames.Economy, currentDate);

                dataManager.WriteFile(xmlData, currentFilePath, fileName);

                //Update LatestFileField
                currentUser.applicationSettingsField.UpdateLastFile(FileType.Economy, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_economy));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads Fans file
        /// </summary>
        private void DownloadFans() {
            try {
                String xmlData = oAuth.AccessProtectedResource(currentUser, QueryString.Fans);

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.Fans);
                string fileName = FileNames.Fans;

                dataManager.WriteFile(xmlData, currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_fans));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads LeagueDetails file
        /// </summary>
        private void DownloadLeagueDetails() {
            try {
                String xmlData = oAuth.AccessProtectedResource(currentUser, QueryString.LeagueDetails);

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.LeagueDetails);
                string fileName = FileNames.LeagueDetails;

                dataManager.WriteFile(xmlData, currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_leaguedetails));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads LeagueFixtures file
        /// </summary>
        private void DownloadLeagueFixtures() {
            try {
                String xmlData = oAuth.AccessProtectedResource(currentUser, QueryString.LeagueFixtures);

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.LeagueFixtures);
                string fileName = FileNames.LeagueFixtures;

                dataManager.WriteFile(xmlData, currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_leaguefixtures));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads MatchArchive file
        /// </summary>
        /// <param name="firstMatchDate">First match date</param>
        /// <param name="lastMatchDate">Last match date</param>
        private List<HTEntities.MatchesArchive.Match> DownloadMatchesArchive(DateTime firstMatchDate, DateTime lastMatchDate, bool youthTeam) {
            try {
                string teamId = youthTeam ? currentUser.youthTeamIdField.ToString() : currentUser.teamIdField.ToString();
                string dateFormat = General.DateFormat;
                string firstDate = firstMatchDate.ToString(dateFormat) + General.DayTimeStart;
                string lastDate = lastMatchDate.ToString(dateFormat) + General.DayTimeEnd;

                String xmlData = oAuth.AccessProtectedResource(currentUser, CreateParameterURL(QueryString.MatchesArchiveAll, teamId, firstDate, lastDate, youthTeam.ToString()));

                return ((HTEntities.MatchesArchive.MatchesArchive)dataManager.ReadXMLString(xmlData, FileType.MatchesArchive)).teamField.matchListField;
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads MatchArchive file
        /// </summary>
        private List<HTEntities.MatchesArchive.Match> DownloadMatchesArchive(bool youthTeam) {
            try {
                string teamId = youthTeam ? currentUser.youthTeamIdField.ToString() : currentUser.teamIdField.ToString();

                String xmlData = oAuth.AccessProtectedResource(currentUser, CreateParameterURL(QueryString.MatchesArchiveCurrent, teamId, youthTeam.ToString()));

                return ((HTEntities.MatchesArchive.MatchesArchive)dataManager.ReadXMLString(xmlData, FileType.MatchesArchive)).teamField.matchListField;
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads MatchDetails file
        /// </summary>
        /// <param name="matchId">Match id</param>
        private void DownloadMatchDetails(string matchId) {
            try {
                string currentFilePath = System.IO.Path.Combine(path, FolderNames.MatchDetails);
                string fileName = String.Format(FileNames.MatchDetails, matchId);
                bool fileExists = File.Exists(Path.Combine(currentFilePath, fileName));

                if (this.downloadExistingFiles || !fileExists) {
                    String xmlData = oAuth.AccessProtectedResource(currentUser, CreateParameterURL(QueryString.MatchDetails, matchId));
                    dataManager.WriteFile(xmlData, currentFilePath, fileName);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads Matches file
        /// </summary>
        private void DownloadMatches() {
            try {
                String xmlData = oAuth.AccessProtectedResource(currentUser, QueryString.Matches);

                dataManager.SaveMatches(currentUser, xmlData);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_matches));

                //DownloadMatchesArchiveAll();
                DownloadMatchesArchiveCurrent();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private string CreateParameterURL(string query, params string[] parameters) {
            return (string.Format(query, parameters));
        }

        /// <summary>
        /// Downloads MatchLineup file
        /// </summary>
        /// <param name="matchId">Match id</param>
        /// <param name="teamId">Team id</param>
        private void DownloadMatchLineup(string matchId, string teamId) {
            try {
                string currentFilePath = System.IO.Path.Combine(path, FolderNames.MatchLineup);
                string fileName = String.Format(FileNames.MatchLineup, matchId, teamId);
                bool fileExists = File.Exists(Path.Combine(currentFilePath, fileName));

                if (this.downloadExistingFiles || !fileExists) {
                    String xmlData = oAuth.AccessProtectedResource(currentUser, CreateParameterURL(QueryString.MatchLineup, teamId, matchId));
                    dataManager.WriteFile(xmlData, currentFilePath, fileName);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads Players file
        /// </summary>
        private List<HTEntities.Players.Player> DownloadPlayers() {
            try {
                String xmlData = oAuth.AccessProtectedResource(currentUser, QueryString.Players);

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.Players);
                string fileName = String.Format(FileNames.Players, currentDate);

                //Writes the file
                dataManager.WriteFile(xmlData, currentFilePath, fileName);

                //Update LatestPlayerFileField
                currentUser.applicationSettingsField.UpdateLastFile(FileType.Players, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_players));

                //Returns the PlayerList
                return ((HTEntities.Players.Players)dataManager.ReadXMLString(xmlData, FileType.Players)).teamField.playerListField;
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads PlayerDetails file
        /// </summary>
        /// <param name="playerId">Player id</param>
        private void DownloadPlayerDetails(string playerId) {
            try {
                string currentFilePath = System.IO.Path.Combine(path, FolderNames.PlayerDetails);
                string fileName = String.Format(FileNames.PlayerDetails, playerId);
                bool fileExists = File.Exists(Path.Combine(currentFilePath, fileName));

                if (this.downloadExistingFiles || !fileExists) {
                    String xmlData = oAuth.AccessProtectedResource(currentUser, CreateParameterURL(QueryString.PlayerDetails, playerId));
                    dataManager.WriteFile(xmlData, currentFilePath, fileName);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads TeamDetails file
        /// </summary>
        private void DownloadTeamDetails() {
            try {
                String xmlData = oAuth.AccessProtectedResource(currentUser, QueryString.TeamDetails);

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.TeamDetails);
                string fileName = String.Format(FileNames.TeamDetails, currentUser.teamIdField.ToString());

                dataManager.WriteFile(xmlData, currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_teamdetails));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads Training file
        /// </summary>
        private void DownloadTraining() {
            try {
                String xmlData = oAuth.AccessProtectedResource(currentUser, QueryString.Training);

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.Training);
                string fileName = String.Format(FileNames.Training, currentDate);

                dataManager.WriteFile(xmlData, currentFilePath, fileName);

                //Update LatestFileField
                currentUser.applicationSettingsField.UpdateLastFile(FileType.Training, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_training));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads TransfersPlayer file
        /// </summary>
        /// <param name="playerId">Player id</param>
        private void DownloadTransfersPlayers(string playerId) {
            try {
                string currentFilePath = System.IO.Path.Combine(path, FolderNames.TransfersPlayer);
                string fileName = String.Format(FileNames.TransfersPlayer, playerId);
                bool fileExists = File.Exists(Path.Combine(currentFilePath, fileName));

                if (this.downloadExistingFiles || !fileExists) {
                    String xmlData = oAuth.AccessProtectedResource(currentUser, CreateParameterURL(QueryString.TransfersPlayer, playerId));
                    dataManager.WriteFile(xmlData, currentFilePath, fileName);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void DownloadTransfersTeam() {
            try {
            } catch (Exception ex) {
                throw ex;
            }
        }

        private HTEntities.TeamDetails.TeamDetails DownloadUserBasicData() {
            try {
                HTEntities.TeamDetails.TeamDetails teamDetails = new HTEntities.TeamDetails.TeamDetails();
                teamDetails = (HTEntities.TeamDetails.TeamDetails)dataManager.ReadXMLString(oAuth.AccessProtectedResource(currentUser, QueryString.UserBasicData), FileType.TeamDetails);

                return teamDetails;
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads WorldDetails file
        /// </summary>
        private void DownloadWorldDetails() {
            try {
                String xmlData = oAuth.AccessProtectedResource(currentUser, QueryString.WorldDetails);
                dataManager.WriteFile(xmlData, FileNames.WorldDetails);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_worlddetails));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Builds the arguments to raise ChppDownloadProgressChanged event
        /// </summary>
        /// <param name="fileName">File downloaded</param>
        /// <param name="finished">Indicates whether the download process has ended</param>
        /// <returns></returns>
        private ChppDownloadProgressChangedEventArgs BuildReportArguments(string fileName) {
            bool finishedDownloading = false;

            filesDownloaded += 1;

            if (filesDownloaded == totalFilesToDownload) {
                finishedDownloading = true;
            } else {
                finishedDownloading = false;
            }

            return new ChppDownloadProgressChangedEventArgs(fileName, true, this.filesDownloaded, this.totalFilesToDownload, finishedDownloading);
        }

        #endregion
    }
}