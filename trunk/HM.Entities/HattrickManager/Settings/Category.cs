using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.HattrickManager.Settings {
    public class Category {
        #region Properties

        public uint categoryIdField { get; set; }
        public string categoryNameField { get; set; }
        public uint categoryColourField { get; set; }
        public bool categoryCheckedField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Category() {
            this.categoryIdField = 0;
            this.categoryNameField = string.Empty;
            this.categoryColourField = 0;
            this.categoryCheckedField = false;
        }

        #endregion

    }
}
