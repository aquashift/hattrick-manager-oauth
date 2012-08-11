using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TransfersPlayer
{
    public class Buyer
    {
        #region Properties

        public uint buyerTeamIdField { get; set; }
        public string buyerTeamNameField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Buyer()
        {
            buyerTeamIdField = 0;
            buyerTeamNameField = string.Empty;
        }

        #endregion
    }
}