using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TransfersPlayer
{
    public class Transfer
    {
        #region Properties

        public uint transferIdField { get; set; }
        public DateTime deadlineField { get; set; }
        public Buyer buyerField { get; set; }
        public Seller sellerField { get; set; }
        public uint priceField { get; set; }
        public uint tsiField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Transfer()
        {
            transferIdField = 0;
            deadlineField = DateTime.MinValue;
            buyerField = new Buyer();
            sellerField = new Seller();
            priceField = 0;
            tsiField = 0;
        }

        #endregion
    }
}