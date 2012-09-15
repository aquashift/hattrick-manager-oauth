using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.MatchesArchive;

namespace HM.DataAccess.Parsers {
    public class MatchesArchiveParser : BaseParser {
        #region Implementation of abstract methods

        protected override HattrickBase CreateEntity() {
            return new MatchesArchive();
        }

        protected override void ParseSpecificNode(XmlNode xmlNode, HattrickBase entity) {
            try {
                MatchesArchive matchesArchive = (MatchesArchive)entity;

                switch (xmlNode.Name) {
                    case Tags.IsYouth:
                        matchesArchive.isYouthField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                        break;
                    case Tags.Team:
                        if (xmlNode.ChildNodes != null) {
                            matchesArchive.teamField = ParseTeamNode(xmlNode);
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
                        case Tags.MatchList:
                            if (xmlNode.ChildNodes != null) {
                                team.matchListField = ParseMatchListNode(xmlNode);
                            }
                            break;
                    }
                }

                return team;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private List<Match> ParseMatchListNode(XmlNode matchListNode) {
            try {
                List<Match> matchList = new List<Match>();

                foreach (XmlNode xmlNode in matchListNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.Match:
                            if (xmlNode.ChildNodes != null) {
                                matchList.Add(ParseMatchNode(xmlNode));
                            }
                            break;
                    }
                }

                return matchList;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private Match ParseMatchNode(XmlNode matchNode) {
            try {
                Match match = new Match();

                foreach (XmlNode xmlNode in matchNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.MatchId:
                            match.matchIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.HomeTeam:
                            if (xmlNode.ChildNodes != null) {
                                match.homeTeamField = ParseHomeTeamNode(xmlNode);
                            }
                            break;
                        case Tags.AwayTeam:
                            if (xmlNode.ChildNodes != null) {
                                match.awayTeamField = ParseAwayTeamNode(xmlNode);
                            }
                            break;
                        case Tags.MatchDate:
                            match.matchDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                            break;
                        case Tags.MatchType:
                            match.matchTypeField = (MatchType)Convert.ToInt32(xmlNode.InnerText);
                            break;
                        case Tags.HomeGoals:
                            match.homeGoalsField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                            break;
                        case Tags.AwayGoals:
                            match.awayGoalsField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                            break;
                    }
                }

                return match;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private HomeTeam ParseHomeTeamNode(XmlNode homeTeamNode) {
            try {
                HomeTeam homeTeam = new HomeTeam();

                foreach (XmlNode xmlNode in homeTeamNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.HomeTeamID:
                            homeTeam.homeTeamIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.HomeTeamName:
                            homeTeam.homeTeamNameField = xmlNode.InnerText;
                            break;
                    }
                }

                return homeTeam;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private AwayTeam ParseAwayTeamNode(XmlNode awayTeamNode) {
            try {
                AwayTeam awayTeam = new AwayTeam();

                foreach (XmlNode xmlNode in awayTeamNode.ChildNodes) {
                    switch (xmlNode.Name) {
                        case Tags.AwayTeamID:
                            awayTeam.awayTeamIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.AwayTeamName:
                            awayTeam.awayTeamNameField = xmlNode.InnerText;
                            break;
                    }
                }

                return awayTeam;
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion
    }
}
