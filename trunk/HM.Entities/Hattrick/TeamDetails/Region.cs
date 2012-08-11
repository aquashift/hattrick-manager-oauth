using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails
{
    public class Region
    {
        #region Properties

        public uint regionIdField { get; set; }
        public string regionNameField { get; set; }
        
        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Region()
        {
            this.regionIdField = 0;
            this.regionNameField = string.Empty;
        }
        
        #endregion
    }
}
