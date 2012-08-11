using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails
{
    public class Fanclub
    {
        #region Properties

        public uint fanclubIdField { get; set; }
        public string fanclubNameField { get; set; }
        
        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Fanclub()
        {
            this.fanclubIdField = 0;
            this.fanclubNameField = string.Empty;
        }
        
        #endregion
    }
}
