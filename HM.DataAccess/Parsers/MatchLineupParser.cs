using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.MatchLineup;
using HM.Resources.Constants;
using HM.Resources;
using System.Xml;

namespace HM.DataAccess.Parsers
{
    public class MatchLineupParser : BaseParser
    {
        #region Implementations of abstract methods

        protected override HM.Entities.Hattrick.HattrickBase CreateEntity()
        {
            return new MatchLineup();
        }

        protected override void ParseSpecificNode(XmlNode xmlNode, HattrickBase entity)
        {
            MatchLineup matchLineup = (MatchLineup)entity;

            switch (xmlNode.Name)
            {
                case Tags.MatchId:
                    matchLineup.matchIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                    break;
                case Tags.IsYouth:
                    matchLineup.isYouthField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                    break;
                case Tags.MatchType:
                    matchLineup.matchTypeField = (MatchType)Convert.ToInt32(xmlNode.InnerText);
                    break;
                case Tags.MatchDate:
                    matchLineup.matchDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                    break;
                case Tags.HomeTeam:
                    matchLineup.homeTeamField = ParseHomeTeamNode(xmlNode);
                    break;
                case Tags.AwayTeam:
                    matchLineup.awayTeamField = ParseAwayTeamNode(xmlNode);
                    break;
                case Tags.Arena:
                    matchLineup.arenaField = ParseArenaNode(xmlNode);
                    break;
                case Tags.Team:
                    matchLineup.teamField = ParseTeamNode(xmlNode);
                    break;
            }
        }

        #endregion

        #region Private methods

        private HomeTeam ParseHomeTeamNode(XmlNode homeTeamNode)
        {
            try
            {
                HomeTeam homeTeam = new HomeTeam();

                if (homeTeamNode.ChildNodes != null)
                {
                    foreach (XmlNode xmlNode in homeTeamNode.ChildNodes)
                    {
                        switch (xmlNode.Name)
                        {
                            case Tags.HomeTeamID:
                                homeTeam.homeTeamIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            case Tags.HomeTeamName:
                                homeTeam.homeTeamNameField = xmlNode.InnerText;
                                break;
                        }
                    }
                }

                return homeTeam;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private AwayTeam ParseAwayTeamNode(XmlNode awayTeamNode)
        {
            try
            {
                AwayTeam awayTeam = new AwayTeam();

                if (awayTeamNode.ChildNodes != null)
                {
                    foreach (XmlNode xmlNode in awayTeamNode.ChildNodes)
                    {
                        switch (xmlNode.Name)
                        {
                            case Tags.AwayTeamID:
                                awayTeam.awayTeamIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            case Tags.AwayTeamName:
                                awayTeam.awayTeamNameField = xmlNode.InnerText;
                                break;
                        }
                    }
                }

                return awayTeam;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Arena ParseArenaNode(XmlNode arenaNode)
        {
            try
            {
                Arena arena = new Arena();

                if (arenaNode.ChildNodes != null)
                {
                    foreach (XmlNode xmlNode in arenaNode.ChildNodes)
                    {
                        switch (xmlNode.Name)
                        {
                            case Tags.ArenaID:
                                arena.arenaIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            case Tags.ArenaName:
                                arena.arenaNameField = xmlNode.InnerText;
                                break;
                        }
                    }
                }
                
                return arena;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Team ParseTeamNode(XmlNode teamNode)
        {
            try
            {
                Team team = new Team();

                if (teamNode.ChildNodes != null)
                {
                    foreach (XmlNode xmlNode in teamNode.ChildNodes)
                    {
                        switch (xmlNode.Name)
                        {
                            case Tags.TeamID:
                                team.teamIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            case Tags.TeamName:
                                team.teamNameField = xmlNode.InnerText;
                                break;
                            case Tags.ExperienceLevel:
                                team.experienceLevelField = (PlayerSkill)Convert.ToInt32(xmlNode.InnerText);
                                break;
                            case Tags.Lineup:
                                team.lineupField = ParseLineupNode(xmlNode);
                                break;
                        }
                    }
                }

                return team;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Player> ParseLineupNode(XmlNode lineupNode)
        {
            try
            {
                List<Player> lineup = new List<Player>();

                if (lineupNode.ChildNodes != null)
                {
                    foreach (XmlNode xmlNode in lineupNode.ChildNodes)
                    {
                        switch (xmlNode.Name)
                        {
                            case Tags.Player:
                                lineup.Add(ParsePlayerNode(xmlNode));
                                break;
                        }
                    }
                }

                return lineup;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Player ParsePlayerNode(XmlNode playerNode)
        {
            try
            {
                Player player = new Player();

                if (playerNode.ChildNodes != null)
                {
                    foreach (XmlNode xmlNode in playerNode.ChildNodes)
                    {
                        switch (xmlNode.Name)
                        {
                            case Tags.PlayerID:
                                player.playerIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            case Tags.RoleID:
                                player.roleIdField = (Role)Convert.ToInt32(xmlNode.InnerText);
                                break;
                            case Tags.PlayerName:
                                player.playerNameField = xmlNode.InnerText;
                                break;
                            case Tags.RatingStars:
                                player.ratingStarsField = GenericFunctions.ConvertStringToDecimal(xmlNode.InnerText);
                                break;
                            case Tags.RatingStarsEndOfMatch:
                                player.ratingStarsEndOfMatchField = GenericFunctions.ConvertStringToDecimal(xmlNode.InnerText);
                                break;
                            case Tags.PositionCode:
                                player.positionCodeField = (PositionCode)Convert.ToInt32(xmlNode.InnerText);
                                break;
                            case Tags.Behaviour:
                                player.behaviourField = (Behaviour)Convert.ToInt32(xmlNode.InnerText);
                                break;
                        }
                    }
                }

                return player;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
