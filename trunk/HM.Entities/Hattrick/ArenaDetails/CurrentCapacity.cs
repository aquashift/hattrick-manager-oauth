using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.ArenaDetails
{
    public class CurrentCapacity
    {
        #region Properties

        public bool availableField { get; set; }
        public DateTime rebuiltDateField { get; set; }
        public uint terracesField { get; set; }
        public uint basicField { get; set; }
        public uint roofField { get; set; }
        public uint vipField { get; set; }
        public uint totalField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public CurrentCapacity()
        {
            this.availableField = false;
            this.rebuiltDateField = DateTime.MinValue;
            this.terracesField = 0;
            this.basicField = 0;
            this.roofField = 0;
            this.vipField = 0;
            this.totalField = 0;
        }

        #endregion
    }
}