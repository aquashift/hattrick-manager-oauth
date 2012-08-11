using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.LeagueFixtures
{
    public class LeagueFixtures : HattrickBase
    {
        #region Properties

        public uint leagueLevelUnitIdField { get; set; }
        public string leagueLevelUnitNameField { get; set; }
        public int seasonField { get; set; }
        public List<Match> matchListField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public LeagueFixtures()
        {
            fileNameField = string.Empty;
            versionField = 0;
            userIdField = 0;
            fetchedDateField = DateTime.MinValue;
            leagueLevelUnitIdField = 0;
            leagueLevelUnitNameField = string.Empty;
            seasonField = 0;
            matchListField = new List<Match>();
        }

        #endregion
    }
}
