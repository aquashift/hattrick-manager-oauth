using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.Players {
    public class Team {
        #region Properties

        public uint teamIdField { get; set; }
        public string teamNameField { get; set; }
        public List<Player> playerListField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Team() {
            teamIdField = 0;
            teamNameField = string.Empty;
            playerListField = new List<Player>();
        }

        #endregion
    }
}
