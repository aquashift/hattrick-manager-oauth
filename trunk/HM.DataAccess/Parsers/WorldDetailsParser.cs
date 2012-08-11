using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.WorldDetails;

namespace HM.DataAccess.Parsers
{
    public class WorldDetailsParser : BaseParser
    {
        #region Implementation of abstract methods

        protected override HM.Entities.Hattrick.HattrickBase CreateEntity()
        {
            return new WorldDetails();
        }

        protected override void ParseSpecificNode(System.Xml.XmlNode xmlNode, HM.Entities.Hattrick.HattrickBase entity)
        {
            try
            {
                WorldDetails worldDetails = (WorldDetails)entity;

                switch (xmlNode.Name)
                {
                    case Tags.LeagueList:
                        {
                            if (xmlNode.ChildNodes != null)
                            {
                                worldDetails.leagueListField = ParseLeagueListNode(xmlNode);
                            }
                            break;
                        }
                    default:
                        throw new Exception(string.Format("Invalid XML: WorldDetails.xml"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private methods

        private List<League> ParseLeagueListNode(XmlNode leagueListNode)
        {
            try
            {
                List<League> leagueList = new List<League>();

                foreach (XmlNode leagueNode in leagueListNode.ChildNodes)
                {
                    if (leagueNode.Name == Tags.League && leagueNode.ChildNodes != null)
                    {
                        leagueList.Add(ParseLeagueNode(leagueNode));
                    }
                }

                return leagueList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                        case (Tags.LeagueID):
                            {
                                league.leagueIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            }
                        case (Tags.LeagueName):
                            {
                                league.leagueNameField = xmlNode.InnerText;
                                break;
                            }
                        case (Tags.Season):
                            {
                                league.seasonField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            }
                        case (Tags.MatchRound):
                            {
                                league.matchRoundField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                                break;
                            }
                        case (Tags.ShortName):
                            {
                                league.shortNameField = xmlNode.InnerText;
                                break;
                            }
                        case (Tags.Continent):
                            {
                                league.continentField = xmlNode.InnerText;
                                break;
                            }
                        case (Tags.ZoneName):
                            {
                                league.zoneNameField = xmlNode.InnerText;
                                break;
                            }
                        case (Tags.EnglishName):
                            {
                                league.englishNameField = xmlNode.InnerText;
                                break;
                            }
                        case (Tags.Country):
                            {
                                if (xmlNode.ChildNodes != null)
                                {
                                    league.countryField = ParseCountryNode(xmlNode);
                                }
                                break;
                            }
                        case (Tags.Cup):
                            {
                                if (xmlNode.ChildNodes != null)
                                {
                                    league.cupField = ParseCupNode(xmlNode);
                                }
                                break;
                            }
                        case (Tags.ActiveUsers):
                            {
                                league.activeUsersField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            }
                        case (Tags.WaitingUsers):
                            {
                                league.waitingUsersField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            }
                        case (Tags.TrainingDate):
                            {
                                league.trainingDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                                break;
                            }
                        case (Tags.EconomyDate):
                            {
                                league.economyDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                                break;
                            }
                        case (Tags.CupMatchDate):
                            {
                                league.cupMatchDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                                break;
                            }
                        case (Tags.SeriesMatchDate):
                            {
                                league.seriesMatchDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                                break;
                            }
                        case (Tags.NumberOfLevels):
                            {
                                league.numberOfLevelsField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                                break;
                            }
                    }
                }

                return league;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Country ParseCountryNode(XmlNode countryNode)
        {
            try
            {
                Country country = new Country();

                foreach (XmlNode xmlNode in countryNode.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.CountryID:
                            {
                                country.countryIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            }
                        case Tags.CountryName:
                            {
                                country.countryNameField = xmlNode.InnerText;
                                break;
                            }
                        case Tags.CurrencyName:
                            {
                                country.currencyNameField = xmlNode.InnerText;
                                break;
                            }
                        case Tags.CurrencyRate:
                            {
                                country.currencyRateField = GenericFunctions.ConvertStringToDecimal(xmlNode.InnerText);
                                break;
                            }
                    }
                }

                return country;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Cup ParseCupNode(XmlNode cupNode)
        {
            try
            {
                Cup cup = new Cup();

                foreach (XmlNode xmlNode in cupNode.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.CupID:
                            {
                                cup.cupIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            }
                        case Tags.CupName:
                            {
                                cup.cupNameField = xmlNode.InnerText;
                                break;
                            }
                    }
                }

                return cup;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
