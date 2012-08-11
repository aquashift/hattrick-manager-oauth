using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.WorldDetails
{
    public class Cup
    {
        #region Properties

        public uint cupIdField { get; set; }
        public string cupNameField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Cup()
        {
            this.cupIdField = 0;
            this.cupNameField = string.Empty;
        }

        #endregion
    }
}
