using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.Players.Internal;

namespace HM.DataAccess.Parsers {
    public class PlayerInternalsParser : BaseParser {
        #region Implementation of abstract methods

        protected override HattrickBase CreateEntity() {
            return new PlayersInternal();
        }

        protected override void ParseSpecificNode(XmlNode xmlNode, HattrickBase entity) {
            try {
                PlayersInternal players = (PlayersInternal)entity;

                switch (xmlNode.Name) {
                    case Tags.PlayerCategories:
                        if (xmlNode.ChildNodes != null) {
                            players.playerCategories = ParseCategoryNode(xmlNode);
                        }
                        break;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion

        #region Private methods

        private List<PlayerCategories>ParseCategoryNode(XmlNode categoryNode) {
           List<PlayerCategories> playerCategories = new List<PlayerCategories>();

            foreach (XmlNode xmlPlayerNode in categoryNode.ChildNodes) {
                if (xmlPlayerNode.ChildNodes != null) {
                    PlayerCategories cat = new PlayerCategories();

                    foreach (XmlNode xmlNode in xmlPlayerNode.ChildNodes) {
                        switch (xmlNode.Name) {
                            case Tags.PlayerID:
                                cat.PlayerIDField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                            case Tags.PlayerCategoryId:
                                cat.PlayerCategoryField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                                break;
                        }
                    }

                    playerCategories.Add(cat);
                }
            }

            return (playerCategories);
        }

        #endregion
    }
}