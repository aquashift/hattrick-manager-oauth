using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.LeagueFixtures;


namespace HM.DataAccess.Parsers
{
    public class LeagueFixturesParser : BaseParser
    {
        #region Implementation of abstract methods

        protected override HM.Entities.Hattrick.HattrickBase CreateEntity()
        {
            return new LeagueFixtures();
        }

        protected override void ParseSpecificNode(System.Xml.XmlNode xmlNode, HM.Entities.Hattrick.HattrickBase entity)
        {
            LeagueFixtures leagueFixtures = (LeagueFixtures)entity;

            switch (xmlNode.Name)
            {
                case Tags.LeagueLevelUnitID:
                    leagueFixtures.leagueLevelUnitIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                    break;
                case Tags.LeagueLevelUnitName:
                    leagueFixtures.leagueLevelUnitNameField = xmlNode.InnerText;
                    break;
                case Tags.Season:
                    leagueFixtures.seasonField = Convert.ToInt32(xmlNode.InnerText);
                    break;
                case Tags.Match:
                    leagueFixtures.matchListField.Add(ParseMatchNode(xmlNode));
                    break;
                default:
                    throw new Exception(string.Format("Invalid XML: LeagueFixtures.xml", Tags.Match));
            }
        }

        #endregion

        #region Private methods

        private Match ParseMatchNode(XmlNode matchNode)
        {
            Match match = new Match();

            foreach (XmlNode xmlNode in matchNode.ChildNodes)
            {
                switch (xmlNode.Name)
                {
                    case Tags.MatchId:
                        match.matchIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                        break;
                    case Tags.MatchRound:
                        match.matchRoundField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                        break;
                    case Tags.HomeTeam:
                        if (xmlNode.ChildNodes != null)
                        {
                            match.homeTeamField = ParseHomeTeamNode(xmlNode);
                        }
                        break;
                    case Tags.AwayTeam:
                        if (xmlNode.ChildNodes != null)
                        {
                            match.awayTeamField = ParseAwayTeamNode(xmlNode);
                        }
                        break;
                    case Tags.MatchDate:
                        match.matchDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
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
        }

        private HomeTeam ParseHomeTeamNode(XmlNode homeTeamNode)
        {
            HomeTeam homeTeam = new HomeTeam();

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

            return homeTeam;
        }

        private AwayTeam ParseAwayTeamNode(XmlNode awayTeamNode)
        {
            AwayTeam awayTeam = new AwayTeam();

            foreach (XmlNode xmlNodeAwayTeam in awayTeamNode.ChildNodes)
            {
                switch (xmlNodeAwayTeam.Name)
                {
                    case Tags.AwayTeamID:
                        awayTeam.awayTeamIdField = GenericFunctions.ConvertStringToUInt(xmlNodeAwayTeam.InnerText);
                        break;
                    case Tags.AwayTeamName:
                        awayTeam.awayTeamNameField = xmlNodeAwayTeam.InnerText;
                        break;
                }
            }
            return awayTeam;
        }

        #endregion
    }
}
