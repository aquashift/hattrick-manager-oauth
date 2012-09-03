using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.HattrickManager.Settings {
    public class Position {
        #region Properties

        public string positionNameField { get; set; }
        public Dictionary<HM.Resources.PlayerSkillTypes, int> positionWeights;
        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Position() {
            this.positionNameField = string.Empty;
            this.positionWeights = new Dictionary<Resources.PlayerSkillTypes, int>();
        }

        public void SetPositionWeight(HM.Resources.PlayerSkillTypes skill, int weight) {
            this.positionWeights[skill] = weight;
        }

        public int GetPositionWeight(HM.Resources.PlayerSkillTypes skill) {
            int weight = 0;

            if (this.positionWeights.ContainsKey(skill)) {
                weight = this.positionWeights[skill];
            }

            return (weight);
        }

        #endregion
    }
}
