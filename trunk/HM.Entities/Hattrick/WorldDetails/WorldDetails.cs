using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.WorldDetails {
    public class WorldDetails : HattrickBase {
        #region Properties

        public List<League> leagueListField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public WorldDetails() {
            this.leagueListField = new List<League>();
        }

        #endregion
    }
}