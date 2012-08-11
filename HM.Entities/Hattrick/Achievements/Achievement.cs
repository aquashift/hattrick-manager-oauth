using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.Achievements {
    public class Achievement {
        #region Properties

        public uint achievementTypeIdField { get; set; }
        public string achievementTextField { get; set; }
        public AchievementCategory categoryIdField { get; set; }
        public DateTime eventDateField { get; set; }
        public int pointsField { get; set; }
        public bool multilevelField { get; set; }
        public uint numberOfEventsField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Achievement() {
            achievementTypeIdField = 0;
            achievementTextField = string.Empty;
            categoryIdField = AchievementCategory.Unavailable;
            eventDateField = DateTime.MinValue;
            pointsField = 0;
            multilevelField = false;
            numberOfEventsField = 0;
        }

        #endregion
    }
}
