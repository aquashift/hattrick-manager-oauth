using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.Authentication;

namespace HM.DataAccess.Parsers
{
    public class AuthenticationParser : BaseParser
    {
        #region Implementations of abstract methods

        protected override HM.Entities.Hattrick.HattrickBase CreateEntity()
        {
            return new Authentication();
        }

        protected override void ParseSpecificNode(System.Xml.XmlNode xmlNode, HM.Entities.Hattrick.HattrickBase entity)
        {
            Authentication authentication = (Authentication)entity;

            switch (xmlNode.Name)
            {
                case Tags.ActionType:
                    {
                        authentication.actionTypeField = xmlNode.InnerText;
                        break;
                    }
                case Tags.LoginResult:
                    {
                        authentication.loginResultField = (LoginResult)Convert.ToInt32(xmlNode.InnerText);
                        break;
                    }
                case Tags.HasSecurityCode:
                    {
                        authentication.hasSecurityCodeField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                        break;
                    }
                case Tags.IsAuthenticated:
                    {
                        authentication.isAuthenticatedField = GenericFunctions.ConvertStringToBool(xmlNode.InnerText);
                        break;
                    }
                default:
                    throw new Exception(string.Format("Invalid XML: Achievements.xml", Tags.Achievement));
            }
        }

        #endregion
    }
}
