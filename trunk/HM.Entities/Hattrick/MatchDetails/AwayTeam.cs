using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.MatchDetails
{
    public class AwayTeam
    {
        #region Properties

        public uint awayTeamIdField { get; set; }
        public string awayTeamNameField { get; set; }
        public string dressField { get; set; }
        public string formationField { get; set; }
        public byte awayGoalsField { get; set; }
        public TacticType tacticTypeField { get; set; }
        public TacticSkill tacticSkillField { get; set; }
        public SectorRating ratingMidfieldField { get; set; }
        public SectorRating ratingRightDefField { get; set; }
        public SectorRating ratingMidDefField { get; set; }
        public SectorRating ratingLeftDefField { get; set; }
        public SectorRating ratingRightAttField { get; set; }
        public SectorRating ratingMidAttField { get; set; }
        public SectorRating ratingLeftAttField { get; set; }
        public TeamAttitude teamAttitudeField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public AwayTeam()
        {
            this.awayTeamIdField = 0;
            this.awayTeamNameField = string.Empty;
            this.dressField = string.Empty;
            this.formationField = string.Empty;
            this.awayGoalsField = 0;
            this.tacticTypeField = TacticType.Unavailable;
            this.tacticSkillField = TacticSkill.Unavailable;
            this.ratingMidfieldField = SectorRating.Unavailable;
            this.ratingRightDefField = SectorRating.Unavailable;
            this.ratingMidDefField = SectorRating.Unavailable;
            this.ratingLeftDefField = SectorRating.Unavailable;
            this.ratingRightAttField = SectorRating.Unavailable;
            this.ratingMidAttField = SectorRating.Unavailable;
            this.ratingLeftAttField = SectorRating.Unavailable;
            this.teamAttitudeField = TeamAttitude.Unavailable;
        }

        #endregion
    }
}
