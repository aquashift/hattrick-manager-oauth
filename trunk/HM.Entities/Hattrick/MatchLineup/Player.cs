using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.MatchLineup
{
    public class Player
    {
        #region Properties

        public uint playerIdField { get; set; }
        public Role roleIdField { get; set; }
        public string playerNameField { get; set; }
        public decimal ratingStarsField { get; set; }
        public decimal ratingStarsEndOfMatchField { get; set; }
        public PositionCode positionCodeField { get; set; }
        public Behaviour behaviourField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Player()
        {
            this.playerIdField = 0;
            this.roleIdField = Role.Unavailable;
            this.playerNameField = string.Empty;
            this.ratingStarsField = 0;
            this.ratingStarsEndOfMatchField = 0;
            this.positionCodeField = PositionCode.Unavailable;
            this.behaviourField = Behaviour.Unavailable;
        }

        #endregion
    }
}