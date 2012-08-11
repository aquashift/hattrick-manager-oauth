using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.Economy
{
    public class Economy : HattrickBase
    {
        #region Properties

        public Team teamField { get; set; }

        #endregion 

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Economy()
        {
            teamField = new Team();
        }

        #endregion
    }
}
