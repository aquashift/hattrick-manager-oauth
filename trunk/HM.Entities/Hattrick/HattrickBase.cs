using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick
{
    using System.IO;
    using System.Xml;
    using HM.Resources.Constants;
    using HM.Resources;

    public abstract class HattrickBase
    {
        #region Properties

        public string fileNameField { get; set; }
        public decimal versionField { get; set; }
        public uint userIdField { get; set; }
        public DateTime fetchedDateField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor for initializing all the common properties of HT data.
        /// </summary>
        public HattrickBase()
        {
            this.fileNameField = string.Empty;
            this.versionField = 0;
            this.userIdField = 0;
            this.fetchedDateField = DateTime.MinValue;
        }

        /// <summary>
        /// Reads the xml document and populates internal state with its data.
        /// </summary>
        /// <param name="xmlDocument">Xml document</param>
        public void ReadXml(XmlDocument xmlDocument)
        {
            if (xmlDocument.DocumentElement.ChildNodes != null)
            {
                //Iterates thru each node in HattrickData node
                foreach (XmlNode xmlNode in xmlDocument.DocumentElement.ChildNodes)
                {
                    bool generalNode = false;
                    switch (xmlNode.Name)
                    {
                        case Tags.FileName:
                            {
                                this.fileNameField = xmlNode.InnerText;
                                generalNode = true;
                                break;
                            }
                        case Tags.Version:
                            {
                                this.versionField = GenericFunctions.ConvertStringToDecimal(xmlNode.InnerText);
                                generalNode = true;
                                break;
                            }
                        case Tags.UserID:
                            {
                                this.userIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                generalNode = true;
                                break;
                            }
                        case Tags.FetchedDate:
                            {
                                this.fetchedDateField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                                generalNode = true;
                                break;
                            }
                    }
                    if (!generalNode)
                    {
                        // Not one of the general nodes, 
                        // try reading it as a specific node
                        //ReadSpecificNode(xmlNode);
                    }
                }
            }
        }

        ///// <summary>
        ///// Checks if node is specific to that document and reads it.
        ///// </summary>
        ///// <param name="xmlNode">Node to read</param>
        //public abstract void ReadSpecificNode(XmlNode xmlNode);

        #endregion
    }
}
