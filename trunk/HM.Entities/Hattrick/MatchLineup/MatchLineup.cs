using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.MatchLineup
{
    public class MatchLineup : HattrickBase
    {
        #region Properties

        public uint matchIdField { get; set; }
        public bool isYouthField { get; set; }
        public MatchType matchTypeField { get; set; }
        public DateTime matchDateField { get; set; }
        public HomeTeam homeTeamField { get; set; }
        public AwayTeam awayTeamField { get; set; }
        public Arena arenaField { get; set; }
        public Team teamField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public MatchLineup()
        {
            this.matchIdField = 0;
            this.isYouthField = false;
            this.matchTypeField = MatchType.Unavailable;
            this.matchDateField = DateTime.MinValue;
            this.homeTeamField = new HomeTeam();
            this.awayTeamField = new AwayTeam();
            this.arenaField = new Arena();
            this.teamField = new Team();
        }

        #endregion
    }
}