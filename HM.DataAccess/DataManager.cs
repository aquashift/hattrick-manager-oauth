using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using HM.Resources;
using HM.Resources.Constants;
using HTEntities = HM.Entities.Hattrick;
using HMEntities = HM.Entities.HattrickManager;
using HM.Entities.HattrickManager.UserProfiles;
using HM.DataAccess.Parsers;

namespace HM.DataAccess {
    public class DataManager {
        #region Properties

        private string commonFolder;

        #endregion

        #region Public Methods

        public DataManager() {
            this.commonFolder = Path.Combine(Directory.GetCurrentDirectory(), FolderNames.CommonDataFolder);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commonFolder">Hattrick Manager common folder</param>
        public DataManager(string commonFolder) {
            this.commonFolder = commonFolder;
        }

        /// <summary>
        /// Reads a HT xml file and returns a HattrickBase object
        /// </summary>
        /// <param name="xmlStream">Xml file content</param>
        /// <param name="fileType">HT file type to read</param>
        /// <returns>HattrickBase object loaded with readed data</returns>
        public HTEntities.HattrickBase ReadFile(Stream xmlStream, FileType fileType) {
            try {
                HTEntities.HattrickBase hattrickData = null;
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlStream);

                switch (fileType) {
                    case FileType.Achievements:
                        hattrickData = new Parsers.AchievementsParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.ArenaDetails:
                        hattrickData = new Parsers.ArenaDetailsParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.Club:
                        hattrickData = new Parsers.ClubParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.Economy:
                        hattrickData = new Parsers.EconomyParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.Servers:
                        hattrickData = new Parsers.ServersParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.LeagueDetails:
                        hattrickData = new Parsers.LeagueDetailsParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.LeagueFixtures:
                        hattrickData = new Parsers.LeagueFixturesParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.MatchLineup:
                        hattrickData = new Parsers.MatchLineupParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.Matches:
                        hattrickData = new Parsers.MatchesParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.MatchesArchive:
                        hattrickData = new Parsers.MatchesArchiveParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.MatchDetails:
                        hattrickData = new Parsers.MatchDetailsParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.Players:
                        hattrickData = new Parsers.PlayersParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.TeamDetails:
                        hattrickData = new Parsers.TeamDetailsParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.TransfersPlayer:
                        hattrickData = new Parsers.TransfersPlayerParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.WorldDetails:
                        hattrickData = new Parsers.WorldDetailsParser().ParseXmlDocument(xmlDocument);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                xmlStream.Close();
                xmlStream.Dispose();

                return hattrickData;
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Reads a HT xml file and returns a HattrickBase object
        /// </summary>
        /// <param name="xmlString">Xml file content</param>
        /// <param name="fileType">HT file type to read</param>
        /// <returns>HattrickBase object loaded with readed data</returns>
        public HTEntities.HattrickBase ReadXMLString(String xmlString, FileType fileType) {
            try {
                HTEntities.HattrickBase hattrickData = null;
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlString);

                switch (fileType) {
                    case FileType.Achievements:
                        hattrickData = new Parsers.AchievementsParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.ArenaDetails:
                        hattrickData = new Parsers.ArenaDetailsParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.Club:
                        hattrickData = new Parsers.ClubParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.Economy:
                        hattrickData = new Parsers.EconomyParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.Servers:
                        hattrickData = new Parsers.ServersParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.LeagueDetails:
                        hattrickData = new Parsers.LeagueDetailsParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.LeagueFixtures:
                        hattrickData = new Parsers.LeagueFixturesParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.MatchLineup:
                        hattrickData = new Parsers.MatchLineupParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.Matches:
                        hattrickData = new Parsers.MatchesParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.MatchesArchive:
                        hattrickData = new Parsers.MatchesArchiveParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.MatchDetails:
                        hattrickData = new Parsers.MatchDetailsParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.Players:
                        hattrickData = new Parsers.PlayersParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.TeamDetails:
                        hattrickData = new Parsers.TeamDetailsParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.TransfersPlayer:
                        hattrickData = new Parsers.TransfersPlayerParser().ParseXmlDocument(xmlDocument);
                        break;
                    case FileType.WorldDetails:
                        hattrickData = new Parsers.WorldDetailsParser().ParseXmlDocument(xmlDocument);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                return hattrickData;
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Reads UserProfile xml file
        /// </summary>
        /// <param name="xmlStream">Xml file content</param>
        /// <returns>UserProfiles object loaded with readed data</returns>
        public HMEntities.UserProfiles.UserProfiles ReadUserProfilesFile(Stream xmlStream) {
            try {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlStream);

                HMEntities.UserProfiles.UserProfiles hattrickManagerData = new HM.Entities.HattrickManager.UserProfiles.UserProfiles();

                if (xmlDocument.DocumentElement.ChildNodes != null) {
                    foreach (XmlNode xmlNodeRoot in xmlDocument.DocumentElement.ChildNodes) {
                        switch (xmlNodeRoot.Name) {
                            case Tags.SavedDate: {
                                    hattrickManagerData.savedDateField = GenericFunctions.ConvertStringToDateTime(xmlNodeRoot.InnerText);
                                    break;
                                }
                            case Tags.UserList: {
                                    if (xmlNodeRoot.ChildNodes != null) {
                                        foreach (XmlNode xmlNodeUserList in xmlNodeRoot.ChildNodes) {
                                            if (xmlNodeUserList.ChildNodes != null) {
                                                HMEntities.UserProfiles.User hattrickManagerDataUser = new HM.Entities.HattrickManager.UserProfiles.User();

                                                foreach (XmlNode xmlNodeUser in xmlNodeUserList) {
                                                    switch (xmlNodeUser.Name) {
                                                        case Tags.TeamID: {
                                                                hattrickManagerDataUser.teamIdField = GenericFunctions.ConvertStringToUInt(xmlNodeUser.InnerText);
                                                                break;
                                                            }
                                                        case Tags.YouthTeamID: {
                                                                hattrickManagerDataUser.youthTeamIdField = GenericFunctions.ConvertStringToUInt(xmlNodeUser.InnerText);
                                                                break;
                                                            }
                                                        case Tags.Loginname: {
                                                                hattrickManagerDataUser.username = xmlNodeUser.InnerText;
                                                                break;
                                                            }
                                                        case Tags.UserToken: {
                                                                hattrickManagerDataUser.accessToken = xmlNodeUser.InnerText;
                                                                break;
                                                            }
                                                        case Tags.UserTokenSecret: {
                                                                hattrickManagerDataUser.accessTokenSecret = xmlNodeUser.InnerText;
                                                                break;
                                                            }
                                                        case Tags.ActivationDate: {
                                                                hattrickManagerDataUser.activationDateField = GenericFunctions.ConvertStringToDateTime(xmlNodeUser.InnerText);
                                                                break;
                                                            }
                                                        case Tags.DataFolder: {
                                                                hattrickManagerDataUser.dataFolderField = xmlNodeUser.InnerText;
                                                                break;
                                                            }
                                                    }
                                                }

                                                hattrickManagerData.userListField.Add(hattrickManagerDataUser);
                                            }
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }
                xmlStream.Close();
                return hattrickManagerData;
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Writes the content to the specified path and file name
        /// </summary>
        /// <param name="xmlData">Content to write</param>
        /// <param name="path">Path to write the file in</param>
        /// <param name="fileName">Name of the file to write</param>
        public void WriteFile(String xmlData, string path, string fileName) {
            try {
                //Creates the directory if it doesn't exists
                Directory.CreateDirectory(path);

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlData);

                xmlDocument.Save(Path.Combine(path, fileName));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Writes a file with the specified name in the common data folder
        /// </summary>
        /// <param name="xmlData">Content to write</param>
        /// <param name="fileName">Name of the file to write</param>
        public void WriteFile(String xmlData, string fileName) {
            try {
                //Creates the directory if it doesn't exists
                Directory.CreateDirectory(this.commonFolder);

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlData);

                xmlDocument.Save(Path.Combine(this.commonFolder, fileName));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Saves Matches XML from stream to disk.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="xmlData"></param>
        public void SaveMatches(User user, string xmlData) {
            string folderPath = System.IO.Path.Combine(System.IO.Path.Combine(user.dataFolderField, user.teamIdField.ToString()), FolderNames.Matches);
            string fileName = FileNames.Matches;

            SaveXml(xmlData, folderPath, fileName);
        }

        public UserProfiles LoadUserProfiles() {
            string fileName = Path.Combine(commonFolder, FileNames.UserProfiles);
            if (File.Exists(fileName)) {
                return ReadUserProfilesFile(GetFileStream(fileName));
            } else {
                return new UserProfiles();
            }
        }

        public void SaveUserProfiles(UserProfiles userProfiles) {
            WriteUserProfilesFile(userProfiles);
        }

        public void SaveUserSettings(User currentUser) {
            WriteUserSettingsFile(currentUser);
        }

        /// <summary>
        /// Reads UserSettings xml file
        /// </summary>
        /// <param name="xmlStream">Xml file content</param>
        /// <returns>UserSettings object from file</returns>
        public HMEntities.Settings.HattrickSettings ReadUserSettingsFile(Stream xmlStream) {
            HMEntities.Settings.HattrickSettings settings = new HMEntities.Settings.HattrickSettings();

            try {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlStream);

                settings = ProcessUserSettingsFile(xmlDocument);
                settings.DefaultsRestored = false;

                return (settings);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Reads UserSettings xml file
        /// </summary>
        /// <param name="xmlContent">Xml content as a string</param>
        /// <returns>UserSettings object from file</returns>
        public HMEntities.Settings.HattrickSettings ReadUserSettingsFile(String xmlContent) {
            HMEntities.Settings.HattrickSettings settings = new HMEntities.Settings.HattrickSettings();

            try {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlContent);

                settings = ProcessUserSettingsFile(xmlDocument);
                settings.DefaultsRestored = true;

                return (settings);
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion

        #region Private Methods

        private HMEntities.Settings.HattrickSettings ProcessUserSettingsFile(XmlDocument xmlDocument) {
            try {
                HMEntities.Settings.HattrickSettings settings = new HMEntities.Settings.HattrickSettings();

                if (xmlDocument.DocumentElement.ChildNodes != null) {
                    foreach (XmlNode xmlNodeRoot in xmlDocument.DocumentElement.ChildNodes) {
                        switch (xmlNodeRoot.Name) {
                            case Tags.CategoryList:
                                settings.playerCategoryListField = ParseSettingCategoryListNode(xmlNodeRoot);

                                if (xmlNodeRoot.Attributes[Tags.Version] != null) {
                                    settings.categoryVersionIDField = Convert.ToInt32(xmlNodeRoot.Attributes[Tags.Version].InnerText);
                                }
                                break;
                            case Tags.PositionList:
                                settings.playerPositionsListField = ParseSettingPositionsListNode(xmlNodeRoot);

                                if (xmlNodeRoot.Attributes[Tags.Version] != null) {
                                    settings.positionsVersionIDField = Convert.ToInt32(xmlNodeRoot.Attributes[Tags.Version].InnerText);
                                }
                                break;
                            case Tags.ColumnTables:
                                settings.tableColumsListField = ParseSettingColumnListNode(xmlNodeRoot);

                                if (xmlNodeRoot.Attributes[Tags.Version] != null) {
                                    settings.tableColumsVersionIDField = Convert.ToInt32(xmlNodeRoot.Attributes[Tags.Version].InnerText);
                                }
                                break;
                            case Tags.LastFileList:
                                if (xmlNodeRoot.ChildNodes != null) {
                                    settings.lastFileListField = ParseSettingLastFilesNode(xmlNodeRoot);
                                }
                                break;
                        }
                    }
                }

                return (settings);
            } catch (Exception ex) {
                throw ex;
            }
        }

        private List<HMEntities.Settings.Category> ParseSettingCategoryListNode(XmlNode node) {
            try {
                List<HMEntities.Settings.Category> categories = new List<HMEntities.Settings.Category>();

                foreach (XmlNode xmlCategoryListNodes in node.ChildNodes) {
                    if (xmlCategoryListNodes.NodeType != XmlNodeType.Comment && xmlCategoryListNodes.ChildNodes != null) {
                        HMEntities.Settings.Category category = new HMEntities.Settings.Category();

                        category.categoryIdField = Convert.ToUInt16(xmlCategoryListNodes.Attributes[Tags.CategoryID].InnerText);

                        foreach (XmlNode xmlCategoryNode in xmlCategoryListNodes.ChildNodes) {
                            switch (xmlCategoryNode.Name) {
                                case Tags.CategoryName:
                                    category.categoryNameField = xmlCategoryNode.InnerText;
                                    break;
                                case Tags.CategoryColour:
                                    category.categoryColourField = Convert.ToInt32(xmlCategoryNode.InnerText);
                                    break;
                                case Tags.CategoryChecked:
                                    category.categoryCheckedField = Convert.ToBoolean(xmlCategoryNode.InnerText);
                                    break;
                                case Tags.CategoryProtected:
                                    category.categoryProtectedField = Convert.ToBoolean(xmlCategoryNode.InnerText);
                                    break;
                            }
                        }

                        categories.Add(category);
                    }
                }

                return (categories);
            } catch (Exception ex) {
                throw ex;
            }
        }

        private List<HMEntities.Settings.Position> ParseSettingPositionsListNode(XmlNode node) {
            try {
                List<HMEntities.Settings.Position> positions = new List<HMEntities.Settings.Position>();

                foreach (XmlNode xmlPositionListNodes in node.ChildNodes) {
                    if (xmlPositionListNodes.NodeType != XmlNodeType.Comment && xmlPositionListNodes.ChildNodes != null) {
                        HMEntities.Settings.Position position = new HMEntities.Settings.Position();

                        position.positionID = (FieldPositionCode)Convert.ToUInt16(xmlPositionListNodes.Attributes[Tags.PositionID].InnerText);

                        foreach (XmlNode xmlPositionNode in xmlPositionListNodes.ChildNodes) {
                            PlayerSkillTypes key = (PlayerSkillTypes)Convert.ToUInt16(xmlPositionNode.Attributes[Tags.PositionWeightName].InnerText);

                            position.positionWeights.Add(key, Convert.ToDouble(xmlPositionNode.InnerText));
                        }

                        positions.Add(position);
                    }
                }

                return (positions);
            } catch (Exception ex) {
                throw ex;
            }
        }

        private Dictionary<ColumnTables, List<HMEntities.Settings.Column>> ParseSettingColumnListNode(XmlNode node) {
            try {
                Dictionary<ColumnTables, List<HMEntities.Settings.Column>> tableColumns = new Dictionary<ColumnTables, List<HMEntities.Settings.Column>>();

                foreach (XmlNode xmlColumnListNodes in node.ChildNodes) {
                    if (xmlColumnListNodes.NodeType != XmlNodeType.Comment && xmlColumnListNodes.ChildNodes != null) {
                        ColumnTables key = (ColumnTables)Convert.ToInt32(xmlColumnListNodes.Attributes[Tags.ColumnTableID].InnerText);
                        List<HMEntities.Settings.Column> columnList = new List<HMEntities.Settings.Column>();

                        foreach (XmlNode xmlColumnNode in xmlColumnListNodes.ChildNodes) {
                            HMEntities.Settings.Column column = new HMEntities.Settings.Column();

                            foreach (XmlNode xmlColumnChildNode in xmlColumnNode.ChildNodes) {
                                switch (xmlColumnChildNode.Name) {
                                    case Tags.ColumnID:
                                        column.columnIDField = Convert.ToUInt16(xmlColumnChildNode.InnerText);
                                        break;
                                    case Tags.ColumnTitle:
                                        column.titleField = xmlColumnChildNode.InnerText;
                                        break;
                                    case Tags.ColumnWidth:
                                        column.widthField = Convert.ToUInt16(xmlColumnChildNode.InnerText);
                                        break;
                                    case Tags.ColumnDisplayType:
                                        column.displayTypeField = (ColumnDisplayType)Convert.ToInt32(xmlColumnChildNode.InnerText);
                                        break;
                                    case Tags.ColumnAlignment:
                                        column.alignmentField = (ColumnAlignment)Convert.ToInt32(xmlColumnChildNode.InnerText);
                                        break;
                                    case Tags.ColumnDisplay:
                                        column.displayColumnField = Convert.ToBoolean(xmlColumnChildNode.InnerText);
                                        break;
                                    case Tags.ColumnDisplayIndex:
                                        column.displayIndex = Convert.ToInt32(xmlColumnChildNode.InnerText);
                                        break;
                                    case Tags.ColumnSortColumn:
                                        column.sortedColumnField = Convert.ToInt32(xmlColumnChildNode.InnerText);
                                        break;
                                }
                            }

                            columnList.Add(column);
                        }

                        tableColumns.Add(key, columnList);
                    }
                }

                return (tableColumns);
            } catch (Exception ex) {
                throw ex;
            }
        }

        private List<HMEntities.Settings.LastFiles> ParseSettingLastFilesNode(XmlNode node) {
            try {
                List<HMEntities.Settings.LastFiles> lastFiles = new List<HMEntities.Settings.LastFiles>();

                foreach (XmlNode xmlFileNodes in node.ChildNodes) {
                    if (xmlFileNodes.NodeType != XmlNodeType.Comment && xmlFileNodes.ChildNodes != null) {
                        HMEntities.Settings.LastFiles file = new HMEntities.Settings.LastFiles();

                        foreach (XmlNode xmlFileNode in xmlFileNodes.ChildNodes) {
                            switch (xmlFileNode.Name) {
                                case Tags.LastFileName:
                                    file.fileNameField = xmlFileNode.InnerText;
                                    break;
                                case Tags.LastFileType:
                                    file.fileTypeField = (FileType)Convert.ToInt32(xmlFileNode.InnerText);
                                    break;
                                case Tags.LastFileDate:
                                    file.dateField = xmlFileNode.InnerText;
                                    break;
                            }
                        }

                        lastFiles.Add(file);                    
                    }

                }

                return lastFiles;
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Writes the UserProfiles to disk
        /// </summary>
        /// <param name="hattrickManagerData">UserProfiles to write</param>
        private void WriteUserProfilesFile(HMEntities.UserProfiles.UserProfiles hattrickManagerData) {
            try {
                XmlDocument xmlDocument = new XmlDocument();

                XmlElement xmlElementRoot = xmlDocument.CreateElement(Tags.HattrickManagerData);

                hattrickManagerData.savedDateField = DateTime.Now;

                xmlElementRoot.AppendChild(xmlDocument.CreateElement(Tags.SavedDate)).InnerText = hattrickManagerData.savedDateField.ToString(General.DateTimeFormat);

                XmlElement xmlElementUserList = xmlDocument.CreateElement(Tags.UserList);

                foreach (HMEntities.UserProfiles.User currentUser in hattrickManagerData.userListField) {
                    XmlElement xmlElementTeamId = xmlDocument.CreateElement(Tags.TeamID);
                    XmlElement xmlElementYouthTeamId = xmlDocument.CreateElement(Tags.YouthTeamID);
                    XmlElement xmlElementLoginname = xmlDocument.CreateElement(Tags.Loginname);
                    XmlElement xmlElementToken = xmlDocument.CreateElement(Tags.UserToken);
                    XmlElement xmlElementTokenSecret = xmlDocument.CreateElement(Tags.UserTokenSecret);
                    XmlElement xmlElementActivation = xmlDocument.CreateElement(Tags.ActivationDate);
                    XmlElement xmlElementDataFolder = xmlDocument.CreateElement(Tags.DataFolder);

                    xmlElementTeamId.InnerText = currentUser.teamIdField.ToString();
                    xmlElementYouthTeamId.InnerText = currentUser.youthTeamIdField.ToString();
                    xmlElementLoginname.InnerText = currentUser.username;
                    xmlElementToken.InnerText = currentUser.accessToken;
                    xmlElementTokenSecret.InnerText = currentUser.accessTokenSecret;

                    xmlElementActivation.InnerText = currentUser.activationDateField.ToString(General.DateTimeFormat);
                    xmlElementDataFolder.InnerText = currentUser.dataFolderField;

                    XmlElement xmlElementUser = xmlDocument.CreateElement(Tags.User);

                    xmlElementUser.AppendChild(xmlElementTeamId);
                    xmlElementUser.AppendChild(xmlElementYouthTeamId);
                    xmlElementUser.AppendChild(xmlElementLoginname);
                    xmlElementUser.AppendChild(xmlElementToken);
                    xmlElementUser.AppendChild(xmlElementTokenSecret);

                    xmlElementUser.AppendChild(xmlElementActivation);
                    xmlElementUser.AppendChild(xmlElementDataFolder);

                    xmlElementUserList.AppendChild(xmlElementUser);
                }

                xmlElementRoot.AppendChild(xmlElementUserList);

                xmlDocument.AppendChild(xmlElementRoot);

                string path = GenericFunctions.GetFolderNameByFileType(FileType.WorldDetails);
                string fileName = Path.Combine(path, FileNames.UserProfiles);

                if (!System.IO.Directory.Exists(path)) {
                    System.IO.Directory.CreateDirectory(path);
                }

                xmlDocument.Save(fileName);
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void WriteUserSettingsFile(HMEntities.UserProfiles.User hattrickUser) {
            try {
                HMEntities.Settings.HattrickSettings hattrickManagerSettings = hattrickUser.applicationSettingsField;
                XmlDocument xmlDocument = new XmlDocument();

                XmlElement xmlElementRoot = xmlDocument.CreateElement(Tags.HattrickManagerSettings);

                hattrickManagerSettings.savedDateField = DateTime.Now;

                xmlElementRoot.AppendChild(xmlDocument.CreateElement(Tags.SavedDate)).InnerText = hattrickManagerSettings.savedDateField.ToString(General.DateTimeFormat);


                // Categories
                XmlElement xmlElementCategoryList = xmlDocument.CreateElement(Tags.CategoryList);
                xmlElementCategoryList.SetAttribute(Tags.Version, hattrickManagerSettings.categoryVersionIDField.ToString());

                foreach (HMEntities.Settings.Category currentCategory in hattrickManagerSettings.playerCategoryListField) {
                    XmlElement xmlElementCategoryName = xmlDocument.CreateElement(Tags.CategoryName);
                    XmlElement xmlElementCategoryColour = xmlDocument.CreateElement(Tags.CategoryColour);
                    XmlElement xmlElementCategoryChecked = xmlDocument.CreateElement(Tags.CategoryChecked);
                    XmlElement xmlElementCategoryProtected = xmlDocument.CreateElement(Tags.CategoryProtected);

                    xmlElementCategoryName.InnerText = currentCategory.categoryNameField;
                    xmlElementCategoryColour.InnerText = currentCategory.categoryColourField.ToString();
                    xmlElementCategoryChecked.InnerText = currentCategory.categoryCheckedField.ToString();
                    xmlElementCategoryProtected.InnerText = currentCategory.categoryProtectedField.ToString();

                    XmlElement xmlCategory = xmlDocument.CreateElement(Tags.Category);

                    xmlCategory.SetAttribute(Tags.CategoryID, currentCategory.categoryIdField.ToString());

                    xmlCategory.AppendChild(xmlElementCategoryName);
                    xmlCategory.AppendChild(xmlElementCategoryColour);
                    xmlCategory.AppendChild(xmlElementCategoryChecked);
                    xmlCategory.AppendChild(xmlElementCategoryProtected);

                    xmlElementCategoryList.AppendChild(xmlCategory);
                }

                xmlElementRoot.AppendChild(xmlElementCategoryList);


                // Positions
                XmlElement xmlElementPositionList = xmlDocument.CreateElement(Tags.PositionList);
                xmlElementPositionList.SetAttribute(Tags.Version, hattrickManagerSettings.positionsVersionIDField.ToString());

                foreach (HMEntities.Settings.Position currentPosition in hattrickManagerSettings.playerPositionsListField) {
                    XmlElement xmlElementPositionWeights = xmlDocument.CreateElement(Tags.PositionWeightList);

                    xmlElementPositionWeights.SetAttribute(Tags.PositionID, ((int)currentPosition.positionID).ToString());

                    foreach (HM.Resources.PlayerSkillTypes skill in currentPosition.positionWeights.Keys) {
                        XmlElement xmlElementWeight = xmlDocument.CreateElement(Tags.PositionWeight);

                        xmlElementWeight.SetAttribute(Tags.PositionWeightName, ((int)skill).ToString());
                        xmlElementWeight.InnerText = currentPosition.positionWeights[skill].ToString();

                        xmlElementPositionWeights.AppendChild(xmlElementWeight);
                    }

                    xmlElementPositionList.AppendChild(xmlElementPositionWeights);
                }

                xmlElementRoot.AppendChild(xmlElementPositionList);


                // Columns
                XmlElement xmlElementColumnTables = xmlDocument.CreateElement(Tags.ColumnTables);
                xmlElementColumnTables.SetAttribute(Tags.Version, hattrickManagerSettings.tableColumsVersionIDField.ToString());

                foreach (HM.Resources.ColumnTables tblKey in hattrickManagerSettings.tableColumsListField.Keys) {
                    List<HM.Entities.HattrickManager.Settings.Column> tablesColumns = hattrickManagerSettings.tableColumsListField[tblKey];
                    XmlElement xmlElementColumnList = xmlDocument.CreateElement(Tags.ColumnList);

                    xmlElementColumnList.SetAttribute(Tags.ColumnTableID, ((int)tblKey).ToString());

                    foreach (HMEntities.Settings.Column currentColumn in tablesColumns) {
                        XmlElement xmlElementColumnID = xmlDocument.CreateElement(Tags.ColumnID);
                        XmlElement xmlElementColumnTitle = xmlDocument.CreateElement(Tags.ColumnTitle);
                        XmlElement xmlElementColumnWidth = xmlDocument.CreateElement(Tags.ColumnWidth);
                        XmlElement xmlElementColumnType = xmlDocument.CreateElement(Tags.ColumnDisplayType);
                        XmlElement xmlElementColumnAlignment = xmlDocument.CreateElement(Tags.ColumnAlignment);
                        XmlElement xmlElementColumnDisplay = xmlDocument.CreateElement(Tags.ColumnDisplay);
                        XmlElement xmlElementColumnDisplayIndex = xmlDocument.CreateElement(Tags.ColumnDisplayIndex);
                        XmlElement xmlElementColumnSorted = xmlDocument.CreateElement(Tags.ColumnSortColumn);

                        xmlElementColumnID.InnerText = currentColumn.columnIDField.ToString();
                        xmlElementColumnTitle.InnerText = currentColumn.titleField;
                        xmlElementColumnWidth.InnerText = currentColumn.widthField.ToString();
                        xmlElementColumnType.InnerText = ((int)currentColumn.displayTypeField).ToString();
                        xmlElementColumnAlignment.InnerText = ((int)currentColumn.alignmentField).ToString();
                        xmlElementColumnDisplay.InnerText = currentColumn.displayColumnField.ToString();
                        xmlElementColumnDisplayIndex.InnerText = currentColumn.displayIndex.ToString();
                        xmlElementColumnSorted.InnerText = currentColumn.sortedColumnField.ToString();

                        XmlElement xmlColumn = xmlDocument.CreateElement(Tags.Column);

                        xmlColumn.AppendChild(xmlElementColumnID);
                        xmlColumn.AppendChild(xmlElementColumnTitle);
                        xmlColumn.AppendChild(xmlElementColumnWidth);
                        xmlColumn.AppendChild(xmlElementColumnType);
                        xmlColumn.AppendChild(xmlElementColumnAlignment);
                        xmlColumn.AppendChild(xmlElementColumnDisplay);
                        xmlColumn.AppendChild(xmlElementColumnDisplayIndex);
                        xmlColumn.AppendChild(xmlElementColumnSorted);

                        xmlElementColumnList.AppendChild(xmlColumn);
                    }

                    xmlElementColumnTables.AppendChild(xmlElementColumnList);
                }

                xmlElementRoot.AppendChild(xmlElementColumnTables);


                // Last Files
                XmlElement xmlElementLastFilesList = xmlDocument.CreateElement(Tags.LastFileList);

                foreach (HMEntities.Settings.LastFiles currentFile in hattrickManagerSettings.lastFileListField) {
                    XmlElement xmlElementFileName = xmlDocument.CreateElement(Tags.LastFileName);
                    XmlElement xmlElementFileType = xmlDocument.CreateElement(Tags.LastFileType);
                    XmlElement xmlElementFileDate = xmlDocument.CreateElement(Tags.LastFileDate);

                    xmlElementFileName.InnerText = currentFile.fileNameField;
                    xmlElementFileType.InnerText = ((int)currentFile.fileTypeField).ToString();
                    xmlElementFileDate.InnerText = currentFile.dateField;

                    XmlElement xmlFile = xmlDocument.CreateElement(Tags.File);

                    xmlFile.AppendChild(xmlElementFileName);
                    xmlFile.AppendChild(xmlElementFileType);
                    xmlFile.AppendChild(xmlElementFileDate);

                    xmlElementLastFilesList.AppendChild(xmlFile);
                }

                xmlElementRoot.AppendChild(xmlElementLastFilesList);

                xmlDocument.AppendChild(xmlElementRoot);

                string path = System.IO.Path.Combine(hattrickUser.dataFolderField, hattrickUser.teamIdField.ToString());
                path = System.IO.Path.Combine(path, FolderNames.UserSettings);

                string fileName = Path.Combine(path, FileNames.UserSettings);

                if (!System.IO.Directory.Exists(path)) {
                    System.IO.Directory.CreateDirectory(path);
                }

                xmlDocument.Save(fileName);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the specified file's Stream object
        /// </summary>
        /// <param name="path">Absolute path to the file</param>
        /// <returns>Stream with file's content</returns>
        private Stream GetFileStream(string path) {
            try {
                return new FileStream(path, FileMode.Open, FileAccess.Read);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Saves given XML stream to disk.
        /// </summary>
        /// <param name="xmlData">XML stream</param>
        /// <param name="folderPath">Folder to save file to</param>
        /// <param name="fileName">File name</param>
        private void SaveXml(string xmlData, string folderPath, string fileName) {
            try {
                //Creates the directory if it doesn't exists
                Directory.CreateDirectory(folderPath);

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlData);

                xmlDocument.Save(Path.Combine(folderPath, fileName));
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion
    }
}