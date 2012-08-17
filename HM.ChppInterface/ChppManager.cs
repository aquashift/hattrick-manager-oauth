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
using HM.Core;

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
        }

        /// <summary>
        /// Performs file download process
        /// </summary>
        public void Download(bool downloadFullMatchesArchive) {
            try {
                totalFilesToDownload += 1;
                DownloadAll(downloadFullMatchesArchive);
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

        private void DownloadAll(bool downloadFullMatchesArchive) {
            totalFilesToDownload += 13;

            DownloadAchievements();
            DownloadArenaDetails();
            DownloadClub();
            DownloadEconomy();
            DownloadFans();
            DownloadLeagueDetails();
            DownloadLeagueFixtures();
            DownloadMatches();

            if (downloadFullMatchesArchive) {
                DownloadMatchesArchiveAll();
            } else {
                DownloadMatchesArchiveCurrent();
            }

            DownloadPlayersData();
            DownloadTeamDetails();
            DownloadTraining();
            DownloadWorldDetails();
        }

        private void DownloadPlayersData() {
            List<HTEntities.Players.Player> playerList = DownloadPlayers();

            totalFilesToDownload += Convert.ToInt32(playerList.Count * 2);

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

            OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_matchesarchive, false));

            totalFilesToDownload += Convert.ToInt32(matchList.Count * 3);

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

            OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_matchesarchive, false));

            totalFilesToDownload += Convert.ToInt32(matchList.Count * 3);

            foreach (HTEntities.MatchesArchive.Match match in matchList) {
                string path = System.IO.Path.Combine(currentUser.dataFolderField, FolderNames.MatchDetails);
                string fileName = String.Format(FileNames.MatchDetails, match.matchIdField.ToString());

                DownloadMatchDetails(match.matchIdField.ToString());
                DownloadMatchLineup(match.matchIdField.ToString(), match.homeTeamField.homeTeamIdField.ToString());
                DownloadMatchLineup(match.matchIdField.ToString(), match.awayTeamField.awayTeamIdField.ToString());
            }
        }

        /*
        /// <summary>
        /// Creates standard UriBuilder for HT XML requests.
        /// </summary>
        /// <returns>UriBuilder initialized with recommended server URI and download path.</returns>
        private UriBuilder GetXmlUriBuilder() {
            UriBuilder uriBuilder = new UriBuilder(recommendedServer);
            uriBuilder.Path += Chpp.ResourcesURL;

            return uriBuilder;
        }
        */
        
        /// <summary>
        /// Downloads Achievements file
        /// </summary>
        private void DownloadAchievements() {
            try {
                HttpWebRequest request = CreateXmlRequest(QueryString.Achievements);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.Achievements);
                string fileName = FileNames.Achievements;

                dataManager.WriteFile(response.GetResponseStream(), currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_achievements, false));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads ArenaDetails file
        /// </summary>
        private void DownloadArenaDetails() {
            try {
                HttpWebRequest request = CreateXmlRequest(QueryString.ArenaDetails);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.ArenaDetails);
                string fileName = FileNames.ArenaDetails;

                dataManager.WriteFile(response.GetResponseStream(), currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_arenadetails, false));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads Club file
        /// </summary>
        private void DownloadClub() {
            try {
                HttpWebRequest request = CreateXmlRequest(QueryString.Club);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.Club);
                string fileName = FileNames.Club;

                dataManager.WriteFile(response.GetResponseStream(), currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_club, false));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads Economy file
        /// </summary>
        private void DownloadEconomy() {
            try {
                HttpWebRequest request = CreateXmlRequest(QueryString.Economy);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.Economy);
                string fileName = FileNames.Economy;

                dataManager.WriteFile(response.GetResponseStream(), currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_economy, false));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads Fans file
        /// </summary>
        private void DownloadFans() {
            try {
                HttpWebRequest request = CreateXmlRequest(QueryString.Fans);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.Fans);
                string fileName = FileNames.Fans;

                dataManager.WriteFile(response.GetResponseStream(), currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_fans, false));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads LeagueDetails file
        /// </summary>
        private void DownloadLeagueDetails() {
            try {
                HttpWebRequest request = CreateXmlRequest(QueryString.LeagueDetails);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.LeagueDetails);
                string fileName = FileNames.LeagueDetails;

                dataManager.WriteFile(response.GetResponseStream(), currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_leaguedetails, false));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads LeagueFixtures file
        /// </summary>
        private void DownloadLeagueFixtures() {
            try {
                HttpWebRequest request = CreateXmlRequest(QueryString.LeagueFixtures);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.LeagueFixtures);
                string fileName = FileNames.LeagueFixtures;

                dataManager.WriteFile(response.GetResponseStream(), currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_leaguefixtures, false));
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

                HttpWebRequest request = CreateXmlRequest(QueryString.MatchesArchiveAll, teamId, firstDate, lastDate, youthTeam.ToString());
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                return ((HTEntities.MatchesArchive.MatchesArchive)dataManager.ReadFile(response.GetResponseStream(), FileType.MatchesArchive)).teamField.matchListField;
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

                HttpWebRequest request = CreateXmlRequest(QueryString.MatchesArchiveCurrent, teamId, youthTeam.ToString());
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                return ((HTEntities.MatchesArchive.MatchesArchive)dataManager.ReadFile(response.GetResponseStream(), FileType.MatchesArchive)).teamField.matchListField;
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
                HttpWebRequest request = CreateXmlRequest(QueryString.MatchDetails, matchId);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.MatchDetails);
                string fileName = String.Format(FileNames.MatchDetails, matchId);

                dataManager.WriteFile(response.GetResponseStream(), currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_matchdetails, false));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads Matches file
        /// </summary>
        private void DownloadMatches() {
            try {
                HttpWebRequest request = CreateXmlRequest(QueryString.Matches);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                dataManager.SaveMatches(currentUser, response.GetResponseStream());

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_matches, false));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Given a query and its parameters, creates a request for HT XML.
        /// </summary>
        /// <param name="query">Query strings</param>
        /// <param name="parameters">Query parameters</param>
        /// <returns>HttpWebRequest ready to be executed</returns>
        private HttpWebRequest CreateXmlRequest(string query, params string[] parameters) {
            // Prepare UriBuilder
            UriBuilder uriBuilder = null;
            uriBuilder.Query = string.Format(query, parameters);

            // Construct request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriBuilder.Uri.AbsoluteUri);
            request.UserAgent = Chpp.UserAgent;
            request.CookieContainer = new CookieContainer();

            return request;
        }

        /// <summary>
        /// Downloads MatchLineup file
        /// </summary>
        /// <param name="matchId">Match id</param>
        /// <param name="teamId">Team id</param>
        private void DownloadMatchLineup(string matchId, string teamId) {
            try {
                HttpWebRequest request = CreateXmlRequest(QueryString.MatchLineup, teamId, matchId);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.MatchLineup);
                string fileName = String.Format(FileNames.MatchLineup, matchId, teamId);

                dataManager.WriteFile(response.GetResponseStream(), currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_matchlineup, false));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads Players file
        /// </summary>
        private List<HTEntities.Players.Player> DownloadPlayers() {
            try {
                HttpWebRequest request = CreateXmlRequest(QueryString.Players);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                //Converts the response Stream in a MemoryStream in order to read it more than once
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd()));

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.Players);
                string fileName = String.Format(FileNames.Players, currentDate);

                //Writes the file
                dataManager.WriteFile(memoryStream, currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_players, false));

                //Rewinds the Stream
                memoryStream.Position = 0;

                //Returns the PlayerList
                return ((HTEntities.Players.Players)dataManager.ReadFile(memoryStream, FileType.Players)).teamField.playerListField;
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
                HttpWebRequest request = CreateXmlRequest(QueryString.PlayerDetails, playerId);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.PlayerDetails);
                string fileName = String.Format(FileNames.PlayerDetails, playerId);

                dataManager.WriteFile(response.GetResponseStream(), currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_playerdetails, false));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads TeamDetails file
        /// </summary>
        private void DownloadTeamDetails() {
            try {
                HttpWebRequest request = CreateXmlRequest(QueryString.TeamDetails, currentUser.teamIdField.ToString());
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.TeamDetails);
                string fileName = String.Format(FileNames.TeamDetails, currentUser.teamIdField.ToString());

                dataManager.WriteFile(response.GetResponseStream(), currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_teamdetails, false));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads Training file
        /// </summary>
        private void DownloadTraining() {
            try {
                HttpWebRequest request = CreateXmlRequest(QueryString.Training);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.Training);
                string fileName = String.Format(FileNames.Training, currentDate);

                dataManager.WriteFile(response.GetResponseStream(), currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_training, false));
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
                HttpWebRequest request = CreateXmlRequest(QueryString.TransfersPlayer, playerId);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string currentFilePath = System.IO.Path.Combine(path, FolderNames.TransfersPlayer);
                string fileName = String.Format(FileNames.TransfersPlayer, playerId);

                dataManager.WriteFile(response.GetResponseStream(), currentFilePath, fileName);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_transfersplayer, false));
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
                teamDetails = (HTEntities.TeamDetails.TeamDetails)dataManager.ParseXMLString(oAuth.AccessProtectedResource(currentUser, QueryString.UserBasicData), FileType.TeamDetails);

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
                HttpWebRequest request = CreateXmlRequest(QueryString.WorldDetails);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                dataManager.WriteFile(response.GetResponseStream(), FileNames.WorldDetails);

                OnChppDownloadProgressChanged(BuildReportArguments(Localization.hm_download_worlddetails, false));
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
        private ChppDownloadProgressChangedEventArgs BuildReportArguments(string fileName, bool finished) {
            filesDownloaded += 1;
            return new ChppDownloadProgressChangedEventArgs(fileName, true, this.filesDownloaded, this.totalFilesToDownload, finished);
        }

        #endregion
    }
}