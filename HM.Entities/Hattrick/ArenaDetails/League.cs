using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.ArenaDetails
{
    public class League
    {
        #region Properties

        public uint leagueIdField { get; set; }
        public string leagueNameField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public League()
        {
            this.leagueIdField = 0;
            this.leagueNameField = string.Empty;
        }

        #endregion
    }
}