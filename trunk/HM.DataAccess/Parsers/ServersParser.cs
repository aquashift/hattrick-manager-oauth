using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.Servers;

namespace HM.DataAccess.Parsers
{
    public class ServersParser : BaseParser
    {
        #region Implementation of abstract methods

        protected override HM.Entities.Hattrick.HattrickBase CreateEntity()
        {
            return new Servers();
        }

        protected override void ParseSpecificNode(System.Xml.XmlNode xmlNode, HM.Entities.Hattrick.HattrickBase entity)
        {
            try
            {
                Servers servers = (Servers)entity;

                switch (xmlNode.Name)
                {
                    case Tags.RecommendedURL:
                        servers.recommendedUrlField = xmlNode.InnerText;
                        break;
                    case Tags.Servers:
                        if (xmlNode.ChildNodes != null)
                        {
                            servers.serversField = ParseServersNode(xmlNode);
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

        private List<String> ParseServersNode(XmlNode serversNode)
        {
            try
            {
                List<string> serversList = new List<string>();

                foreach (XmlNode xmlNode in serversNode.ChildNodes)
                {
                    if (xmlNode.ChildNodes != null)
                    {
                        foreach (XmlNode xmlNodeUrl in xmlNode.ChildNodes)
                        {
                            serversList.Add(xmlNodeUrl.InnerText);
                        }
                    }
                }
                return serversList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
