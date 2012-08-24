using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.WorldDetails {
    public class Country {
        #region Properties

        public uint countryIdField { get; set; }
        public string countryNameField { get; set; }
        public string currencyNameField { get; set; }
        public decimal currencyRateField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Country() {
            this.countryIdField = 0;
            this.countryNameField = string.Empty;
            this.currencyNameField = string.Empty;
            this.currencyRateField = 0;
        }

        #endregion
    }
}
