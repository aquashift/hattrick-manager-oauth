using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.MatchDetails;
using HM.Resources.Constants;
using HM.Resources;
using System.Xml;

namespace HM.DataAccess.Parsers
{
    public class MatchDetailsParser : BaseParser
    {
        #region Implementation of abstract methods

        protected override HM.Entities.Hattrick.HattrickBase CreateEntity()
        {
            return new MatchDetails();
        }

        protected override void ParseSpecificNode(XmlNode xmlNode, HM.Entities.Hattrick.HattrickBase entity)
        {
            try
            {
                MatchDetails matchDetails = (MatchDetails)entity;

                switch (xmlNode.Name)
                {
                    case Tags.UserIsSupporter:
                        matchDetails.userIsSupporterField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                        break;
                    case Tags.IsYouth:
                        matchDetails.isYouthField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                        break;
                    case Tags.Match:
                        matchDetails.matchField = ParseMatchNode(xmlNode);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private methods

        private Match ParseMatchNode(XmlNode xmlNode)
        {
            try
            {
                Match match = new Match();

                foreach (XmlNode matchNode in xmlNode.ChildNodes)
                {
                    switch (matchNode.Name)
                    {
                        case Tags.MatchId:
                            match.matchIdField = GenericFunctions.ConvertStringToUInt(matchNode.InnerText);
                            break;
                        case Tags.MatchType:
                            match.matchTypeField = (MatchType)Convert.ToInt32(matchNode.InnerText);
                            break;
                        case Tags.MatchDate:
                            match.matchDateField = GenericFunctions.ConvertStringToDateTime(matchNode.InnerText);
                            break;
                        case Tags.FinishedDate:
                            match.finishedDateField = GenericFunctions.ConvertStringToDateTime(matchNode.InnerText);
                            break;
                        case Tags.HomeTeam:
                            match.homeTeamField = ParseHomeTeamNode(matchNode);
                            break;
                        case Tags.AwayTeam:
                            match.awayTeamField = ParseAwayTeamNode(matchNode);
                            break;
                        case Tags.Arena:
                            match.arenaField = ParseArenaNode(matchNode);
                            break;
                        case Tags.Scorers:
                            match.scorersField = ParseScorersNode(matchNode);
                            break;
                        case Tags.Bookings:
                            match.bookingsField = ParseBookingsNode(matchNode);
                            break;
                        case Tags.PossessionFirstHalfHome:
                            match.possesionFirstHalfHomeField = GenericFunctions.ConvertStringToByte(matchNode.InnerText);
                            break;
                        case Tags.PossessionFirstHalfAway:
                            match.possesionFirstHalfAwayField = GenericFunctions.ConvertStringToByte(matchNode.InnerText);
                            break;
                        case Tags.PossessionSecondHalfHome:
                            match.possesionSecondHalfHomeField = GenericFunctions.ConvertStringToByte(matchNode.InnerText);
                            break;
                        case Tags.PossessionSecondHalfAway:
                            match.possesionSecondHalfAwayField = GenericFunctions.ConvertStringToByte(matchNode.InnerText);
                            break;
                        case Tags.EventList:
                            match.eventListField = ParseEventListNode(matchNode);
                            break;
                    }
                }
                return match;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private HomeTeam ParseHomeTeamNode(XmlNode xmlNode)
        {
            try
            {
                HomeTeam homeTeam = new HomeTeam();

                if (xmlNode.ChildNodes != null)
                {
                    foreach (XmlNode homeTeamNode in xmlNode.ChildNodes)
                    {
                        switch (homeTeamNode.Name)
                        {
                            case Tags.HomeTeamID:
                                homeTeam.homeTeamIdField = GenericFunctions.ConvertStringToUInt(homeTeamNode.InnerText);
                                break;
                            case Tags.HomeTeamName:
                                homeTeam.homeTeamNameField = homeTeamNode.InnerText;
                                break;
                            case Tags.Dress:
                                homeTeam.dressField = homeTeamNode.InnerText;
                                break;
                            case Tags.Formation:
                                homeTeam.formationField = homeTeamNode.InnerText;
                                break;
                            case Tags.HomeGoals:
                                homeTeam.homeGoalsField = GenericFunctions.ConvertStringToByte(homeTeamNode.InnerText);
                                break;
                            case Tags.TacticType:
                                homeTeam.tacticTypeField = (TacticType)Convert.ToInt32(homeTeamNode.InnerText);
                                break;
                            case Tags.TacticSkill:
                                homeTeam.tacticSkillField = (TacticSkill)Convert.ToInt32(homeTeamNode.InnerText);
                                break;
                            case Tags.RatingMidfield:
                                homeTeam.ratingMidfieldField = (SectorRating)Convert.ToInt32(homeTeamNode.InnerText);
                                break;
                            case Tags.RatingRightDef:
                                homeTeam.ratingRightDefField = (SectorRating)Convert.ToInt32(homeTeamNode.InnerText);
                                break;
                            case Tags.RatingMidDef:
                                homeTeam.ratingMidDefField = (SectorRating)Convert.ToInt32(homeTeamNode.InnerText);
                                break;
                            case Tags.RatingLeftDef:
                                homeTeam.ratingLeftDefField = (SectorRating)Convert.ToInt32(homeTeamNode.InnerText);
                                break;
                            case Tags.RatingRightAtt:
                                homeTeam.ratingRightAttField = (SectorRating)Convert.ToInt32(homeTeamNode.InnerText);
                                break;
                            case Tags.RatingMidAtt:
                                homeTeam.ratingMidAttField = (SectorRating)Convert.ToInt32(homeTeamNode.InnerText);
                                break;
                            case Tags.RatingLeftAtt:
                                homeTeam.ratingLeftAttField = (SectorRating)Convert.ToInt32(homeTeamNode.InnerText);
                                break;
                            case Tags.TeamAttitude:
                                homeTeam.teamAttitudeField = (TeamAttitude)Convert.ToInt32(homeTeamNode.InnerText);
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

        private AwayTeam ParseAwayTeamNode(XmlNode xmlNode)
        {
            try
            {
                AwayTeam awayTeam = new AwayTeam();

                if (xmlNode.ChildNodes != null)
                {
                    foreach (XmlNode awayTeamNode in xmlNode.ChildNodes)
                    {
                        switch (awayTeamNode.Name)
                        {
                            case Tags.AwayTeamID:
                                awayTeam.awayTeamIdField = GenericFunctions.ConvertStringToUInt(awayTeamNode.InnerText);
                                break;
                            case Tags.AwayTeamName:
                                awayTeam.awayTeamNameField = awayTeamNode.InnerText;
                                break;
                            case Tags.Dress:
                                awayTeam.dressField = awayTeamNode.InnerText;
                                break;
                            case Tags.Formation:
                                awayTeam.formationField = awayTeamNode.InnerText;
                                break;
                            case Tags.AwayGoals:
                                awayTeam.awayGoalsField = GenericFunctions.ConvertStringToByte(awayTeamNode.InnerText);
                                break;
                            case Tags.TacticType:
                                awayTeam.tacticTypeField = (TacticType)Convert.ToInt32(awayTeamNode.InnerText);
                                break;
                            case Tags.TacticSkill:
                                awayTeam.tacticSkillField = (TacticSkill)Convert.ToInt32(awayTeamNode.InnerText);
                                break;
                            case Tags.RatingMidfield:
                                awayTeam.ratingMidfieldField = (SectorRating)Convert.ToInt32(awayTeamNode.InnerText);
                                break;
                            case Tags.RatingRightDef:
                                awayTeam.ratingRightDefField = (SectorRating)Convert.ToInt32(awayTeamNode.InnerText);
                                break;
                            case Tags.RatingMidDef:
                                awayTeam.ratingMidDefField = (SectorRating)Convert.ToInt32(awayTeamNode.InnerText);
                                break;
                            case Tags.RatingLeftDef:
                                awayTeam.ratingLeftDefField = (SectorRating)Convert.ToInt32(awayTeamNode.InnerText);
                                break;
                            case Tags.RatingRightAtt:
                                awayTeam.ratingRightAttField = (SectorRating)Convert.ToInt32(awayTeamNode.InnerText);
                                break;
                            case Tags.RatingMidAtt:
                                awayTeam.ratingMidAttField = (SectorRating)Convert.ToInt32(awayTeamNode.InnerText);
                                break;
                            case Tags.RatingLeftAtt:
                                awayTeam.ratingLeftAttField = (SectorRating)Convert.ToInt32(awayTeamNode.InnerText);
                                break;
                            case Tags.TeamAttitude:
                                awayTeam.teamAttitudeField = (TeamAttitude)Convert.ToInt32(awayTeamNode.InnerText);
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

        private Arena ParseArenaNode(XmlNode xmlNode)
        {
            try
            {
                Arena arena = new Arena();

                if (xmlNode.ChildNodes != null)
                {
                    foreach (XmlNode arenaNode in xmlNode.ChildNodes)
                    {
                        switch (arenaNode.Name)
                        {
                            case Tags.ArenaID:
                                arena.arenaIdField = GenericFunctions.ConvertStringToUInt(arenaNode.InnerText);
                                break;
                            case Tags.ArenaName:
                                arena.arenaNameField = arenaNode.InnerText;
                                break;
                            case Tags.WeatherID:
                                arena.weatherIdField = (Weather)Convert.ToInt32(arenaNode.InnerText);
                                break;
                            case Tags.SoldTotal:
                                arena.soldTotalField = GenericFunctions.ConvertStringToUInt(arenaNode.InnerText);
                                break;
                            case Tags.SoldTerraces:
                                arena.soldTerracesField = GenericFunctions.ConvertStringToUInt(arenaNode.InnerText);
                                break;
                            case Tags.SoldBasic:
                                arena.soldBasicField = GenericFunctions.ConvertStringToUInt(arenaNode.InnerText);
                                break;
                            case Tags.SoldRoof:
                                arena.soldRoofField = GenericFunctions.ConvertStringToUInt(arenaNode.InnerText);
                                break;
                            case Tags.SoldVIP:
                                arena.soldVipField = GenericFunctions.ConvertStringToUInt(arenaNode.InnerText);
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

        private List<Goal> ParseScorersNode(XmlNode xmlNode)
        {
            try
            {
                List<Goal> scorers = new List<Goal>();

                if (xmlNode.ChildNodes != null)
                {
                    foreach (XmlNode scorersNode in xmlNode.ChildNodes)
                    {
                        switch (scorersNode.Name)
                        {
                            case Tags.Goal:
                                scorers.Add(ParseGoalNode(scorersNode));
                                break;
                        }
                    }
                }

                return scorers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Goal ParseGoalNode(XmlNode xmlNode)
        {
            try
            {
                Goal goal = new Goal();

                if (xmlNode.Attributes[Tags.Index] != null)
                {
                    goal.indexField = Convert.ToInt32(xmlNode.Attributes[Tags.Index].Value);
                }
                if (xmlNode.ChildNodes != null)
                {
                    foreach (XmlNode goalNode in xmlNode.ChildNodes)
                    {
                        switch (goalNode.Name)
                        {
                            case Tags.ScorerPlayerID:
                                goal.scorerPlayerIdField = GenericFunctions.ConvertStringToUInt(goalNode.InnerText);
                                break;
                            case Tags.ScorerPlayerName:
                                goal.scorerPlayerNameField = goalNode.InnerText;
                                break;
                            case Tags.ScorerTeamID:
                                goal.scorerTeamIdField = GenericFunctions.ConvertStringToUInt(goalNode.InnerText);
                                break;
                            case Tags.ScorerHomeGoals:
                                goal.scorerHomeGoalsField = GenericFunctions.ConvertStringToByte(goalNode.InnerText);
                                break;
                            case Tags.ScorerAwayGoals:
                                goal.scorerAwayGoalsField = GenericFunctions.ConvertStringToByte(goalNode.InnerText);
                                break;
                            case Tags.ScorerMinute:
                                goal.scorerMinuteField = GenericFunctions.ConvertStringToByte(goalNode.InnerText);
                                break;
                        }
                    }
                }

                return goal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Booking> ParseBookingsNode(XmlNode xmlNode)
        {
            try
            {
                List<Booking> bookings = new List<Booking>();

                if (xmlNode.ChildNodes != null)
                {
                    foreach (XmlNode bookingsNode in xmlNode.ChildNodes)
                    {
                        switch (bookingsNode.Name)
                        {
                            case Tags.Booking:
                                bookings.Add(ParseBookingNode(bookingsNode));
                                break;
                        }
                    }
                }

                return bookings;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Booking ParseBookingNode(XmlNode xmlNode)
        {
            try
            {
                Booking booking = new Booking();

                if (xmlNode.Attributes[Tags.Index] != null)
                {
                    booking.indexField = Convert.ToInt32(xmlNode.Attributes[Tags.Index].Value);
                }

                if (xmlNode.ChildNodes != null)
                {
                    foreach (XmlNode bookingNode in xmlNode.ChildNodes)
                    {
                        switch (bookingNode.Name)
                        {
                            case Tags.BookingPlayerID:
                                booking.bookingPlayerIdField = GenericFunctions.ConvertStringToUInt(bookingNode.InnerText);
                                break;
                            case Tags.BookingPlayerName:
                                booking.bookingPlayerNameField = bookingNode.InnerText;
                                break;
                            case Tags.BookingTeamID:
                                booking.bookingTeamIdField = GenericFunctions.ConvertStringToUInt(bookingNode.InnerText);
                                break;
                            case Tags.BookingType:
                                booking.bookingTypeField = Convert.ToInt32(bookingNode.InnerText);
                                break;
                            case Tags.BookingMinute:
                                booking.bookingMinuteField = GenericFunctions.ConvertStringToByte(bookingNode.InnerText);
                                break;
                        }
                    }
                }

                return booking;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Event> ParseEventListNode(XmlNode xmlNode)
        {
            try
            {
                List<Event> eventList = new List<Event>();

                if (xmlNode.ChildNodes != null)
                {
                    foreach (XmlNode eventListNode in xmlNode.ChildNodes)
                    {
                        switch (eventListNode.Name)
                        {
                            case Tags.Event:
                                eventList.Add(ParseEventNode(eventListNode));
                                break;
                        }
                    }
                }

                return eventList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Event ParseEventNode(XmlNode xmlNode)
        {
            try
            {
                Event eventField = new Event();

                if (xmlNode.Attributes[Tags.Index] != null)
                {
                    eventField.indexField = Convert.ToInt32(xmlNode.Attributes[Tags.Index].Value);
                }

                if (xmlNode.ChildNodes != null)
                {
                    foreach (XmlNode eventNode in xmlNode.ChildNodes)
                    {
                        switch (xmlNode.Name)
                        {
                            case Tags.Minute:
                                eventField.minuteField = GenericFunctions.ConvertStringToByte(eventNode.InnerText);
                                break;
                            case Tags.SubjectPlayerID:
                                eventField.subjectPlayerIdField = GenericFunctions.ConvertStringToUInt(eventNode.InnerText);
                                break;
                            case Tags.SubjectTeamID:
                                eventField.subjectTeamIdField = GenericFunctions.ConvertStringToUInt(eventNode.InnerText);
                                break;
                            case Tags.ObjectPlayerID:
                                eventField.objectPlayerIdField = GenericFunctions.ConvertStringToUInt(eventNode.InnerText);
                                break;
                            case Tags.EventKey:
                                eventField.eventKeyField = eventNode.InnerText;
                                break;
                            case Tags.EventText:
                                eventField.eventTextField = eventNode.InnerText;
                                break;
                        }
                    }
                }

                return eventField;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
