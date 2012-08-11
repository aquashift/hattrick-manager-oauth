using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.Players
{
    public class Players : HattrickBase
    {
        #region Properties

        public bool userIsSupporterField { get; set; }
        public bool isYouthField { get; set; }
        public string actionTypeField { get; set; }
        public bool isPlayingMatchField { get; set; }
        public Team teamField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Players()
        {
            fileNameField = string.Empty;
            versionField = 0;
            userIdField = 0;
            fetchedDateField = DateTime.MinValue;
            userIsSupporterField = false;
            isYouthField = false;
            actionTypeField = string.Empty;
            isPlayingMatchField = false;
            teamField = new Team();
        }
    }

        #endregion
}