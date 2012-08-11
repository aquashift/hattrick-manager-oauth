using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.MatchLineup
{
    public class Team
    {
        #region Properties

        public uint teamIdField { get; set; }
        public string teamNameField { get; set; }
        public PlayerSkill experienceLevelField { get; set; }
        public List<Player> lineupField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Team()
        {
            this.teamIdField = 0;
            this.teamNameField = string.Empty;
            this.experienceLevelField = PlayerSkill.Unavailable;
            this.lineupField = new List<Player>();
        }

        #endregion
    }
}