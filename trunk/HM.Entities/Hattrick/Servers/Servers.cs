using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HM.Entities.Hattrick.Servers
{
    public class Servers : HattrickBase
    {
        #region Properties

        public string recommendedUrlField { get; set; }
        public List<string> serversField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Servers()
        {
            recommendedUrlField = string.Empty;
            serversField = new List<string>();
        }

        #endregion
    }
}