using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.ArenaDetails
{
    public class ExpandedCapacity
    {
        #region Properties

        public bool availableField { get; set; }
        public DateTime expansionDateField { get; set; }
        public int terracesField { get; set; }
        public int basicField { get; set; }
        public int roofField { get; set; }
        public int vipField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public ExpandedCapacity()
        {
            this.availableField = false;
            this.expansionDateField = DateTime.MinValue;
            this.terracesField = 0;
            this.basicField = 0;
            this.roofField = 0;
            this.vipField = 0;
        }

        #endregion
    }
}