using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HM.Resources;

namespace HM.Entities.Hattrick.Players {
    public class Player {
        #region Properties

        public uint playerIdField { get; set; }
        public string firstNameField { get; set; }
        public string nickNameField { get; set; }
        public string lastNameField { get; set; }
        public byte playerNumberField { get; set; }
        public byte ageField { get; set; }
        public byte ageDaysField { get; set; }
        public uint tsiField { get; set; }
        public PlayerForm playerFormField { get; set; }
        public string statementField { get; set; }
        public PlayerSkill experienceField { get; set; }
        public Leadership leadershipField { get; set; }
        public uint salaryField { get; set; }
        public bool isAbroadField { get; set; }
        public Agreeability agreeabilityField { get; set; }
        public Aggressiveness aggressivenessField { get; set; }
        public Honesty honestyField { get; set; }
        public int leagueGoalsField { get; set; }
        public int cupGoalsField { get; set; }
        public int friendliesGoalsField { get; set; }
        public int careerGoalsField { get; set; }
        public int careerHattricksField { get; set; }
        public PlayerSpecialty specialtyField { get; set; }
        public bool transferlistedField { get; set; }
        public uint nationalTeamIdField { get; set; }
        public uint countryIdField { get; set; }
        public uint leagueIdField { get; set; }
        public int capsField { get; set; }
        public int capsU20Field { get; set; }
        public int cardsField { get; set; }
        public int injuryLevelField { get; set; }
        public bool motherClubField { get; set; }
        public PlayerSkill loyaltyField { get; set; }
        public PlayerSkill staminaSkillField { get; set; }
        public PlayerSkill keeperSkillField { get; set; }
        public PlayerSkill playmakerSkillField { get; set; }
        public PlayerSkill scorerSkillField { get; set; }
        public PlayerSkill passingSkillField { get; set; }
        public PlayerSkill wingerSkillField { get; set; }
        public PlayerSkill defenderSkillField { get; set; }
        public PlayerSkill setPiecesSkillField { get; set; }
        public PlayerSkill playerCategoryIdField { get; set; }
        public TrainerData trainerDataField { get; set; }
        public LastMatchData lastMatchField { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public Player() {
            playerIdField = 0;
            firstNameField = string.Empty;
            nickNameField = string.Empty;
            lastNameField = string.Empty;
            playerNumberField = 0;
            ageField = 0;
            ageDaysField = 0;
            tsiField = 0;
            playerFormField = PlayerForm.Unavailable;
            statementField = string.Empty;
            experienceField = PlayerSkill.Unavailable;
            leadershipField = Leadership.Unavailable;
            salaryField = 0;
            isAbroadField = false;
            agreeabilityField = Agreeability.Unavailable;
            aggressivenessField = Aggressiveness.Unavailable;
            honestyField = Honesty.Unavailable;
            leagueGoalsField = 0;
            cupGoalsField = 0;
            friendliesGoalsField = 0;
            careerGoalsField = 0;
            careerHattricksField = 0;
            specialtyField = PlayerSpecialty.NoSpecialty;
            transferlistedField = false;
            nationalTeamIdField = 0;
            countryIdField = 0;
            leagueIdField = 0;
            capsField = 0;
            capsU20Field = 0;
            cardsField = 0;
            injuryLevelField = 0;
            motherClubField = false;
            loyaltyField = PlayerSkill.Unavailable;
            staminaSkillField = PlayerSkill.Unavailable;
            keeperSkillField = PlayerSkill.Unavailable;
            playmakerSkillField = PlayerSkill.Unavailable;
            scorerSkillField = PlayerSkill.Unavailable;
            passingSkillField = PlayerSkill.Unavailable;
            wingerSkillField = PlayerSkill.Unavailable;
            defenderSkillField = PlayerSkill.Unavailable;
            setPiecesSkillField = PlayerSkill.Unavailable;
            playerCategoryIdField = 0;
            trainerDataField = new TrainerData();
            lastMatchField = new LastMatchData();
        }

        public string getFullName() {
            return (this.firstNameField + " " + this.lastNameField);
        }

        public string getFullAge() {
            return (this.ageField + "." + this.ageDaysField);
        }

        #endregion
    }
}
