using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.MatchLineup
{
    public class HomeTeam
    {
        #region Properties

        public uint homeTeamIdField { get; set; }
        public string homeTeamNameField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeTeam()
        {
            this.homeTeamIdField = 0;
            this.homeTeamNameField = string.Empty;
        }

        #endregion
    }
}