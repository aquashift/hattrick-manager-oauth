using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.HattrickManager.Settings {
    public class HattrickSettings : HattrickManagerBase {
        #region Properties

        public List<Category> playerCategoryListField { get; set; }
        public List<Position> playerPositionsListField { get; set; }
        public Dictionary<HM.Resources.ColumnTables, List<Column>> tableColumsListField { get; set; }
        public List<LastFiles> lastFileListField { get; set; }
        public bool DefaultsRestored { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        public HattrickSettings() {
            this.playerCategoryListField = new List<Category>();
            this.playerPositionsListField = new List<Position>();
            this.tableColumsListField = new Dictionary<Resources.ColumnTables,List<Column>>();
            this.lastFileListField = new List<LastFiles>();
            this.DefaultsRestored = false;
        }

        public void UpdateLastFile(HM.Resources.FileType fileType, string fileName) {
            bool FileExists = false;
            string currentDate = DateTime.Now.ToString(HM.Resources.Constants.Chpp.HMDateFormat);

            //Try and update an exisiting field
            for (int i = 0; i < lastFileListField.Count; i++) {
                LastFiles file = lastFileListField[i];

                if (file.fileTypeField == fileType) {
                    file.fileNameField = fileName;
                    file.dateField = currentDate;
                    FileExists = true;
                    break;
                }
            }

            // Create New Last File Field
            if (!FileExists) {
                LastFiles newFile = new LastFiles();
                newFile.fileTypeField = fileType;
                newFile.fileNameField = fileName;
                newFile.dateField = currentDate;

                lastFileListField.Add(newFile);
            }
        }

        public string GetLastFileName(HM.Resources.FileType fileType) {
            string filename = string.Empty;

            //Try and update an exisiting field
            for (int i = 0; i < lastFileListField.Count; i++) {
                LastFiles file = lastFileListField[i];

                if (file.fileTypeField == fileType) {
                    filename = file.fileNameField;
                    break;
                }
            }

            return (filename);
        }

        #endregion
    }
}
