using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.MatchDetails
{
    public class MatchDetails : HattrickBase
    {
        #region Properties

        public bool userIsSupporterField { get; set; }
        public bool isYouthField { get; set; }
        public Match matchField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public MatchDetails()
        {
            this.userIsSupporterField = false;
            this.isYouthField = false;
            this.matchField = new Match();
        }

        #endregion
    }
}
