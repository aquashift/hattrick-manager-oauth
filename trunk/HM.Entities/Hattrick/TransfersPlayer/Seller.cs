using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TransfersPlayer
{
    public class Seller
    {
        #region Properties

        public uint sellerTeamIdField { get; set; }
        public string sellerTeamNameField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Seller()
        {
            sellerTeamIdField = 0;
            sellerTeamNameField = string.Empty;
        }

        #endregion
    }
}