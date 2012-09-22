using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.Players.Internal {
    public class PlayerCategories {
        #region Properties

        public uint PlayerIDField { get; set; }
        public uint PlayerCategoryField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public PlayerCategories() {
            this.PlayerIDField = 0;
            this.PlayerCategoryField = 0;
        }

        #endregion
    }
}
