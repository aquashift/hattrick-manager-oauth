using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.MatchLineup
{
    public class Arena
    {
        #region Properties

        public uint arenaIdField { get; set; }
        public string arenaNameField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Arena()
        {
            this.arenaIdField = 0;
            this.arenaNameField = string.Empty;
        }

        #endregion
    }
}
