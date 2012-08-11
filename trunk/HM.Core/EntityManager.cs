using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HTEntities = HM.Entities.Hattrick;
using HMEntities = HM.Entities.HattrickManager;
using HMDal = HM.DataAccess;
using HM.Entities.HattrickManager.UserProfiles;
using HM.Resources.Constants;

namespace HM.Core {
    public class EntityManager {
        #region Properties

        private User user;
        private DataManager dataManager;

        #endregion

        #region Methods

        /// <summary>
        /// Creates EntityManager for given user.
        /// </summary>
        /// <param name="user">User profile</param>
        public EntityManager(User user) {
            this.user = user;
            dataManager = new DataManager(user);
        }

        /// <summary>
        /// Gets user achievements.
        /// </summary>
        /// <returns>Achievements object</returns>
        public HTEntities.Achievements.Achievements GetAchievements() {
            try {
                return (HTEntities.Achievements.Achievements)dataManager.ReadFile(FileNames.Achievements, HM.Resources.FileType.Achievements);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Gets arena details.
        /// </summary>
        /// <returns>Arena object</returns>
        public HTEntities.ArenaDetails.ArenaDetails GetArenaDetails() {
            try {
                return (HTEntities.ArenaDetails.ArenaDetails)dataManager.ReadFile(FileNames.ArenaDetails, HM.Resources.FileType.ArenaDetails);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Gets economy.
        /// </summary>
        /// <returns>Economy object</returns>
        public HTEntities.Economy.Economy GetEconomy() {
            try {
                return (HTEntities.Economy.Economy)dataManager.ReadFile(FileNames.Economy, HM.Resources.FileType.Economy);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Gets league details.
        /// </summary>
        /// <returns>LeagueDetails object</returns>
        public HTEntities.LeagueDetails.LeagueDetails GetLeagueDetails() {
            try {
                return (HTEntities.LeagueDetails.LeagueDetails)dataManager.ReadFile(FileNames.LeagueDetails, HM.Resources.FileType.LeagueDetails);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Gets league fixtures.
        /// </summary>
        /// <returns>LeagueFixtures object</returns>
        public HTEntities.LeagueFixtures.LeagueFixtures GetLeagueFixtures() {
            try {
                return (HTEntities.LeagueFixtures.LeagueFixtures)dataManager.ReadFile(FileNames.LeagueFixtures, HM.Resources.FileType.LeagueFixtures);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Gets current matches.
        /// </summary>
        /// <returns>Matches object</returns>
        public HTEntities.Matches.Matches GetMatches() {
            try {
                return (HTEntities.Matches.Matches)dataManager.ReadFile(FileNames.Matches, HM.Resources.FileType.Matches);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Gets team's details.
        /// </summary>
        /// <returns>TeamDetails object</returns>
        public HTEntities.TeamDetails.TeamDetails GetTeamDetails() {
            try {
                return (HTEntities.TeamDetails.TeamDetails)dataManager.ReadFile(string.Format(FileNames.TeamDetails, user.teamIdField), HM.Resources.FileType.TeamDetails);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Gets league details.
        /// </summary>
        /// <returns>WorldDetails object</returns>
        public HTEntities.WorldDetails.WorldDetails GetWorldDetails() {
            try {
                return (HTEntities.WorldDetails.WorldDetails)dataManager.ReadFile(FileNames.WorldDetails, HM.Resources.FileType.WorldDetails);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static void SaveUser(HMEntities.UserProfiles.User user) {
            HMDal.DataManager dataManager = new HMDal.DataManager();

            HMEntities.UserProfiles.UserProfiles userProfiles = dataManager.LoadUserProfiles();
            List<HMEntities.UserProfiles.User> userList = userProfiles.userListField;

            int index = userList.FindIndex(p => p.teamIdField == user.teamIdField);
            if (index == -1) {
                // If profile with this TeamId does not exist, add it...
                userList.Add(user);
            } else {
                // ... otherwise, update its data
                userList[index].CopyData(user);
            }

            dataManager.SaveUserProfiles(userProfiles);
        }

        #endregion

        public HTEntities.Club.Club GetClub() {
            HMDal.DataManager dataManager = new HMDal.DataManager();
            HTEntities.Club.Club club = dataManager.LoadClub(user);
            return club;
        }
    }
}
