using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.Players {
    public class LastMatchData {
        #region Properties

        public DateTime dateField { get; set; }
        public int matchIdField { get; set; }
        public int minutesPlayedField { get; set; }
        public Role roleField { get; set; }
        public double ratingField { get; set; }
        public double ratingEndOfGameField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public LastMatchData() {
            dateField = DateTime.Now;
            matchIdField = 0;
            minutesPlayedField = 0;
            roleField = Role.Unavailable;
            ratingField = 0;
            ratingEndOfGameField = 0;
        }

        #endregion
    }
}