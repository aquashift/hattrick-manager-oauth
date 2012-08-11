using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.Economy
{
    public class SponsorsPopularity
    {
        #region Properties

        public bool availableField { get; set; }
        public SponsorsMood sponsorsPopularityField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public SponsorsPopularity()
        {
            availableField = false;
            sponsorsPopularityField = SponsorsMood.Unavailable;
        }

        #endregion
    }
}
