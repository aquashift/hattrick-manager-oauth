using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.WorldDetails {
    public class WorldDetails : HattrickBase {
        #region Properties

        public List<League> leagueListField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public WorldDetails() {
            this.leagueListField = new List<League>();
        }

        public uint GetLeagueIDFromCountryID(uint countryID) {
            uint id = 0;

            foreach (League league in leagueListField) {
                if (league.countryField.countryIdField == countryID) {
                    id = league.leagueIdField;
                    break;
                }
            }

            return (id);
        }

        #endregion
    }
}