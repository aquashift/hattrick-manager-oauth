using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TransfersPlayer
{
    public class TransfersPlayer : HattrickBase
    {
        #region Properties

        public Transfers transfersField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public TransfersPlayer()
        {
            transfersField = new Transfers();
        }

        #endregion
    }
}