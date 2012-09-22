using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.Players.Internal {
    public class PlayersInternal : HattrickBase {
        #region Properties

        public List<PlayerCategories> playerCategories { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public PlayersInternal() {
            fileNameField = string.Empty;
            versionField = 0;
            userIdField = 0;
            fetchedDateField = DateTime.MinValue;
            playerCategories = new List<PlayerCategories>();
        }

        #endregion
        
    }
}
