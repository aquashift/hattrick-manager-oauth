using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Entities.Hattrick.TeamDetails {
    public class Team {
        #region Properties

        public uint teamIdField { get; set; }
        public string teamNameField { get; set; }
        public string shortTeamNameField { get; set; }
        public Arena arenaField { get; set; }
        public League leagueField { get; set; }
        public Region regionField { get; set; }
        public Trainer trainerField { get; set; }
        public string homePageField { get; set; }
        public string dressField { get; set; }
        public string dressAlternateField { get; set; }
        public LeagueLevelUnit leagueLevelUnitField { get; set; }
        public BotStatus botStatusField { get; set; }
        public Cup cupField { get; set; }
        public uint friendlyTeamIdField { get; set; }
        public int numberOfVictoriesField { get; set; }
        public int numberOfUndefeatedField { get; set; }
        public int teamRankField { get; set; }
        public string logoUrlField { get; set; }
        public Fanclub fanclubField { get; set; }
        public Guestbook guestbookField { get; set; }
        public PressAnnouncement pressAnnouncementField { get; set; }
        public uint youthTeamIdField { get; set; }
        public int numberOfVisitsField { get; set; }
        public Flags flagsField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Team() {
            this.teamIdField = 0;
            this.teamNameField = string.Empty;
            this.shortTeamNameField = string.Empty;
            this.arenaField = new Arena();
            this.leagueField = new League();
            this.regionField = new Region();
            this.trainerField = new Trainer();
            this.homePageField = string.Empty;
            this.dressField = string.Empty;
            this.dressAlternateField = string.Empty;
            this.leagueLevelUnitField = new LeagueLevelUnit();
            this.botStatusField = new BotStatus();
            this.cupField = new Cup();
            this.friendlyTeamIdField = 0;
            this.numberOfVictoriesField = 0;
            this.numberOfUndefeatedField = 0;
            this.teamRankField = 0;
            this.logoUrlField = string.Empty;
            this.fanclubField = new Fanclub();
            this.guestbookField = new Guestbook();
            this.pressAnnouncementField = new PressAnnouncement();
            this.youthTeamIdField = 0;
            this.numberOfVisitsField = 0;
            this.flagsField = new Flags();
        }

        #endregion
    }
}