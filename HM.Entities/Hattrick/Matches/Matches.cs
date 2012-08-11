using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.Matches
{
    public class Matches : HattrickBase
    {
        #region Properties

        public bool isYouth { get; set; }
        public Team team { get; set; }

        #endregion

        #region Methods

        public Matches()
        {
            isYouth = false;
            team = new Team();
        }

        #endregion
    }
}
