using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.Players;

namespace HM.DataAccess.Parsers {
    public class PlayersParser : BaseParser {
        #region Implementation of abstract methods

        protected override HattrickBase CreateEntity() {
            return new Players();
        }

        protected override void ParseSpecificNode(XmlNode xmlNode, HattrickBase entity) {
            try {
                Players players = (Players)entity;

                switch (xmlNode.Name) {
                    case Tags.UserIsSupporter:
                        players.userIsSupporterField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                        break;
                    case Tags.IsYouth:
                        players.isYouthField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                        break;
                    case Tags.ActionType:
                        players.actionTypeField = xmlNode.InnerText;
                        break;
                    case Tags.IsPlayingMatch:
                        players.isPlayingMatchField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                        break;
                    case Tags.Team:
                        if (xmlNode.ChildNodes != null) {
                            players.teamField = ParseTeamNode(xmlNode);
                        }
                        break;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion

        #region Private methods

        private Team ParseTeamNode(XmlNode teamNode) {
            try {
                Team team = new Team();

                foreach (XmlNode xmlNode in teamNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.TeamID:
                            team.teamIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.TeamName:
                            team.teamNameField = xmlNode.InnerText;
                            break;
                        case Tags.PlayerList:
                            if (xmlNode.ChildNodes != null) {
                                team.playerListField = ParsePlayerListNode(xmlNode);
                            }
                            break;
                    }
                }

                return team;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private List<Player> ParsePlayerListNode(XmlNode playerListNode) {
            try {
                List<Player> playerList = new List<Player>();

                foreach (XmlNode xmlPlayerNode in playerListNode.ChildNodes) {
                    if (xmlPlayerNode.ChildNodes != null) {
                        Player player = new Player();

                        foreach (XmlNode xmlNode in xmlPlayerNode.ChildNodes) {
                            switch (xmlNode.Name) {
                                case Tags.PlayerID:
                                    player.playerIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                    break;
                                case Tags.FirstName:
                                    player.firstNameField = xmlNode.InnerText;
                                    break;
                                case Tags.NickName:
                                    player.nickNameField = xmlNode.InnerText;
                                    break;
                                case Tags.LastName:
                                    player.lastNameField = xmlNode.InnerText;
                                    break;
                                case Tags.PlayerNumber:
                                    player.playerNumberField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                                    break;
                                case Tags.Age:
                                    player.ageField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                                    break;
                                case Tags.AgeDays:
                                    player.ageDaysField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                                    break;
                                case Tags.TSI:
                                    player.tsiField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                    break;
                                case Tags.PlayerForm:
                                    player.playerFormField = (PlayerForm)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.Statement:
                                    player.statementField = xmlNode.InnerText;
                                    break;
                                case Tags.Experience:
                                    player.experienceField = (PlayerSkill)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.Leadership:
                                    player.leadershipField = (Leadership)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.Salary:
                                    player.salaryField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                    break;
                                case Tags.IsAbroad:
                                    player.isAbroadField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                                    break;
                                case Tags.Agreeability:
                                    player.agreeabilityField = (Agreeability)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.Aggressiveness:
                                    player.aggressivenessField = (Aggressiveness)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.Honesty:
                                    player.honestyField = (Honesty)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.LeagueGoals:
                                    player.leagueGoalsField = Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.CupGoals:
                                    player.cupGoalsField = Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.FriendliesGoals:
                                    player.friendliesGoalsField = Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.CareerGoals:
                                    player.careerGoalsField = Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.CareerHattricks:
                                    player.careerHattricksField = Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.Specialty:
                                    player.specialtyField = (PlayerSpecialty)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.TransferListed:
                                    player.transferlistedField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                                    break;
                                case Tags.NationalTeamID:
                                    player.nationalTeamIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                    break;
                                case Tags.CountryID:
                                    player.countryIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                    break;
                                case Tags.Caps:
                                    player.capsField = Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.CapsU20:
                                    player.capsU20Field = Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.Cards:
                                    player.cardsField = Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.InjuryLevel:
                                    player.injuryLevelField = Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.StaminaSkill:
                                    player.staminaSkillField = (PlayerSkill)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.KeeperSkill:
                                    player.keeperSkillField = (PlayerSkill)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.PlaymakerSkill:
                                    player.playmakerSkillField = (PlayerSkill)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.ScorerSkill:
                                    player.scorerSkillField = (PlayerSkill)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.PassingSkill:
                                    player.passingSkillField = (PlayerSkill)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.WingerSkill:
                                    player.wingerSkillField = (PlayerSkill)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.DefenderSkill:
                                    player.defenderSkillField = (PlayerSkill)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.SetPiecesSkill:
                                    player.setPiecesSkillField = (PlayerSkill)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.PlayerCategoryId:
                                    player.playerCategoryIdField = (PlayerSkill)Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.TrainerData:
                                    if (xmlNode.ChildNodes != null) {
                                        player.trainerDataField = ParseTrainerDataNode(xmlNode);
                                    }
                                    break;
                            }
                        }

                        playerList.Add(player);
                    }
                }

                return playerList;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private TrainerData ParseTrainerDataNode(XmlNode trainerDataNode) {
            try {
                TrainerData trainerData = new TrainerData();

                foreach (XmlNode xmlNode in trainerDataNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.TrainerType: {
                                trainerData.trainerTypeField = (TrainerType)Convert.ToInt32(xmlNode.InnerText);
                                break;
                            }
                        case Tags.TrainerSkill: {
                                trainerData.trainerSkillField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                                break;
                            }
                    }
                }

                return trainerData;
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion
    }
}