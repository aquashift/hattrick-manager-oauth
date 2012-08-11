using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails
{
    public class PressAnnouncement
    {
        #region Properties

        public string subjectField { get; set; }
        public string bodyField { get; set; }
        public DateTime sendDateField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public PressAnnouncement()
        {
            this.subjectField = string.Empty;
            this.bodyField = string.Empty;
            this.sendDateField = DateTime.MinValue;
        }

        #endregion
    }
}
