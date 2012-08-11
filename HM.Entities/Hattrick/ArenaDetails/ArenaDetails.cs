using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.ArenaDetails {
    public class ArenaDetails : HattrickBase {
        #region Properties

        public uint arenaIdField { get; set; }
        public string arenaNameField { get; set; }
        public Team teamField { get; set; }
        public League leagueField { get; set; }
        public Region regionField { get; set; }
        public CurrentCapacity currentCapacityField { get; set; }
        public ExpandedCapacity expandedCapacityField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public ArenaDetails() {
            this.arenaIdField = 0;
            this.arenaNameField = string.Empty;
            this.teamField = new Team();
            this.leagueField = new League();
            this.regionField = new Region();
            this.currentCapacityField = new CurrentCapacity();
            this.expandedCapacityField = new ExpandedCapacity();
        }

        #endregion
    }
}