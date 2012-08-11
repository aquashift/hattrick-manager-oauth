using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.LeagueFixtures
{
    public class Match
    {
        #region Properties

        public uint matchIdField { get; set; }
        public byte matchRoundField { get; set; }
        public HomeTeam homeTeamField { get; set; }
        public AwayTeam awayTeamField { get; set; }
        public DateTime matchDateField { get; set; }
        public byte homeGoalsField { get; set; }
        public byte awayGoalsField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Match()
        {
            matchIdField = 0;
            matchRoundField = 0;
            homeTeamField = new HomeTeam();
            awayTeamField = new AwayTeam();
            matchDateField = DateTime.MinValue;
            homeGoalsField = 0;
            awayGoalsField = 0;
        }

        #endregion
    }
}
