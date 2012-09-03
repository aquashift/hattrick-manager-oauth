using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.HattrickManager.Settings {
    public class LastFiles {
        #region Properties

        public HM.Resources.FileType fileTypeField { get; set; }
        public string fileNameField { get; set; }
        public string dateField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public LastFiles() {
            this.fileTypeField = HM.Resources.FileType.Undefined;
            this.fileNameField = string.Empty;
            this.dateField = string.Empty;
        }

        #endregion
    }
}
