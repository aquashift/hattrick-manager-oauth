using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.MatchDetails
{
    public class Goal
    {
        #region Properties

        public int indexField { get; set; }
        public uint scorerPlayerIdField { get; set; }
        public string scorerPlayerNameField { get; set; }
        public uint scorerTeamIdField { get; set; }
        public byte scorerHomeGoalsField { get; set; }
        public byte scorerAwayGoalsField { get; set; }
        public byte scorerMinuteField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Goal()
        {
            this.indexField = -1;
            this.scorerPlayerIdField = 0;
            this.scorerPlayerNameField = string.Empty;
            this.scorerTeamIdField = 0;
            this.scorerHomeGoalsField = 0;
            this.scorerAwayGoalsField = 0;
            this.scorerMinuteField = 0;
        }

        #endregion
    }
}
