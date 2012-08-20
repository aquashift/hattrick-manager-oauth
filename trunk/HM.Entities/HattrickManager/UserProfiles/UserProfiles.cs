using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.HattrickManager.UserProfiles {
    public class UserProfiles : HattrickManagerBase {
        #region Properties

        public List<User> userListField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public UserProfiles() {
            savedDateField = DateTime.MinValue;
            userListField = new List<User>();
        }

        #endregion
    }
}
