using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails
{
    public class NationalTeam
    {
        #region Properties

        public uint nationalTeamIdField { get; set; }
        public string nationalTeamNameField { get; set; }
        
        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public NationalTeam()
        {
            this.nationalTeamIdField = 0;
            this.nationalTeamNameField = string.Empty;
        }

        #endregion
    }
}
