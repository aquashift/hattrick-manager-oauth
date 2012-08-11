using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.Achievements {
    public class Achievements : HattrickBase {
        #region Properties

        public uint maxPointsField { get; set; }
        public List<Achievement> achievementListField { get; set; }
        public int userPointsField {
            get {
                int currentPoints = 0;
                foreach (Achievement currentAchievement in achievementListField) {
                    currentPoints += currentAchievement.pointsField;
                }

                return currentPoints;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Achievements() {
            maxPointsField = 0;
            achievementListField = new List<Achievement>();
        }

        #endregion
    }
}
