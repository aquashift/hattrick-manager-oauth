using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.MatchDetails
{
    public class Event
    {
        #region Properties

        public int indexField { get; set; }
        public byte minuteField { get; set; }
        public uint subjectPlayerIdField { get; set; }
        public uint subjectTeamIdField { get; set; }
        public uint objectPlayerIdField { get; set; }
        public string eventKeyField { get; set; }
        public string eventTextField { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// Constructor
        /// </summary>
        public Event()
        {
            this.indexField = 0;
            this.minuteField = 0;
            this.subjectPlayerIdField = 0;
            this.subjectTeamIdField = 0;
            this.objectPlayerIdField = 0;
            this.eventKeyField = string.Empty;
            this.eventTextField = string.Empty;
        }

        #endregion
    }
}