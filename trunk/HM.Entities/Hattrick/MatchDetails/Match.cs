using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.MatchDetails
{
    public class Match
    {
        #region Properties

        public uint matchIdField { get; set; }
        public MatchType matchTypeField { get; set; }
        public DateTime matchDateField { get; set; }
        public DateTime finishedDateField { get; set; }
        public HomeTeam homeTeamField { get; set; }
        public AwayTeam awayTeamField { get; set; }
        public Arena arenaField { get; set; }
        public List<Goal> scorersField { get; set; }
        public List<Booking> bookingsField { get; set; }
        public byte possesionFirstHalfHomeField { get; set; }
        public byte possesionFirstHalfAwayField { get; set; }
        public byte possesionSecondHalfHomeField { get; set; }
        public byte possesionSecondHalfAwayField { get; set; }
        public List<Event> eventListField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Match()
        {
            this.matchIdField = 0;
            this.matchTypeField = MatchType.Unavailable;
            this.matchDateField = DateTime.MinValue;
            this.finishedDateField = DateTime.MinValue;
            this.homeTeamField = new HomeTeam();
            this.awayTeamField = new AwayTeam();
            this.arenaField = new Arena();
            this.scorersField = new List<Goal>();
            this.bookingsField = new List<Booking>();
            this.possesionFirstHalfHomeField = 0;
            this.possesionFirstHalfAwayField = 0;
            this.possesionSecondHalfHomeField = 0;
            this.possesionSecondHalfAwayField = 0;
            this.eventListField = new List<Event>();
        }

        #endregion
    }
}