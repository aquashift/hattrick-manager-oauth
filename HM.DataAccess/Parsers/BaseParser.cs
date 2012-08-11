using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Entities.Hattrick;
using HM.Resources.Constants;
using HM.Resources;

namespace HM.DataAccess.Parsers
{
    public abstract class BaseParser
    {
        /// <summary>
        /// Parses given XmlDocument and populates a HattrickBase object with data from it.
        /// </summary>
        /// <param name="xmlDocument">XmlDocument to parse</param>
        /// <returns>Populated entity, a HattrickBase (or derived) object</returns>
        public HattrickBase ParseXmlDocument(XmlDocument xmlDocument)
        {
            HattrickBase entity = CreateEntity();

            if (xmlDocument.DocumentElement.ChildNodes != null)
            {
                // Iterates through each node in HattrickData node
                foreach (XmlNode xmlNode in xmlDocument.DocumentElement.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.FileName:
                            entity.fileNameField = xmlNode.InnerText;
                            break;
                        case Tags.Version:
                            entity.versionField = GenericFunctions.ConvertStringToDecimal(xmlNode.InnerText);
                            break;
                        case Tags.UserID:
                            entity.userIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.FetchedDate:
                            entity.fetchedDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                            break;
                        default:
                            ParseSpecificNode(xmlNode, entity);
                            break;
                    }
                }
            }            

            return entity;
        }

        #region Abstract methods

        /// <summary>
        /// Creates appropriate object of class derived from HattrickBase.
        /// </summary>
        /// <returns>New object of class derived from HattrickBase.</returns>
        protected abstract HattrickBase CreateEntity();

        /// <summary>
        /// Reads data from entity-specific XML node and populates entity with the data.
        /// </summary>
        /// <param name="xmlNode">XML node to read</param>
        /// <param name="entity">Entity to populate</param>
        protected abstract void ParseSpecificNode(XmlNode xmlNode, HattrickBase entity);

        #endregion
    }
}
