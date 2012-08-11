using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.MatchDetails
{
    public class Booking
    {
        #region Properties

        public int indexField { get; set; }
        public uint bookingPlayerIdField { get; set; }
        public string bookingPlayerNameField { get; set; }
        public uint bookingTeamIdField { get; set; }
        public int bookingTypeField { get; set; }
        public byte bookingMinuteField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Booking()
        {
            this.indexField = 0;
            this.bookingPlayerIdField = 0;
            this.bookingPlayerNameField = string.Empty;
            this.bookingTeamIdField = 0;
            this.bookingTypeField = -1;
            this.bookingMinuteField = 0;
        }

        #endregion
    }
}
