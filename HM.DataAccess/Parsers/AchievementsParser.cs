using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.Achievements;

namespace HM.DataAccess.Parsers
{
    public class AchievementsParser : BaseParser
    {
        #region Implementations of abstract methods

        protected override HattrickBase CreateEntity()
        {
            return new Achievements();
        }

        protected override void ParseSpecificNode(XmlNode xmlNode, HattrickBase entity)
        {
            Achievements achievements = (Achievements)entity;

            switch (xmlNode.Name)
            {
                case Tags.MaxPoints:
                    {
                        achievements.maxPointsField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                        break;
                    }
                case Tags.AchievementList:
                    if (xmlNode.ChildNodes != null)
                    {
                        achievements.achievementListField = ParseAchievementListNode(xmlNode);
                    }
                    break;
                default:
                    throw new Exception(string.Format("Invalid XML: Achievements.xml", Tags.Achievement));
            }
        }

        #endregion

        #region Private methods

        private List<Achievement> ParseAchievementListNode(XmlNode achievementListNode)
        {
            List<Achievement> achievements = new List<Achievement>();
            //Iterates thru each Achievement node in AchievementList node
            foreach (XmlNode xmlNodeAchievementList in achievementListNode.ChildNodes)
            {
                if (xmlNodeAchievementList.ChildNodes != null)
                {
                    achievements.Add(ParseAchievementNode(xmlNodeAchievementList));
                }
            }
            return achievements;
        }

        private Achievement ParseAchievementNode(XmlNode achievementListNode)
        {
            Achievement achievement = new Achievement();

            foreach (XmlNode achievementNode in achievementListNode.ChildNodes)
            {
                switch (achievementNode.Name)
                {
                    case Tags.AchievementTypeID:
                        achievement.achievementTypeIdField = GenericFunctions.ConvertStringToUInt(achievementNode.InnerText);
                        break;
                    case Tags.AchievementText:
                        achievement.achievementTextField = achievementNode.InnerText;
                        break;
                    case Tags.CategoryID:
                        achievement.categoryIdField = (AchievementCategory)Convert.ToInt32(achievementNode.InnerText);
                        break;
                    case Tags.EventDate:
                        achievement.eventDateField = GenericFunctions.ConvertStringToDateTime(achievementNode.InnerText);
                        break;
                    case Tags.Points:
                        achievement.pointsField = Convert.ToInt32(achievementNode.InnerText);
                        break;
                    case Tags.MultiLevel:
                        achievement.multilevelField = GenericFunctions.ConvertStringToBool(achievementNode.InnerText);
                        break;
                    case Tags.NumberOfEvents:
                        achievement.numberOfEventsField = GenericFunctions.ConvertStringToUInt(achievementNode.InnerText);
                        break;
                }
            }
            return achievement;
        }

        #endregion
    }
}
