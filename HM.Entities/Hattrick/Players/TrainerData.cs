using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.Players
{
    public class TrainerData
    {
        #region Properties

        public TrainerType trainerTypeField { get; set; }
        public byte trainerSkillField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public TrainerData()
        {
            trainerTypeField = TrainerType.Unavailable;
            trainerSkillField = 0;
        }

        #endregion
    }
}