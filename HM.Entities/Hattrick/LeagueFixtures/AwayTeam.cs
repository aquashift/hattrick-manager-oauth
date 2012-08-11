using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.LeagueFixtures
{
    public class AwayTeam
    {
        #region Properties

        public uint awayTeamIdField { get; set; }
        public string awayTeamNameField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public AwayTeam()
        {
            awayTeamIdField = 0;
            awayTeamNameField = string.Empty;
        }

        #endregion
    }
}