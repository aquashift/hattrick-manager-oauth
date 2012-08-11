using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.MatchesArchive
{
    public class MatchesArchive : HattrickBase
    {
        #region Properties

        public bool isYouthField { get; set; }
        public Team teamField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public MatchesArchive()
        {
            isYouthField = false;
            teamField = new Team();
        }

        #endregion
    }
}
