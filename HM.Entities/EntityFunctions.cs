using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities {
    public static class EntityFunctions {
        public static string GetPlayerSkillName(PlayerSkill skill) {
            return (HM.Resources.Constants.DefaultValues.PlayerSkillNames[(int)skill]);
        }
    }
}
