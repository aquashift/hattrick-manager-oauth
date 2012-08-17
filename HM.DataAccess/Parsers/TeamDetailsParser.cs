using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.TeamDetails;

namespace HM.DataAccess.Parsers {
    public class TeamDetailsParser : BaseParser {
        #region Implementation of abstract methods

        protected override HattrickBase CreateEntity() {
            return new TeamDetails();
        }

        protected override void ParseSpecificNode(XmlNode xmlNode, HattrickBase entity) {
            try {
                TeamDetails teamDetails = (TeamDetails)entity;

                switch (xmlNode.Name) {
                    case Tags.User:
                        if (xmlNode.ChildNodes != null) {
                            teamDetails.userField = ParseUserNode(xmlNode);
                        }
                        break;
                    case Tags.Team:
                        if (xmlNode.ChildNodes != null) {
                            teamDetails.teamField = ParseTeamNode(xmlNode);
                        }
                        break;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion

        #region Private methods

        private User ParseUserNode(XmlNode userNode) {
            try {
                User user = new User();

                foreach (XmlNode xmlNode in userNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.UserID:
                            user.userIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.Language:
                            if (xmlNode.ChildNodes != null) {
                                user.languageField = ParseLanguageNode(xmlNode);
                            }
                            break;
                        case Tags.HasSupporter:
                            user.hasSupporterField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                            break;
                        case Tags.Loginname:
                            user.loginnameField = xmlNode.InnerText;
                            break;
                        case Tags.Name:
                            user.nameField = xmlNode.InnerText;
                            break;
                        case Tags.ICQ:
                            user.icqField = xmlNode.InnerText;
                            break;
                        case Tags.SignupDate:
                            user.signupDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                            break;
                        case Tags.ActivationDate:
                            user.activationDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                            break;
                        case Tags.LastLoginDate:
                            user.lastLoginDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                            break;
                        case Tags.NationalTeamCoach:
                            if (xmlNode.ChildNodes != null) {
                                user.nationalTeamCoachField = ParseNationalTeamCoachNode(xmlNode);
                            }
                            break;
                    }
                }

                return user;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private Language ParseLanguageNode(XmlNode languageNode) {
            try {
                Language language = new Language();

                foreach (XmlNode xmlNode in languageNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.LanguageID:
                            language.languageIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LanguageName:
                            language.languageNameField = xmlNode.InnerText;
                            break;
                    }
                }

                return language;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private List<NationalTeam> ParseNationalTeamCoachNode(XmlNode nationalTeamNode) {
            try {
                List<NationalTeam> nationalTeamList = new List<NationalTeam>();

                foreach (XmlNode xmlNode in nationalTeamNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.NationalTeam:
                            if (xmlNode.ChildNodes != null) {
                                NationalTeam newNationalTeam = new NationalTeam();

                                foreach (XmlNode xmlNodeNationalTeam in xmlNode.ChildNodes) {
                                    switch (xmlNodeNationalTeam.Name) {
                                        case Tags.NationalTeamID:
                                            newNationalTeam.nationalTeamIdField = GenericFunctions.ConvertStringToUInt(xmlNodeNationalTeam.InnerText);
                                            break;
                                        case Tags.NationalTeamName:
                                            newNationalTeam.nationalTeamNameField = xmlNodeNationalTeam.InnerText;
                                            break;
                                    }
                                }
                                nationalTeamList.Add(newNationalTeam);
                            }
                            break;
                    }
                }

                return nationalTeamList;
            } catch (Exception ex) {
                throw ex;
            }
        }

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
                        case Tags.ShortTeamName:
                            team.shortTeamNameField = xmlNode.InnerText;
                            break;
                        case Tags.Arena:
                            if (xmlNode.ChildNodes != null) {
                                team.arenaField = ParseArenaNode(xmlNode);
                            }
                            break;
                        case Tags.League:
                            if (xmlNode.ChildNodes != null) {
                                team.leagueField = ParseLeagueNode(xmlNode);
                            }
                            break;
                        case Tags.Region:
                            if (xmlNode.ChildNodes != null) {
                                team.regionField = ParseRegionNode(xmlNode);
                            }
                            break;
                        case Tags.Trainer:
                            if (xmlNode.ChildNodes != null) {
                                team.trainerField = ParseTrainerNode(xmlNode);
                            }
                            break;
                        case Tags.HomePage:
                            team.homePageField = xmlNode.InnerText;
                            break;
                        case Tags.Dress:
                            team.dressField = xmlNode.InnerText;
                            break;
                        case Tags.DressAlternate:
                            team.dressAlternateField = xmlNode.InnerText;
                            break;
                        case Tags.LeagueLevelUnit:
                            if (xmlNode.ChildNodes != null) {
                                team.leagueLevelUnitField = ParseLeagueLevelUnitNode(xmlNode);
                            }
                            break;
                        case Tags.BotStatus:
                            if (xmlNode.ChildNodes != null) {
                                team.botStatusField = ParseBotStatusNode(xmlNode);
                            }
                            break;
                        case Tags.Cup:
                            if (xmlNode.ChildNodes != null) {
                                team.cupField = ParseCupNode(xmlNode);
                            }
                            break;
                        case Tags.FriendlyTeamID:
                            team.friendlyTeamIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.NumberOfVictories:
                            team.numberOfVictoriesField = Convert.ToInt32(xmlNode.InnerText);
                            break;
                        case Tags.NumberOfUndefeated:
                            team.numberOfUndefeatedField = Convert.ToInt32(xmlNode.InnerText);
                            break;
                        case Tags.TeamRank:
                            team.teamRankField = Convert.ToInt32(xmlNode.InnerText);
                            break;
                        case Tags.LogoURL:
                            team.logoUrlField = xmlNode.InnerText;
                            break;
                        case Tags.Fanclub:
                            if (xmlNode.ChildNodes != null) {
                                team.fanclubField = ParseFanclubNode(xmlNode);
                            }
                            break;
                        case Tags.Guestbook:
                            if (xmlNode.ChildNodes != null) {
                                team.guestbookField = ParseGuestbookNode(xmlNode);
                            }
                            break;
                        case Tags.PressAnnouncement:
                            if (xmlNode.ChildNodes != null) {
                                team.pressAnnouncementField = ParsePressAnnouncementNode(xmlNode);
                            }
                            break;
                        case Tags.YouthTeamID:
                            team.youthTeamIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.NumberOfVisits:
                            team.numberOfVisitsField = Convert.ToInt32(xmlNode.InnerText);
                            break;
                        case Tags.Flags:
                            team.flagsField = ParseFlagsNode(xmlNode);
                            break;
                    }
                }

                return team;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private Arena ParseArenaNode(XmlNode arenaNode) {
            try {
                Arena arena = new Arena();

                foreach (XmlNode xmlNode in arenaNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.ArenaID:
                            arena.arenaIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.ArenaName:
                            arena.arenaNameField = xmlNode.InnerText;
                            break;
                    }
                }

                return arena;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private Flags ParseFlagsNode(XmlNode flagsNode) {
            try {
                Flags flags = new Flags();

                foreach (XmlNode xmlNode in flagsNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.AwayFlags:
                            flags.awayFlagsField = ParseFlagListNode(xmlNode);
                            break;
                        case Tags.HomeFlags:
                            flags.homeFlagsField = ParseFlagListNode(xmlNode);
                            break;
                    }
                }

                return flags;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private List<Flag> ParseFlagListNode(XmlNode flagsListNode) {
            try {
                List<Flag> flagsList = new List<Flag>();

                foreach (XmlNode xmlNode in flagsListNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.Flag:
                            flagsList.Add(ParseFlagNode(xmlNode));
                            break;
                    }
                }

                return flagsList;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private Flag ParseFlagNode(XmlNode flagsListNode) {
            try {
                Flag flag = new Flag();

                foreach (XmlNode xmlNode in flagsListNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.LeagueId:
                            flag.leagueIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LeagueName:
                            flag.leagueNameField = xmlNode.InnerText;
                            break;
                        case Tags.CountryCode:
                            flag.countryCodeField = xmlNode.InnerText;
                            break;
                    }
                }

                return flag;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private League ParseLeagueNode(XmlNode leagueNode) {
            try {
                League league = new League();

                foreach (XmlNode xmlNode in leagueNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.LeagueID:
                            league.leagueIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LeagueName:
                            league.leagueNameField = xmlNode.InnerText;
                            break;
                    }
                }

                return league;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private Region ParseRegionNode(XmlNode regionNode) {
            try {
                Region region = new Region();

                foreach (XmlNode xmlNode in regionNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.RegionID:
                            region.regionIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.RegionName:
                            region.regionNameField = xmlNode.InnerText;
                            break;
                    }
                }

                return region;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private Trainer ParseTrainerNode(XmlNode trainerNode) {
            try {
                Trainer trainer = new Trainer();

                foreach (XmlNode xmlNode in trainerNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.PlayerID:
                            trainer.playerIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                    }
                }

                return trainer;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private LeagueLevelUnit ParseLeagueLevelUnitNode(XmlNode leagueLevelUnitNode) {
            try {
                LeagueLevelUnit leagueLevelUnit = new LeagueLevelUnit();

                foreach (XmlNode xmlNode in leagueLevelUnitNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.LeagueLevelUnitID:
                            leagueLevelUnit.leagueLevelUnitIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LeagueLevelUnitName:
                            leagueLevelUnit.leagueLevelUnitNameField = xmlNode.InnerText;
                            break;
                        case Tags.LeagueLevelUnit:
                            leagueLevelUnit.leagueLevelField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                            break;
                    }
                }

                return leagueLevelUnit;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private BotStatus ParseBotStatusNode(XmlNode botStatusNode) {
            try {
                BotStatus botStatus = new BotStatus();

                foreach (XmlNode xmlNode in botStatusNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.IsBot:
                            botStatus.isBotField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                            break;
                    }
                }

                return botStatus;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private Cup ParseCupNode(XmlNode cupNode) {
            try {
                Cup cup = new Cup();

                foreach (XmlNode xmlNode in cupNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.StillInCup:
                            cup.stillInCupField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                            break;
                    }
                }

                return cup;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private Fanclub ParseFanclubNode(XmlNode fanclubNode) {
            try {
                Fanclub fanclub = new Fanclub();

                foreach (XmlNode xmlNode in fanclubNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.FanclubID:
                            fanclub.fanclubIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.FanclubName:
                            fanclub.fanclubNameField = xmlNode.InnerText;
                            break;
                    }
                }

                return fanclub;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private Guestbook ParseGuestbookNode(XmlNode guestbookNode) {
            try {
                Guestbook guestbook = new Guestbook();

                foreach (XmlNode xmlNode in guestbookNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.NumberOfGuestbookItems:
                            guestbook.numberOfGuestbookItemsField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                    }
                }

                return guestbook;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private PressAnnouncement ParsePressAnnouncementNode(XmlNode pressAnnouncementNode) {
            try {
                PressAnnouncement pressAnnouncement = new PressAnnouncement();

                foreach (XmlNode xmlNode in pressAnnouncementNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.Subject:
                            pressAnnouncement.subjectField = xmlNode.InnerText;
                            break;
                        case Tags.Body:
                            pressAnnouncement.bodyField = xmlNode.InnerText;
                            break;
                        case Tags.SendDate:
                            pressAnnouncement.sendDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                            break;
                    }
                }

                return pressAnnouncement;
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion
    }
}
