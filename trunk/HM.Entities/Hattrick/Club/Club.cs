using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HM.Entities.Hattrick.Club
{
    public class Club : HattrickBase
    {
        #region Properties

        public Team teamField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Club()
        {
            this.teamField = new Team();
        }

        #endregion
    }
}
