using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TransfersPlayer
{
    public class Transfers
    {
        #region Properties

        public DateTime startDateField { get; set; }
        public DateTime endDateField { get; set; }
        public Player playerField { get; set; }
        public List<Transfer> transferField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Transfers()
        {
            startDateField = DateTime.MinValue;
            endDateField = DateTime.MinValue;
            playerField = new Player();
            transferField = new List<Transfer>();
        }

        #endregion
    }
}