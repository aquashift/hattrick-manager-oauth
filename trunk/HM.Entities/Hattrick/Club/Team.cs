using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.Club
{
    public class Team
    {
        #region Properties

        public uint teamIdField { get; set; }
        public string teamNameField { get; set; }
        public Specialists specialistsField { get; set; }
        public YouthSquad youthSquadField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Team()
        {
            this.teamIdField = 0;
            this.teamNameField = string.Empty;
            this.specialistsField = new Specialists();
            this.youthSquadField = new YouthSquad();
        }

        #endregion
    }
}
