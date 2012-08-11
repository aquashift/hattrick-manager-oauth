using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.LeagueDetails;

namespace HM.DataAccess.Parsers
{
    public class LeagueDetailsParser : BaseParser
    {
        #region Implementations of abstract methods

        protected override HM.Entities.Hattrick.HattrickBase CreateEntity()
        {
            return new LeagueDetails();
        }

        protected override void ParseSpecificNode(System.Xml.XmlNode xmlNode, HM.Entities.Hattrick.HattrickBase entity)
        {
            LeagueDetails leagueDetails = (LeagueDetails)entity;

            switch (xmlNode.Name)
            {
                case Tags.LeagueID:
                    leagueDetails.leagueIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                    break;
                case Tags.LeagueName:
                    leagueDetails.leagueNameField = xmlNode.InnerText;
                    break;
                case Tags.LeagueLevel:
                    leagueDetails.leagueLevelField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                    break;
                case Tags.MaxLevel:
                    leagueDetails.maxLevelField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                    break;
                case Tags.LeagueLevelUnitID:
                    leagueDetails.leagueLevelUnitIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                    break;
                case Tags.LeagueLevelUnitName:
                    leagueDetails.leagueLevelUnitNameField = xmlNode.InnerText;
                    break;
                case Tags.Team:
                    Team newTeam = ParseTeamNode(xmlNode);
                    leagueDetails.teamField[newTeam.positionField - 1] = newTeam;
                    break;
                default:
                    throw new Exception(string.Format("Invalid XML: LeagueDetails.xml", Tags.Team));
            }
        }

        #endregion

        #region Priveate Methods

        private Team ParseTeamNode(XmlNode teamArrayNode)
        {
            Team team = new Team();

            foreach (XmlNode teamNode in teamArrayNode.ChildNodes)
            {
                switch (teamNode.Name)
                {
                    case Tags.TeamID:
                        team.teamIdField = GenericFunctions.ConvertStringToUInt(teamNode.InnerText);
                        break;
                    case Tags.TeamName:
                        team.teamNameField = teamNode.InnerText;
                        break;
                    case Tags.Position:
                        team.positionField = GenericFunctions.ConvertStringToByte(teamNode.InnerText);
                        break;
                    case Tags.PositionChange:
                        team.positionChangeField = (PositionChange)Convert.ToInt32(teamNode.InnerText);
                        break;
                    case Tags.Matches:
                        team.matchesField = GenericFunctions.ConvertStringToByte(teamNode.InnerText);
                        break;
                    case Tags.GoalsFor:
                        team.goalsForField = GenericFunctions.ConvertStringToByte(teamNode.InnerText);
                        break;
                    case Tags.GoalsAgainst:
                        team.goalsAgainstField = GenericFunctions.ConvertStringToByte(teamNode.InnerText);
                        break;
                    case Tags.Points:
                        team.pointsField = GenericFunctions.ConvertStringToByte(teamNode.InnerText);
                        break;
                }
            }
            return team;
        }

        #endregion
    }
}
