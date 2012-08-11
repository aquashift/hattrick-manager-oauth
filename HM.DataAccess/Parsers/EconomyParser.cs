using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.Economy;

namespace HM.DataAccess.Parsers
{
    public class EconomyParser : BaseParser
    {
        #region Implementations of abstract methods

        protected override HattrickBase CreateEntity()
        {
            return new Economy();
        }

        protected override void ParseSpecificNode(XmlNode xmlNode, HattrickBase entity)
        {
            try
            {
                Economy economy = (Economy)entity;

                switch (xmlNode.Name)
                {
                    case Tags.Team:
                        if (xmlNode.ChildNodes != null)
                        {
                            economy.teamField = ParseTeamNode(xmlNode);
                        }
                        break;
                    default:
                        throw new Exception(string.Format("Invalid XML: Economy.xml"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private methods

        private Team ParseTeamNode(XmlNode teamNode)
        {
            try
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
                        case Tags.Cash:
                            team.cashField = Convert.ToInt32(xmlNode.InnerText);
                            break;
                        case Tags.ExpectedCash:
                            team.expectedCashField = Convert.ToInt32(xmlNode.InnerText);
                            break;
                        case Tags.SponsorsPopularity:
                            team.sponsorsPopularityField = ParseSponsorsPopularityNode(xmlNode);
                            break;
                        case Tags.SupportersPopularity:
                            team.supportersPopularityField = ParseSupportersPopularityNode(xmlNode);
                            break;
                        case Tags.FanClubSize:
                            team.fanClubSizeField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.IncomeSpectators:
                            team.incomeSpectatorsField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.IncomeSponsors:
                            team.incomeSponsorsField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.IncomeFinancial:
                            team.incomeFinancialField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.IncomeTemporary:
                            team.incomeTemporaryField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.IncomeSum:
                            team.incomeSumField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.CostsArena:
                            team.costsArenaField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.CostsPlayers:
                            team.costsPlayersField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.CostsFinancial:
                            team.costsFinancialField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.CostsStaff:
                            team.costsStaffField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.CostsTemporary:
                            team.costsTemporaryField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.CostsYouth:
                            team.costsYouthField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.CostsSum:
                            team.costsSumField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.ExpectedWeeksTotal:
                            team.expectedWeeksTotalField = Convert.ToInt32(xmlNode.InnerText);
                            break;
                        case Tags.LastIncomeSpectators:
                            team.lastIncomeSpectatorsField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LastIncomeSponsors:
                            team.lastIncomeSponsorsField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LastIncomeFinancial:
                            team.lastIncomeFinancialField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LastIncomeTemporary:
                            team.lastIncomeTemporaryField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LastIncomeSum:
                            team.lastIncomeSumField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LastCostsArena:
                            team.lastCostsArenaField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LastCostsPlayers:
                            team.lastCostsPlayersField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LastCostsFinancial:
                            team.lastCostsFinancialField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LastCostsStaff:
                            team.lastCostsStaffField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LastCostsTemporary:
                            team.lastCostsTemporaryField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LastCostsYouth:
                            team.lastCostsYouthField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LastCostsSum:
                            team.lastCostsSumField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.LastWeeksTotal:
                            team.lastWeeksTotalField = Convert.ToInt32(xmlNode.InnerText);
                            break;
                    }
                }

                return team;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private SponsorsPopularity ParseSponsorsPopularityNode(XmlNode sponsorsNode)
        {
            try
            {
                SponsorsPopularity sponsorsPopularity = new SponsorsPopularity();

                sponsorsPopularity.availableField = GenericFunctions.ConvertStringToBool(sponsorsNode.Attributes[Tags.Available].Value);
                sponsorsPopularity.sponsorsPopularityField = (SponsorsMood)Convert.ToInt32(sponsorsNode.InnerText);

                return sponsorsPopularity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private SupportersPopularity ParseSupportersPopularityNode(XmlNode supportersNode)
        {
            try
            {
                SupportersPopularity supportersPopularity = new SupportersPopularity();

                supportersPopularity.availableField = GenericFunctions.ConvertStringToBool(supportersNode.Attributes[Tags.Available].Value);
                supportersPopularity.supportersPopularityField = (SupportersMood)Convert.ToInt32(supportersNode.InnerText);

                return supportersPopularity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
