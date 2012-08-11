using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.Matches
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
            leagueLevelUnitIdField = 0;
            leagueLevelUnitNameField = string.Empty;
            leagueLevelField = 0;
        }

        #endregion
    }
}
