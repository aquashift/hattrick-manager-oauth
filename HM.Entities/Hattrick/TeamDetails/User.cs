using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails {
    public class User {
        #region Properties

        public uint userIdField { get; set; }
        public Language languageField { get; set; }
        public bool hasSupporterField { get; set; }
        public string loginnameField { get; set; }
        public string nameField { get; set; }
        public string icqField { get; set; }
        public DateTime signupDateField { get; set; }
        public DateTime activationDateField { get; set; }
        public DateTime lastLoginDateField { get; set; }
        public List<NationalTeam> nationalTeamCoachField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public User() {
            this.userIdField = 0;
            this.languageField = new Language();
            this.hasSupporterField = false;
            this.loginnameField = string.Empty;
            this.nameField = string.Empty;
            this.icqField = string.Empty;
            this.signupDateField = DateTime.MinValue;
            this.activationDateField = DateTime.MinValue;
            this.lastLoginDateField = DateTime.MinValue;
            this.nationalTeamCoachField = new List<NationalTeam>();
        }

        #endregion
    }
}