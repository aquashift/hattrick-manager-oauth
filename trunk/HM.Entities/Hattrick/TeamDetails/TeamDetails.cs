using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails {
    public class TeamDetails : HattrickBase {
        #region Properties

        public User userField { get; set; }
        public Team teamField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamDetails() {
            this.userField = new User();
            this.teamField = new Team();
        }

        #endregion
    }
}
