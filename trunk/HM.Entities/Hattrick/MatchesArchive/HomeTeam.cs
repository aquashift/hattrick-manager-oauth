﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.MatchesArchive
{
    public class HomeTeam
    {
        #region Properties

        public uint homeTeamIdField { get; set; }
        public string homeTeamNameField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeTeam()
        {
            homeTeamIdField = 0;
            homeTeamNameField = string.Empty;
        }

        #endregion
    }
}