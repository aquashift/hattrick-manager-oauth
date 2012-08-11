using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HM.Entities.Hattrick;
using HM.Entities.Hattrick.TransfersPlayer;

namespace HM.DataAccess.Parsers
{
    public class TransfersPlayerParser : BaseParser
    {
        #region Implementation of abstract methods

        protected override HattrickBase CreateEntity()
        {
            return new TransfersPlayer();
        }

        protected override void ParseSpecificNode(XmlNode xmlNode, HattrickBase entity)
        {
            try
            {
                TransfersPlayer transfersPlayer = (TransfersPlayer)entity;

                switch (xmlNode.Name)
                {
                    case Tags.Transfers:
                        if (xmlNode.ChildNodes != null)
                        {
                            foreach (XmlNode xmlNodeTransfers in xmlNode.ChildNodes)
                            {
                                switch (xmlNodeTransfers.Name)
                                {
                                    case Tags.StartDate:
                                        transfersPlayer.transfersField.startDateField = GenericFunctions.ConvertStringToDateTime(xmlNodeTransfers.InnerText);
                                        break;
                                    case Tags.EndDate:
                                        transfersPlayer.transfersField.endDateField = GenericFunctions.ConvertStringToDateTime(xmlNodeTransfers.InnerText);
                                        break;
                                    case Tags.Player:
                                        if (xmlNodeTransfers.ChildNodes != null)
                                        {
                                            transfersPlayer.transfersField.playerField = ParsePlayerNode(xmlNodeTransfers);
                                        }
                                        break;
                                    case Tags.Transfer:
                                        if (xmlNodeTransfers.ChildNodes != null)
                                        {
                                            transfersPlayer.transfersField.transferField.Add(ParseTransferNode(xmlNodeTransfers));
                                        }
                                        break;
                                }
                            }
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

        private Player ParsePlayerNode(XmlNode playerNode)
        {
            try
            {
                Player player = new Player();

                foreach (XmlNode xmlNode in playerNode.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.PlayerID:
                            player.playerIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.PlayerName:
                            player.playerNameField = xmlNode.InnerText;
                            break;
                        case Tags.TeamId:
                            player.teamIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                    }
                }

                return player;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Transfer ParseTransferNode(XmlNode transferNode)
        {
            try
            {
                Transfer transfer = new Transfer();

                foreach (XmlNode xmlNode in transferNode.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.TransferID:
                            transfer.transferIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.Deadline:
                            transfer.deadlineField = GenericFunctions.ConvertStringToDateTime(xmlNode.InnerText);
                            break;
                        case Tags.Buyer:
                            if (xmlNode.ChildNodes != null)
                            {
                                transfer.buyerField = ParseBuyerNode(xmlNode);
                            }
                            break;
                        case Tags.Seller:
                            if (xmlNode.ChildNodes != null)
                            {
                                transfer.sellerField = ParseSellerNode(xmlNode);
                            }
                            break;
                        case Tags.Price:
                            transfer.priceField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.TSI:
                            transfer.tsiField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                    }
                }

                return transfer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Buyer ParseBuyerNode(XmlNode buyerNode)
        {
            try
            {
                Buyer buyer = new Buyer();

                foreach (XmlNode xmlNode in buyerNode.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.BuyerTeamID:
                            buyer.buyerTeamIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.BuyerTeamName:
                            buyer.buyerTeamNameField = xmlNode.InnerText;
                            break;
                    }
                }

                return buyer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Seller ParseSellerNode(XmlNode sellerNode)
        {
            try
            {
                Seller seller = new Seller();

                foreach (XmlNode xmlNode in sellerNode.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case Tags.SellerTeamID:
                            seller.sellerTeamIdField = GenericFunctions.ConvertStringToUInt(xmlNode.InnerText);
                            break;
                        case Tags.SellerTeamName:
                            seller.sellerTeamNameField = xmlNode.InnerText;
                            break;
                    }
                }

                return seller;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
