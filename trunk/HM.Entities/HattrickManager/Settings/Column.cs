using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.HattrickManager.Settings {
    public class Column {
        #region Properties

        public uint columnIDField { get; set; }
        public uint statisticIDField { get; set; }
        public string titleField { get; set; }
        public uint widthField { get; set; }
        public HM.Resources.ColumnDisplayType displayTypeField { get; set; }
        public HM.Resources.ColumnAlignment alignmentField { get; set; }
        public bool displayColumnField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Column() {
            this.columnIDField = 0;
            this.statisticIDField = 0;
            this.titleField = string.Empty;
            this.widthField = 100;
            this.displayTypeField = HM.Resources.ColumnDisplayType.Value;
            this.alignmentField = HM.Resources.ColumnAlignment.Left;
            this.displayColumnField = false;
        }

        #endregion
    }
}
