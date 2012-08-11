using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.LeagueDetails
{
    public class Team
    {
        #region Properties

        public uint teamIdField { get; set; }
        public string teamNameField { get; set; }
        public byte positionField { get; set; }
        public PositionChange positionChangeField { get; set; }
        public byte matchesField { get; set; }
        public byte goalsForField { get; set; }
        public byte goalsAgainstField { get; set; }
        public byte pointsField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Team()
        {
            teamIdField = 0;
            teamNameField = string.Empty;
            positionField = 0;
            positionChangeField = PositionChange.Unavailable;
            matchesField = 0;
            goalsForField = 0;
            goalsAgainstField = 0;
            pointsField = 0;
        }

        #endregion
    }
}
