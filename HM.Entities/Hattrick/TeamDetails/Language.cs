using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails
{
    public class Language
    {
        #region Properties

        public uint languageIdField { get; set; }
        public string languageNameField { get; set; }

        #endregion

        #region Methods

        public Language()
        {
            this.languageIdField = 0;
            this.languageNameField = string.Empty;
        }

        #endregion
    }
}
