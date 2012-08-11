using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HTEntities = HM.Entities.Hattrick;
using HM.Entities.HattrickManager.UserProfiles;
using HM.Resources.Constants;

namespace HM.Core {
    public class CurrencyManager {
        /// <summary>
        /// Converts given amount to user's local currency.
        /// </summary>
        /// <param name="club">User</param>
        /// <param name="amount">Amount to convert</param>
        /// <returns>Amount in user's local currency</returns>
        public static string Convert(User user, uint amount) {
            HTEntities.WorldDetails.League userLeague = GetLeague(user);

            return string.Format(General.Money, (amount / userLeague.countryField.currencyRateField).ToString(General.NoDecimalFormat), userLeague.countryField.currencyNameField);
        }

        /// <summary>
        /// Converts given amount to user's local currency.
        /// </summary>
        /// <param name="club">User</param>
        /// <param name="amount">Amount to convert</param>
        /// <returns>Amount in user's local currency</returns>
        public static string Convert(User user, int amount) {
            HTEntities.WorldDetails.League userLeague = GetLeague(user);

            return string.Format(General.Money, (amount / userLeague.countryField.currencyRateField).ToString(General.NoDecimalFormat), userLeague.countryField.currencyNameField);
        }

        /// <summary>
        /// Gets the user's league
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>League object</returns>
        private static HTEntities.WorldDetails.League GetLeague(User user) {
            EntityManager entityManager = new EntityManager(user);

            HTEntities.WorldDetails.WorldDetails worldDetails = entityManager.GetWorldDetails();
            HTEntities.TeamDetails.TeamDetails teamDetails = entityManager.GetTeamDetails();
            uint leagueId = teamDetails.teamField.leagueField.leagueIdField;
            return worldDetails.leagueListField.Single(l => l.leagueIdField == leagueId);
        }
    }
}
