using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.Matches
{
    public class Team
    {
        #region Properties

        public uint teamIdField { get; set; }
        public string teamNameField { get; set; }
        public string shortTeamNameField { get; set; }
        public League leagueField { get; set; }
        public LeagueLevelUnit leagueLevelUnitField { get; set; }
        public List<Match> matchListField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Team()
        {
            teamIdField = 0;
            teamNameField = string.Empty;
            matchListField = new List<Match>();
        }

        #endregion
    }
}
