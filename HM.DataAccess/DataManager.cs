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
                    case FileType.Login:
                        hattrickData = new Parsers.AuthenticationParser().ParseXmlDocument(xmlDocument);
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
                                                                hattrickManagerDataUser.authorizationField = xmlNodeUser.InnerText;
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
        /// <param name="xmlStream">Content to write</param>
        /// <param name="path">Path to write the file in</param>
        /// <param name="fileName">Name of the file to write</param>
        public void WriteFile(Stream xmlStream, string path, string fileName) {
            try {
                //Creates the directory if it doesn't exists
                Directory.CreateDirectory(path);

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlStream);

                xmlDocument.Save(Path.Combine(path, fileName));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Writes a file with the specified name in the common data folder
        /// </summary>
        /// <param name="xmlStream">Content to write</param>
        /// <param name="fileName">Name of the file to write</param>
        public void WriteFile(Stream xmlStream, string fileName) {
            try {
                //Creates the directory if it doesn't exists
                Directory.CreateDirectory(this.commonFolder);

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlStream);

                xmlDocument.Save(Path.Combine(this.commonFolder, fileName));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Writes the UserProfiles to disk
        /// </summary>
        /// <param name="hattrickManagerData">UserProfiles to write</param>
        public void WriteUserProfilesFile(HMEntities.UserProfiles.UserProfiles hattrickManagerData) {
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
                    XmlElement xmlElementSecurityCode = xmlDocument.CreateElement(Tags.SecurityCode);
                    XmlAttribute xmlAttributeStoreSecurityCode = xmlDocument.CreateAttribute(Tags.Store);
                    XmlElement xmlElementActivation = xmlDocument.CreateElement(Tags.ActivationDate);
                    XmlElement xmlElementDataFolder = xmlDocument.CreateElement(Tags.DataFolder);


                    xmlElementTeamId.InnerText = currentUser.teamIdField.ToString();
                    xmlElementYouthTeamId.InnerText = currentUser.youthTeamIdField.ToString();
                    xmlElementLoginname.InnerText = currentUser.authorizationField;

                    xmlElementSecurityCode.Attributes.Append(xmlAttributeStoreSecurityCode);
                    xmlElementActivation.InnerText = currentUser.activationDateField.ToString(General.DateTimeFormat);
                    xmlElementDataFolder.InnerText = currentUser.dataFolderField;

                    XmlElement xmlElementUser = xmlDocument.CreateElement(Tags.User);

                    xmlElementUser.AppendChild(xmlElementTeamId);
                    xmlElementUser.AppendChild(xmlElementYouthTeamId);
                    xmlElementUser.AppendChild(xmlElementLoginname);
                    xmlElementUser.AppendChild(xmlElementSecurityCode);
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

        /// <summary>
        /// Saves Matches XML from stream to disk.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="xmlStream"></param>
        public void SaveMatches(User user, Stream xmlStream) {
            string folderPath = System.IO.Path.Combine(System.IO.Path.Combine(user.dataFolderField, user.teamIdField.ToString()), FolderNames.Matches);
            string fileName = FileNames.Matches;

            SaveXml(xmlStream, folderPath, fileName);
        }

        //public void SaveMatches(User user, Stream xmlStream)
        //{
        //    string folderPath = System.IO.Path.Combine(user.dataFolderField, FolderNames.Matches);
        //    string fileName = FileNames.Matches;

        //    SaveXml(xmlStream, folderPath, fileName);
        //}

        #endregion

        #region Private Methods

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
        /// <param name="xmlStream">XML stream</param>
        /// <param name="folderPath">Folder to save file to</param>
        /// <param name="fileName">File name</param>
        private void SaveXml(Stream xmlStream, string folderPath, string fileName) {
            try {
                //Creates the directory if it doesn't exists
                Directory.CreateDirectory(folderPath);

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlStream);

                xmlDocument.Save(Path.Combine(folderPath, fileName));
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion

        public void SaveAchievements(User user, Stream xmlStream) {
            string folderPath = System.IO.Path.Combine(user.dataFolderField, FolderNames.Achievements);
            string fileName = FileNames.Achievements;

            SaveXml(xmlStream, folderPath, fileName);
        }

        public void SaveHattrickXml(User user, Stream xmlStream, FileType fileType) {
            // TODO. This should be a generic method to save any Hattrick XML to disk.
            // Algorithm:
            // 1. Calculate folder path from user and fileType
            // 2. Calculate file name from fileType and xmlStream
            // 3. Call SaveXml
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

        public HTEntities.Club.Club LoadClub(User user) {
            string userDataFolder = Path.Combine(user.dataFolderField, user.teamIdField.ToString());

            FileType fileType = FileType.Club;
            string folderName = GenericFunctions.GetFolderNameByFileType(fileType);
            string clubFolder = Path.Combine(userDataFolder, folderName);

            string fileName = FileNames.Club;
            string filePath = Path.Combine(clubFolder, fileName);

            Stream fileStream = GetFileStream(filePath);
            HTEntities.Club.Club club = (HTEntities.Club.Club)ReadFile(fileStream, fileType);

            return club;
        }
    }
}