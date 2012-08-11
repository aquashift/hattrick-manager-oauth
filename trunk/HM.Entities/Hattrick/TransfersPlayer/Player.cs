using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TransfersPlayer
{
    public class Player
    {
        #region Properties

        public uint playerIdField { get; set; }
        public string playerNameField { get; set; }
        public uint teamIdField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Player()
        {
            playerIdField = 0;
            playerNameField = string.Empty;
            teamIdField = 0;
        }

        #endregion
    }
}