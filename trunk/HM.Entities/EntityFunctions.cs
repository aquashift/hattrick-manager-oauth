using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities {
    public static class EntityFunctions {
        public static string GetPlayerSkillName(PlayerSkill skill) {
            return (HM.Resources.Constants.EnumNames.PlayerSkillNames[(int)skill]);
        }

        public static string GetPlayerSkillName(PlayerSkill skill, int bonus) {
            int index = (int)skill + bonus;

            if (index > 20) {
                index = 20;
            }

            return (HM.Resources.Constants.EnumNames.PlayerSkillNames[index]);
        }

        public static string GetPlayerFormName(PlayerForm form) {
            return (HM.Resources.Constants.EnumNames.PlayerFormNames[(int)form]);
        }

        public static string GetPlayerLeadershipName(Leadership leadership) {
            return (HM.Resources.Constants.EnumNames.PlayerLeadershipNames[(int)leadership]);
        }

        public static string GetPlayerHealthString(int health) {
            string healthString = "";

            if (health == -1) {
                healthString = "Healthy";
            } else if (health == 0) {
                healthString = "Bruised";
            } else {
                healthString = "Injured (" + health + "w)";
            }

            return (healthString);
        }

        public static double GetPlayerPositionRating(Dictionary<PlayerSkillTypes, double> weights, Dictionary<PlayerSkillTypes, uint> skills) {
            double rating = 0.0;

            foreach (PlayerSkillTypes key in weights.Keys) {
                if (skills.ContainsKey(key)) {
                    double skillLevel = skills[key];

                    // Add Loyalty Bonus
                    skillLevel += (Convert.ToDouble(skills[PlayerSkillTypes.Loyalty]) / Convert.ToDouble(PlayerSkill.Divine));

                    // Add Motherclub Bonus
                    skillLevel += (Convert.ToDouble(skills[PlayerSkillTypes.MotherClubMonus]) / 2.0);

                    // Apply Form Modifier
                    skillLevel *= (Convert.ToDouble(skills[PlayerSkillTypes.Form]) / Convert.ToDouble(PlayerForm.Excellent));

                    rating += (skillLevel * weights[key]);
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
            skills[PlayerSkillTypes.Loyalty] = (uint)player.loyaltyField;
            skills[PlayerSkillTypes.Passing] = (uint)player.passingSkillField;
            skills[PlayerSkillTypes.Playmaking] = (uint)player.playmakerSkillField;
            skills[PlayerSkillTypes.Scoring] = (uint)player.scorerSkillField;
            skills[PlayerSkillTypes.SetPieces] = (uint)player.setPiecesSkillField;
            skills[PlayerSkillTypes.Stamina] = (uint)player.staminaSkillField;
            skills[PlayerSkillTypes.Winger] = (uint)player.wingerSkillField;
            skills[PlayerSkillTypes.MotherClubMonus] = (uint)(player.motherClubField ? 1 : 0);

            return (skills);
        }
    }
}
