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

        public static double GetPlayerPositionRating(Dictionary<PlayerSkillTypes, double> weights, Dictionary<PlayerSkillTypes, uint> skills) {
            double rating = 0.0;

            foreach (PlayerSkillTypes key in weights.Keys) {
                if (skills.ContainsKey(key)) {
                    rating += (skills[key] * weights[key]);
                }
            }

            return (rating);
        }

        public static Dictionary<PlayerSkillTypes, uint> GetPlayerSkills(Hattrick.Players.Player player) {
            Dictionary<PlayerSkillTypes, uint> skills = new Dictionary<PlayerSkillTypes, uint>();

            skills[PlayerSkillTypes.Defending] = (uint)player.defenderSkillField;
            skills[PlayerSkillTypes.Experience] = (uint)player.experienceField;
            skills[PlayerSkillTypes.Form] = (uint)player.playerFormField;
            skills[PlayerSkillTypes.Keeper] = (uint)player.keeperSkillField;
            skills[PlayerSkillTypes.Leadership] = (uint)player.leadershipField;
            skills[PlayerSkillTypes.Loyalty] = 0;
            skills[PlayerSkillTypes.Passing] = (uint)player.passingSkillField;
            skills[PlayerSkillTypes.Playmaking] = (uint)player.playmakerSkillField;
            skills[PlayerSkillTypes.Scoring] = (uint)player.scorerSkillField;
            skills[PlayerSkillTypes.SetPieces] = (uint)player.setPiecesSkillField;
            skills[PlayerSkillTypes.Stamina] = (uint)player.staminaSkillField;
            skills[PlayerSkillTypes.Winger] = (uint)player.wingerSkillField;

            return (skills);
        }
    }
}
