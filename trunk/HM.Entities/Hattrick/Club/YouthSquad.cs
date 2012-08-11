using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.Club
{
    public class YouthSquad
    {
        #region Properties

        public uint investmentField { get; set; }
        public bool hasPromotedField { get; set; }
        public byte youthLevelField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public YouthSquad()
        {
            this.investmentField = 0;
            this.hasPromotedField = false;
            this.youthLevelField = 0;
        }

        #endregion
    }
}
