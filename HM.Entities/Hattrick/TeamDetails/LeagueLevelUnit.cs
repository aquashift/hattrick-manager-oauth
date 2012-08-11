using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails
{
    public class LeagueLevelUnit
    {
        #region Properties

        public uint leagueLevelUnitIdField { get; set; }
        public string leagueLevelUnitNameField { get; set; }
        public byte leagueLevelField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public LeagueLevelUnit()
        {
            this.leagueLevelUnitIdField = 0;
            this.leagueLevelUnitNameField = string.Empty;
            this.leagueLevelField = 0;
        }

        #endregion
    }
}
