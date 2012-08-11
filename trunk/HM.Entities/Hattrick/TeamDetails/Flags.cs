using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails
{
    public class Flags
    {
        #region Properties

        public List<Flag> awayFlagsField { get; set; }
        public List<Flag> homeFlagsField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Flags()
        {
            this.awayFlagsField = new List<Flag>();
            this.homeFlagsField = new List<Flag>();
        }

        #endregion
    }
}