using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.Economy
{
    public class SupportersPopularity
    {
        #region Properties

        public bool availableField { get; set; }
        public SupportersMood supportersPopularityField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportersPopularity()
        {
            availableField = false;
            supportersPopularityField = SupportersMood.Unavailable;
        }

        #endregion

    }
}
