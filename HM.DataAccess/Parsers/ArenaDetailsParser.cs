using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.ArenaDetails;
using HM.Resources;

namespace HM.DataAccess.Parsers
{
    public class ArenaDetailsParser : BaseParser
    {
        #region Implementation of abstract methods

        protected override HattrickBase CreateEntity()
        {
            return new ArenaDetails();
        }

        protected override void ParseSpecificNode(XmlNode xmlNode, HattrickBase entity)
        {
            try
            {
                ArenaDetails arena = (ArenaDetails)entity;

                switch (xmlNode.Name)
                {
                    case Tags.Arena:
                        arena = ParseArenaNode(xmlNode, arena);
                        break;
                    default:
                        throw new Exception("Invalid XML file.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private methods

        private ArenaDetails ParseArenaNode(XmlNode xmlNodeArena, ArenaDetails arena)
        {
            try
            {
                foreach (XmlNode xmlNode in xmlNodeArena.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.ArenaID:
                            arena.arenaIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.ArenaName:
                            arena.arenaNameField = xmlNode.InnerText;
                            break;
                        case Tags.Team:
                            arena.teamField = ParseTeamNode(xmlNode);
                            break;
                        case Tags.League:
                            arena.leagueField = ParseLeagueNode(xmlNode);
                            break;
                        case Tags.Region:
                            arena.regionField = ParseRegionNode(xmlNode);
                            break;
                        case Tags.CurrentCapacity:
                            arena.currentCapacityField = ParseCurrentCapacityNode(xmlNode);
                            break;
                        case Tags.ExpandedCapacity:
                            arena.expandedCapacityField = ParseExpandedCapacityNode(xmlNode);
                            break;
                    }
                }

                return arena;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Team ParseTeamNode(XmlNode xmlNodeTeam)
        {
            try
            {
                Team team = new Team();

                foreach (XmlNode xmlNode in xmlNodeTeam.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.TeamID:
                            team.teamIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.TeamName:
                            team.teamNameField = xmlNode.InnerText;
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

        private League ParseLeagueNode(XmlNode xmlNodeLeague)
        {
            try
            {
                League league = new League();

                foreach (XmlNode xmlNode in xmlNodeLeague.ChildNodes)
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

        private Region ParseRegionNode(XmlNode xmlNodeRegion)
        {
            try
            {
                Region region = new Region();

                foreach (XmlNode xmlNode in xmlNodeRegion.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.RegionID:
                            region.regionIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.RegionName:
                            region.regionNameField = xmlNode.InnerText;
                            break;
                    }
                }
                return region;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CurrentCapacity ParseCurrentCapacityNode(XmlNode xmlNodeCurrentCapacity)
        {
            try
            {
                CurrentCapacity currentCapacity = new CurrentCapacity();

                if (xmlNodeCurrentCapacity.ChildNodes != null)
                {
                    foreach (XmlNode xmlNode in xmlNodeCurrentCapacity.ChildNodes)
                    {
                        switch (xmlNode.Name)
                        {
                            case Tags.RebuiltDate:
                                if (xmlNode.Attributes[Tags.Available] != null)
                                {
                                    currentCapacity.availableField = GenericFunctions.ConvertStringToBool(xmlNode.Attributes[Tags.Available].Value);

                                    if (currentCapacity.availableField)
                                    {
                                        currentCapacity.rebuiltDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                                    }
                                }
                                break;
                            case Tags.Basic:
                                currentCapacity.basicField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            case Tags.Terraces:
                                currentCapacity.terracesField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            case Tags.Roof:
                                currentCapacity.roofField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            case Tags.VIP:
                                currentCapacity.vipField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            case Tags.Total:
                                currentCapacity.totalField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                        }
                    }
                }
                return currentCapacity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ExpandedCapacity ParseExpandedCapacityNode(XmlNode xmlNodeExpandedCapacity)
        {
            try
            {
                ExpandedCapacity expandedCapacity = new ExpandedCapacity();

                if (xmlNodeExpandedCapacity.ChildNodes != null)
                {
                    if (xmlNodeExpandedCapacity.Attributes[Tags.Available] != null)
                    {
                        expandedCapacity.availableField = GenericFunctions.ConvertStringToBool(xmlNodeExpandedCapacity.Attributes[Tags.Available].Value);
                    }

                    if (expandedCapacity.availableField)
                    {
                        foreach (XmlNode xmlNode in xmlNodeExpandedCapacity.ChildNodes)
                        {
                            switch (xmlNode.Name)
                            {
                                case Tags.ExpansionDate:
                                    expandedCapacity.expansionDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                                    break;
                                case Tags.Basic:
                                    expandedCapacity.basicField = Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.Terraces:
                                    expandedCapacity.terracesField = Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.Roof:
                                    expandedCapacity.roofField = Convert.ToInt32(xmlNode.InnerText);
                                    break;
                                case Tags.VIP:
                                    expandedCapacity.vipField = Convert.ToInt32(xmlNode.InnerText);
                                    break;
                            }
                        }
                    }
                }
                return expandedCapacity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}