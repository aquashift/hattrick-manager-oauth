using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails
{
    public class Cup
    {
        #region Properties

        public bool stillInCupField { get; set; }
        
        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Cup()
        {
            this.stillInCupField = false;
        } 

        #endregion
    }
}
