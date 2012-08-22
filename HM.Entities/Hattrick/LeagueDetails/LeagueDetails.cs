using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.LeagueDetails {
    public class LeagueDetails : HattrickBase {
        #region Properties

        public uint leagueIdField { get; set; }
        public string leagueNameField { get; set; }
        public byte leagueLevelField { get; set; }
        public byte maxLevelField { get; set; }
        public uint leagueLevelUnitIdField { get; set; }
        public string leagueLevelUnitNameField { get; set; }
        public uint currentMatchRound { get; set; }
        public Team[] teamField { get; set; }
        public byte matchRoundField {
            get {
                return teamField[0].matchesField;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public LeagueDetails() {
            leagueIdField = 0;
            leagueNameField = string.Empty;
            leagueLevelField = 0;
            maxLevelField = 0;
            leagueLevelUnitIdField = 0;
            leagueLevelUnitNameField = string.Empty;
            currentMatchRound = 0;
            teamField = new Team[8];
        }

        #endregion
    }
}