using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.HattrickManager.UserProfiles
{
    public class User
    {
        #region Properties

        public uint teamIdField { get; set; }
        public uint youthTeamIdField { get; set; }
        public string loginNameField { get; set; }
        public bool storeSecurityCodeField { get; set; }
        public string securityCodeField { get; set; }
        public DateTime activationDateField { get; set; }
        public string dataFolderField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public User()
        {
            teamIdField = 0;
            youthTeamIdField = 0;
            loginNameField = string.Empty;
            storeSecurityCodeField = false;
            securityCodeField = string.Empty;
            dataFolderField = string.Empty;
        }

        public void CopyData(User source)
        {
            this.loginNameField = source.loginNameField;
            this.storeSecurityCodeField = source.storeSecurityCodeField;
            if (this.storeSecurityCodeField)
            {
                this.securityCodeField = source.securityCodeField;
            }
            else
            {
                this.securityCodeField = "";
            }
            this.dataFolderField = source.dataFolderField;
            this.youthTeamIdField = source.youthTeamIdField;
        }

        #endregion
    }
}
