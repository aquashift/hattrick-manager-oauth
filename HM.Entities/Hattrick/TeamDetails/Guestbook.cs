using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails
{
    public class Guestbook
    {
        #region Properties

        public uint numberOfGuestbookItemsField { get; set; }
        
        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Guestbook()
        {
            this.numberOfGuestbookItemsField = 0;
        }
        
        #endregion
    }
}
