using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails
{
    public class BotStatus
    {
        #region Properties

        public bool isBotField { get; set; }
        
        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public BotStatus()
        {
            this.isBotField = false;
        }
        
        #endregion
    }
}