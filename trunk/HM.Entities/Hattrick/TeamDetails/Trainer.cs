using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails
{
    public class Trainer
    {
        #region Properties

        public uint playerIdField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Trainer()
        {
            this.playerIdField = 0;
        }

        #endregion
    }
}