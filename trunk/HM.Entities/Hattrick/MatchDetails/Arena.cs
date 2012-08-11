using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.MatchDetails
{
    public class Arena
    {
        #region Properties

        public uint arenaIdField { get; set; }
        public string arenaNameField { get; set; }
        public Weather weatherIdField { get; set; }
        public uint soldTotalField { get; set; }
        public uint soldTerracesField { get; set; }
        public uint soldBasicField { get; set; }
        public uint soldRoofField { get; set; }
        public uint soldVipField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Arena()
        {
            this.arenaIdField = 0;
            this.arenaNameField = string.Empty;
            this.weatherIdField = Weather.Unavailable;
            this.soldTotalField = 0;
            this.soldTerracesField = 0;
            this.soldBasicField = 0;
            this.soldRoofField = 0;
            this.soldVipField = 0;
        }

        #endregion
    }
}