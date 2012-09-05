using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.HattrickManager.Settings {
    public class Position {
        #region Properties

        public HM.Resources.FieldPositionCode positionID { get; set; }
        public Dictionary<HM.Resources.PlayerSkillTypes, double> positionWeights;
        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Position() {
            this.positionID = HM.Resources.FieldPositionCode.Unavailable;
            this.positionWeights = new Dictionary<Resources.PlayerSkillTypes, double>();
        }

        public void SetPositionWeight(HM.Resources.PlayerSkillTypes skill, double weight) {
            this.positionWeights[skill] = weight;
        }

        public double GetPositionWeight(HM.Resources.PlayerSkillTypes skill) {
            double weight = 0;

            if (this.positionWeights.ContainsKey(skill)) {
                weight = this.positionWeights[skill];
            }

            return (weight);
        }

        #endregion
    }
}
