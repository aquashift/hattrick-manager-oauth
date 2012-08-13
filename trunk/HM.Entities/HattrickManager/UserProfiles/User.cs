using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.HattrickManager.UserProfiles {
    public class User {
        #region Properties

        public uint teamIdField { get; set; }
        public uint youthTeamIdField { get; set; }
        public string accessToken { get; set; }
        public string accessTokenSecret { get; set; }
        public DateTime activationDateField { get; set; }
        public string dataFolderField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public User() {
            teamIdField = 0;
            youthTeamIdField = 0;
            accessToken = string.Empty;
            accessTokenSecret = string.Empty;
            dataFolderField = string.Empty;
        }

        public void CopyData(User source) {
            this.accessToken = source.accessToken;
            this.accessTokenSecret = source.accessTokenSecret;
            this.dataFolderField = source.dataFolderField;
            this.youthTeamIdField = source.youthTeamIdField;
        }

        #endregion
    }
}
