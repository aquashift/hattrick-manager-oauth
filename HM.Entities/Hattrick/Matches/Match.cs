using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.Matches
{
    public class Match
    {
        #region Properties

        public uint matchIdField { get; set; }
        public HomeTeam homeTeamField { get; set; }
        public AwayTeam awayTeamField { get; set; }
        public DateTime matchDateField { get; set; }
        public MatchType matchTypeField { get; set; }
        public byte homeGoalsField { get; set; }
        public byte awayGoalsField { get; set; }
        public bool ordersGivenField { get; set; }
        public MatchStatus statusField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Match()
        {
            matchIdField = 0;
            homeTeamField = new HomeTeam();
            awayTeamField = new AwayTeam();
            matchDateField = DateTime.MinValue;
            matchTypeField = MatchType.Unavailable;
            homeGoalsField = 0;
            awayGoalsField = 0;
            ordersGivenField = false;
            statusField = MatchStatus.Finished;
        }

        #endregion
    }
}