using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.Matches;

namespace HM.DataAccess.Parsers
{
    public class MatchesParser : BaseParser
    {
        #region Implementations of abstract methods

        protected override HattrickBase CreateEntity()
        {
            return new Matches();
        }

        protected override void ParseSpecificNode(XmlNode xmlNode, HattrickBase entity)
        {
            Matches matches = (Matches)entity;

            switch (xmlNode.Name)
            {
                case Tags.IsYouth:
                    matches.isYouth = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                    break;
                case Tags.Team:
                    if (xmlNode.ChildNodes != null)
                    {
                        matches.team = ParseTeamNode(xmlNode);
                    }
                    break;
                default:
                    throw new Exception(string.Format("Invalid XML: Matches.xml", Tags.Team));
            }
        }

        #endregion

        #region Private methods

        private Team ParseTeamNode(XmlNode teamNode)
        {
            Team team = new Team();
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
                    case Tags.ShortTeamName:
                        team.shortTeamNameField = xmlNode.InnerText;
                        break;
                    case Tags.League:
                        team.leagueField = ParseLeagueNode(xmlNode);
                        break;
                    case Tags.LeagueLevelUnit:
                        team.leagueLevelUnitField = ParseLeagueLevelUnitNode(xmlNode);
                        break;
                    case Tags.MatchList:
                        if (xmlNode.ChildNodes != null)
                        {
                            team.matchListField = ParseMatchListNode(xmlNode);
                        }
                        break;
                }
            }
            return team;
        }

        private List<Match> ParseMatchListNode(XmlNode matchListNode)
        {
            List<Match> matchList = new List<Match>();

            foreach (XmlNode matchNode in matchListNode.ChildNodes)
            {
                if (matchNode.Name == Tags.Match && matchNode.ChildNodes != null)
                {
                    matchList.Add(ParseMatchNode(matchNode));
                }
            }
            return matchList;
        }

        private Match ParseMatchNode(XmlNode matchNode)
        {
            Match match = new Match();

            foreach (XmlNode xmlNode in matchNode.ChildNodes)
            {
                switch (xmlNode.Name)
                {
                    case Tags.MatchID:
                        match.matchIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
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
                    case Tags.MatchType:
                        match.matchTypeField = (MatchType)Convert.ToInt32(xmlNode.InnerText);
                        break;
                    case Tags.HomeGoals:
                        match.homeGoalsField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                        break;
                    case Tags.AwayGoals:
                        match.awayGoalsField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                        break;
                    case Tags.Status:
                        string statusString = xmlNode.InnerText;
                        MatchStatus status = MatchStatus.Finished;
                        switch (statusString)
                        {
                            case General.StatusFinished:
                                status = MatchStatus.Finished;
                                break;
                            case General.StatusUpcoming:
                                status = MatchStatus.Upcoming;
                                break;
                        }
                        match.statusField = status;
                        break;
                    case Tags.OrdersGiven:
                        match.ordersGivenField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                        break;
                }
            }

            return match;
        }

        private League ParseLeagueNode(XmlNode leagueNode)
        {
            try
            {
                League league = new League();

                foreach (XmlNode xmlNode in leagueNode.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.LeagueID:
                            league.leagueIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LeagueName:
                            league.leagueNameField = xmlNode.InnerText;
                            break;
                    }
                }

                return league;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private LeagueLevelUnit ParseLeagueLevelUnitNode(XmlNode leagueLevelUnitNode)
        {
            try
            {
                LeagueLevelUnit leagueLevelUnit = new LeagueLevelUnit();

                foreach (XmlNode xmlNode in leagueLevelUnitNode.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.LeagueLevelUnitID:
                            leagueLevelUnit.leagueLevelUnitIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LeagueLevelUnitName:
                            leagueLevelUnit.leagueLevelUnitNameField = xmlNode.InnerText;
                            break;
                        case Tags.LeagueLevel:
                            leagueLevelUnit.leagueLevelField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                            break;
                    }
                }

                return leagueLevelUnit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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