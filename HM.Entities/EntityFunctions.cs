using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
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

        public static Image GetPlayerValueImage(HM.Entities.HattrickManager.UserProfiles.User user, HM.Entities.Hattrick.Players.Player player, HM.Entities.Hattrick.Players.Internal.PlayersInternal playerInternal, HM.Resources.TableColumns columnID) {
            switch (columnID) {
                case TableColumns.Player_Category:
                    HM.Entities.Hattrick.Players.Internal.PlayerCategories playerCategory = playerInternal.playerCategories.Find(pc => pc.PlayerIDField == player.playerIdField);

                    if (playerCategory != null) {
                        return (HM.Resources.GenericFunctions.GetCategoryImage(user.applicationSettingsField.playerCategoryListField.Find(cat => cat.categoryIdField == playerCategory.PlayerCategoryField).categoryColourField));
                    } else {
                        return (HM.Resources.GenericFunctions.GetCategoryImage(0));
                    }
                case TableColumns.Player_Health:
                    return (HM.Resources.GenericFunctions.GetInjuriesImage(player.injuryLevelField));
                case TableColumns.Player_LastPosition:
                    return (HM.Resources.GenericFunctions.GetPositionImage(player.lastMatchField.roleField));
                case TableColumns.Player_Nationality:
                    return (HM.Resources.GenericFunctions.GetFlagByLeagueId(player.leagueIdField));
                case TableColumns.Player_Warnings:
                    return (HM.Resources.GenericFunctions.GetCardImage(player.cardsField));
            }

            return (null);
        }

        public static string GetPlayerValueName(HM.Entities.HattrickManager.UserProfiles.User user, HM.Entities.Hattrick.Players.Player player, HM.Entities.Hattrick.Players.Internal.PlayersInternal playerInternal, HM.Resources.TableColumns columnID) {
            switch (columnID) {
                case TableColumns.Player_AgeFull:
                    return (player.getFullAge());
                case TableColumns.Player_FirstName:
                    return (player.firstNameField);
                case TableColumns.Player_FullName:
                    return (player.getFullName());
                case TableColumns.Player_LastName:
                    return (player.lastNameField);
            }

            return (string.Empty);
        }

        public static int GetPlayerValueNumber(HM.Entities.HattrickManager.UserProfiles.User user, HM.Entities.Hattrick.Players.Player player, HM.Entities.Hattrick.Players.Internal.PlayersInternal playerInternal, HM.Resources.TableColumns columnID) {
            switch (columnID) {
                case TableColumns.Player_AgeDays:
                    return (Convert.ToInt32(player.ageDaysField));
                case TableColumns.Player_AgeYears:
                    return (Convert.ToInt32(player.ageField));
                case TableColumns.Player_Defending:
                    return (Convert.ToInt32(player.defenderSkillField));
                case TableColumns.Player_Form:
                    return (Convert.ToInt32(player.playerFormField));
                case TableColumns.Player_Health:
                    return (Convert.ToInt32(player.injuryLevelField));
                case TableColumns.Player_ID:
                    return (Convert.ToInt32(player.playerIdField));
                case TableColumns.Player_Keeping:
                    return (Convert.ToInt32(player.keeperSkillField));
                case TableColumns.Player_LastPosition:
                    return (Convert.ToInt32(player.lastMatchField.roleField));
                case TableColumns.Player_Nationality:
                    return (Convert.ToInt32(player.countryIdField));
                case TableColumns.Player_Number:
                    return (Convert.ToInt32(player.playerNumberField));
                case TableColumns.Player_Passing:
                    return (Convert.ToInt32(player.passingSkillField));
                case TableColumns.Player_Playmaking:
                    return (Convert.ToInt32(player.playmakerSkillField));
                case TableColumns.Player_Scoring:
                    return (Convert.ToInt32(player.scorerSkillField));
                case TableColumns.Player_SetPieces:
                    return (Convert.ToInt32(player.setPiecesSkillField));
                case TableColumns.Player_Stamina:
                    return (Convert.ToInt32(player.staminaSkillField));
                case TableColumns.Player_TSI:
                    return (Convert.ToInt32(player.tsiField));
                case TableColumns.Player_Warnings:
                    return (Convert.ToInt32(player.cardsField));
                case TableColumns.Player_Wing:
                    return (Convert.ToInt32(player.wingerSkillField));
            }

            return (0);
        }
    }
}
