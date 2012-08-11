using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.Authentication
{
    public class Authentication : HattrickBase
    {
        #region Properties

        public string actionTypeField { get; set; }
        public LoginResult loginResultField { get; set; }
        public bool hasSecurityCodeField { get; set; }
        public bool isAuthenticatedField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Authentication()
        {
            actionTypeField = string.Empty;
            loginResultField = LoginResult.Unavailable;
            hasSecurityCodeField = false;
            isAuthenticatedField = false;
        }

        #endregion
    }
}
