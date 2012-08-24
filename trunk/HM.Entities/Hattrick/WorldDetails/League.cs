using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.WorldDetails {
    public class League {
        #region Comparison

        public static Comparison<League> englishNameComparison = delegate(League league1, League league2) {
            return league1.englishNameField.CompareTo(league2.englishNameField);
        };

        #endregion

        #region Properties

        public uint leagueIdField { get; set; }
        public string leagueNameField { get; set; }
        public uint seasonField { get; set; }
        public byte matchRoundField { get; set; }
        public string shortNameField { get; set; }
        public string continentField { get; set; }
        public string zoneNameField { get; set; }
        public string englishNameField { get; set; }
        public Country countryField { get; set; }
        public Cup cupField { get; set; }
        public uint activeUsersField { get; set; }
        public uint waitingUsersField { get; set; }
        public DateTime trainingDateField { get; set; }
        public DateTime economyDateField { get; set; }
        public DateTime cupMatchDateField { get; set; }
        public DateTime seriesMatchDateField { get; set; }
        public byte numberOfLevelsField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public League() {
            this.leagueIdField = 0;
            this.leagueNameField = string.Empty;
            this.seasonField = 0;
            this.matchRoundField = 0;
            this.shortNameField = string.Empty;
            this.continentField = string.Empty;
            this.zoneNameField = string.Empty;
            this.englishNameField = string.Empty;
            this.countryField = new Country();
            this.cupField = new Cup();
            this.activeUsersField = 0;
            this.waitingUsersField = 0;
            this.trainingDateField = DateTime.MinValue;
            this.economyDateField = DateTime.MinValue;
            this.cupMatchDateField = DateTime.MinValue;
            this.seriesMatchDateField = DateTime.MinValue;
        }

        #endregion
    }
}
