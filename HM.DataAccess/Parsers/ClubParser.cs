using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.Club;

namespace HM.DataAccess.Parsers
{
    public class ClubParser : BaseParser
    {
        #region Implementation of abstract methods

        protected override HattrickBase CreateEntity()
        {
            return new Club();
        }

        protected override void ParseSpecificNode(XmlNode xmlNode, HattrickBase entity)
        {
            try
            {
                Club club = (Club)entity;

                switch (xmlNode.Name)
                {
                    case Tags.Team:
                        if (xmlNode.ChildNodes != null)
                        {
                            club.teamField = ParseTeamNode(xmlNode);
                        }
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
                        case Tags.Specialists:
                            if (xmlNode.ChildNodes != null)
                            {
                                team.specialistsField = ParseSpecialistsNode(xmlNode);
                            }
                            break;
                        case Tags.YouthSquad:
                            if (xmlNode.ChildNodes != null)
                            {
                                team.youthSquadField = ParseYouthSquadNode(xmlNode);
                            }
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

        private Specialists ParseSpecialistsNode(XmlNode specialistsNode)
        {
            try
            {
                Specialists specialists = new Specialists();

                foreach (XmlNode xmlNode in specialistsNode.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.KeeperTrainers:
                            specialists.keeperTrainersField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.AssistantTrainers:
                            specialists.assistantTrainersField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.Psychologists:
                            specialists.psychologistsField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.PressSpokesmen:
                            specialists.pressSpokesmenField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.Economists:
                            specialists.economistsField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.Physiotherapists:
                            specialists.physiotherapistsField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.Doctors:
                            specialists.doctorsField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                    }
                }

                return specialists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private YouthSquad ParseYouthSquadNode(XmlNode youthSquadNode)
        {
            try
            {
                YouthSquad youthSquad = new YouthSquad();

                foreach (XmlNode xmlNode in youthSquadNode.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.Investment:
                            youthSquad.investmentField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.HasPromoted:
                            youthSquad.hasPromotedField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                            break;
                        case Tags.YouthLevel:
                            youthSquad.youthLevelField = GenericFunctions.ConvertStringToByte(xmlNode.InnerText);
                            break;
                    }
                }

                return youthSquad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
