using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Resources {
    public enum DownloadStatus : int {
        Downloading = 0,
        Complete = 1,
        Failed = 2
    };

    public enum MatchType : int {
        Unavailable = 0,
        LeagueMatch = 1,
        QualificationMatch = 2,
        LeagueCupMatch = 3,
        FriendlyMatchNormalRules = 4,
        FriendlyMatchCupRules = 5,
        NotInUse01 = 6,
        HattrickMastersMatch = 7,
        InternationalFriendlyMatchNormalRules = 8,
        InternationalFriendlyMatchCupRules = 9,
        NationalTeamsCompetitionMatchNormalRules = 10,
        NationalTeamsCompetitionMatchCupRules = 11,
        NationalTeamsFriendlyMatch = 12,
        YouthLeagueMatch = 100,
        YouthFriendlyMatchNormalRules = 101,
        NotInUse02 = 102,
        YouthFriendlyMatchCupRules = 103,
        NotInUse03 = 104,
        YouthInternationalFriendlyMatchNormalRules = 105,
        YouthInternationalFriendlyMatchCupRules = 106,
        NotInUse04 = 107
    };

    public enum FileType : int {
        Undefined = -1,
        Servers = 0,
        CheckSecurityCode = 1,
        Login = 2,
        Achievements = 3,
        ArenaDetails = 4,
        Club = 5,
        Economy = 6,
        Fans = 7,
        LeagueDetails = 8,
        LeagueFixtures = 9,
        MatchDetails = 10,
        Matches = 11,
        MatchesArchive = 12,
        MatchLineup = 13,
        PlayerDetails = 14,
        Players = 15,
        TeamDetails = 16,
        Training = 17,
        TransfersPlayer = 18,
        TransfersTeam = 19,
        WorldDetails = 20,
        UserSettings = 21,
        LastPlayers = 22,
        PlayerInternals = 23
    };

    public enum SettingTypes : int {
        All = 0,
        Categories = 1,
        Positions = 2,
        Columns = 3
    };

    public enum ColumnAlignment : int {
        Left = 0,
        Center = 1,
        Right = 2
    };

    public enum ColumnDisplayType : int {
        Value = 0,
        Name = 1,
        NameValue = 2,
        Graphical = 3,
        All = 4
    };

    public enum AchievementCategory : int {
        Unavailable = 0,
        Ranking = 1,
        Team = 2,
        Matches = 3,
        Manager = 4,
        SpecialAward = 5
    };

    public enum TrainerType : int {
        Unavailable = -1,
        Defensive = 0,
        Offensive = 1,
        Balanced = 2
    };

    public enum PlayerSpecialty : int {
        NoSpecialty = 0,
        Technical = 1,
        Quick = 2,
        Powerful = 3,
        Unpredictable = 4,
        HeadSpecialist = 5
    };

    public enum MatchStatus {
        Finished,
        Upcoming
    };

    public enum FormMode {
        Add,
        Edit
    };

    public enum PositionChange : int {
        Unavailable = -1,
        NoChange = 0,
        MovingUp = 1,
        MovingDown = 2
    };

    public enum TeamLocation {
        Home,
        Away
    };

    public enum SupportersMood : int {
        Unavailable = -1,
        Furious = 1,
        Angry = 2,
        Irritated = 3,
        Disappointed = 4,
        Calm = 5,
        Content = 6,
        Satisfied = 7,
        Delirious = 8,
        HighOnLife = 9,
        DancingInTheStreets = 10,
        SendingLovePoemsToYou = 11
    };

    public enum SponsorsMood : int {
        Unavailable = -1,
        Murderous = 0,
        Furious = 1,
        Irritated = 2,
        Calm = 3,
        Content = 4,
        Satisfied = 5,
        Delirious = 6,
        HighOnLife = 7,
        DancingInTheStreets = 8,
        SendingLovePoemsToYou = 9
    };

    public enum Weather : int {
        Unavailable = -1,
        Rain = 0,
        Overcast = 1,
        PartiallyCloudy = 2,
        Sunny = 3
    };

    public enum TeamAttitude : int {
        Unavailable = -2,
        PlayItCool = -1,
        Normal = 0,
        MatchOfTheSeason = 1
    };

    public enum TacticType : int {
        Unavailable = -1,
        Normal = 0,
        Pressing = 1,
        CounterAttacks = 2,
        AttackInTheMiddle = 3,
        AttackInWings = 4,
        PlayCreatively = 7,
        LongShots = 8
    };

    public enum TacticSkill : int {
        Unavailable = -1,
        NonExistent = 0,
        Disastrous = 1,
        Wretched = 2,
        Poor = 3,
        Weak = 4,
        Inadequate = 5,
        Passable = 6,
        Solid = 7,
        Excellent = 8,
        Formidable = 9,
        Outstanding = 10,
        Brilliant = 11,
        Magnificent = 12,
        WorldClass = 13,
        Supernatural = 14,
        Titanic = 15,
        ExtraTerrestrial = 16,
        Mythical = 17,
        Magical = 18,
        Utopian = 19,
        Divine = 20
    };

    public enum PlayerSkill : int {
        Unavailable = -1,
        NonExistent = 0,
        Disastrous = 1,
        Wretched = 2,
        Poor = 3,
        Weak = 4,
        Inadequate = 5,
        Passable = 6,
        Solid = 7,
        Excellent = 8,
        Formidable = 9,
        Outstanding = 10,
        Brilliant = 11,
        Magnificent = 12,
        WorldClass = 13,
        Supernatural = 14,
        Titanic = 15,
        ExtraTerrestrial = 16,
        Mythical = 17,
        Magical = 18,
        Utopian = 19,
        Divine = 20
    };

    public enum CoachSkill : int {
        Unavailable = -1,
        NonExistent = 0,
        Disastrous = 1,
        Wretched = 2,
        Poor = 3,
        Weak = 4,
        Inadequate = 5,
        Passable = 6,
        Solid = 7,
        Excellent = 8
    };

    public enum Leadership : int {
        Unavailable = -1,
        NonExistent = 0,
        Disastrous = 1,
        Wretched = 2,
        Poor = 3,
        Weak = 4,
        Inadequate = 5,
        Passable = 6,
        Solid = 7,
        Excellent = 8
    };

    public enum PlayerForm : int {
        Unavailable = -1,
        NonExistent = 0,
        Disastrous = 1,
        Wretched = 2,
        Poor = 3,
        Weak = 4,
        Inadequate = 5,
        Passable = 6,
        Solid = 7,
        Excellent = 8
    };

    public enum ScoutingNetwork : int {
        Unavailable = -1,
        NonExistent = 0,
        Disastrous = 1,
        Wretched = 2,
        Poor = 3,
        Weak = 4,
        Inadequate = 5,
        Passable = 6,
        Solid = 7,
        Excellent = 8
    };

    public enum FormationExperience : int {
        Unavailable = -1,
        Poor = 3,
        Weak = 4,
        Inadequate = 5,
        Passable = 6,
        Solid = 7,
        Excellent = 8,
        Formidable = 9,
        Outstanding = 10
    };

    public enum SectorRating : int {
        Unavailable = -1,
        NonExistent = 0,
        DisastrousVeryLow = 1,
        DisastrousLow = 2,
        DisastrousHigh = 3,
        DisastrousVeryHigh = 4,
        WretchedVeryLow = 5,
        WretchedLow = 6,
        WretchedHigh = 7,
        WretchedVeryHigh = 8,
        PoorVeryLow = 9,
        PoorLow = 10,
        PoorHigh = 11,
        PoorVeryHigh = 12,
        WeakVeryLow = 13,
        WeakLow = 14,
        WeakHigh = 15,
        WeakVeryHigh = 16,
        InadequateVeryLow = 17,
        InadequateLow = 18,
        InadequateHigh = 19,
        InadequateVeryHigh = 20,
        PassableVeryLow = 21,
        PassableLow = 22,
        PassableHigh = 23,
        PassableVeryHigh = 24,
        SolidVeryLow = 25,
        SolidLow = 26,
        SolidHigh = 27,
        SolidVeryHigh = 28,
        ExcellentVeryLow = 29,
        ExcellentLow = 30,
        ExcellentHigh = 31,
        ExcellentVeryHigh = 32,
        FormidableVeryLow = 33,
        FormidableLow = 34,
        FormidableHigh = 35,
        FormidableVeryHigh = 36,
        OutstandingVeryLow = 37,
        OutstandingLow = 38,
        OutstandingHigh = 39,
        OutstandingVeryHigh = 40,
        BrilliantVeryLow = 41,
        BrilliantLow = 42,
        BrilliantHigh = 43,
        BrilliantVeryHigh = 44,
        MagnificentVeryLow = 45,
        MagnificentLow = 46,
        MagnificentHigh = 47,
        MagnificentVeryHigh = 48,
        WorldClassVeryLow = 49,
        WorldClassLow = 50,
        WorldClassHigh = 51,
        WorldClassVeryHigh = 52,
        SupernaturalVeryLow = 53,
        SupernaturalLow = 54,
        SupernaturalHigh = 55,
        SupernaturalVeryHigh = 56,
        TitanicVeryLow = 57,
        TitanicLow = 58,
        TitanicHigh = 59,
        TitanicVeryHigh = 60,
        ExtraTerrestrialVeryLow = 61,
        ExtraTerrestrialLow = 62,
        ExtraTerrestrialHigh = 63,
        ExtraTerrestrialVeryHigh = 64,
        MythicalVeryLow = 65,
        MythicalLow = 66,
        MythicalHigh = 67,
        MythicalVeryHigh = 68,
        MagicalVeryLow = 69,
        MagicalLow = 70,
        MagicalHigh = 71,
        MagicalVeryHigh = 72,
        UtopianVeryLow = 73,
        UtopianLow = 74,
        UtopianHigh = 75,
        UtopianVeryHigh = 76,
        DivineVeryLow = 77,
        DivineLow = 78,
        DivineHigh = 79,
        DivineVeryHigh = 80
    };

    public enum FanSeasonExpectation : int {
        Unavailable = -1,
        WeAreNotWorthyOfThisDivision = 0,
        EveryDayInThisDivisionIsBonus = 1,
        WeWillHaveToFightToStayUp = 2,
        AMidTableFinishIsNice = 3,
        WeBelongInTheTopFour = 4,
        AimForTheTitle = 5,
        WeHaveToWinThisSeason = 6,
        WeAreSoMuchBetterThanThisDivision = 7
    };

    public enum FanMatchExpectation : int {
        Unavailable = -1,
        BetterNotShowUp = 0,
        WeAreOutclassed = 1,
        WeWillLose = 2,
        TheyAreFavourites = 3,
        TheyHaveTheEdge = 4,
        ItWillBeCloseAffair = 5,
        WeHaveTheEdge = 6,
        WeAreFavourites = 7,
        WeWillWin = 8,
        PieceOfCake = 9,
        LetsHumiliateThem = 10
    };

    public enum Agreeability : int {
        Unavailable = -1,
        NastyFellow = 0,
        ControversialPerson = 1,
        PleasantGuy = 2,
        SympatheticGuy = 3,
        PopularGuy = 4,
        BelovedTeamMember = 5
    };

    public enum Honesty : int {
        Unavailable = -1,
        Infamous = 0,
        Dishonest = 1,
        Honest = 2,
        Upright = 3,
        Righteous = 4,
        Saintly = 5
    };

    public enum Aggressiveness : int {
        Unavailable = -1,
        Tranquil = 0,
        Calm = 1,
        Balanced = 2,
        Temperamental = 3,
        Fiery = 4,
        Unstable = 5
    };

    public enum TeamSpirit : int {
        Unavailable = -1,
        LikeTheColdWar = 0,
        Murderous = 1,
        Furious = 2,
        Irritated = 3,
        Composed = 4,
        Calm = 5,
        Content = 6,
        Satisfied = 7,
        Delirious = 8,
        WalkingOnClouds = 9,
        ParadiseOnEarth = 10
    };

    public enum TeamConfidence : int {
        CompletelyExaggerated = 9,
        Exaggerated = 8,
        SlightlyExaggerated = 7,
        Wonderful = 6,
        Strong = 5,
        Decent = 4,
        Poor = 3,
        Wretched = 2,
        Disastrous = 1,
        NonExistent = 0,
        Unavailable = -1
    };

    public enum Role : int {
        Unavailable = -1,
        SetPieces = 17,
        Captain = 18,
        ReplacedPlayer1 = 19,
        ReplacedPlayer2 = 20,
        ReplacedPlayer3 = 21,
        PenaltyTaker1 = 22,
        PenaltyTaker2 = 23,
        PenaltyTaker3 = 24,
        PenaltyTaker4 = 25,
        PenaltyTaker5 = 26,
        PenaltyTaker6 = 27,
        PenaltyTaker7 = 28,
        PenaltyTaker8 = 29,
        PenaltyTaker9 = 30,
        PenaltyTaker10 = 31,
        PenaltyTaker11 = 32,
        Keeper = 100,
        RightBack = 101,
        RightCentralDefender = 102,
        MiddleCentralDefender = 103,
        LeftCentralDefender = 104,
        LeftBack = 105,
        RightWinger = 106,
        RightInnerMidfield = 107,
        MiddleInnerMidfield = 108,
        LeftInnerMidfield = 109,
        LeftWinger = 110,
        RightForward = 111,
        MiddleForward = 112,
        LeftForward = 113,
        SubstitutionKeeper = 114,
        SubstitutionDefender = 115,
        InnerMidfield = 116,
        SubstitutionWinger = 117,
        SubstitutionForward = 118
    };

    public enum PositionCode : int {
        Unavailable = -1,
        Keeper = 1,
        Rightback = 2,
        CentralDefender1 = 3,
        CentralDefender2 = 4,
        LeftBack = 5,
        RightWinger = 6,
        InnerMidfield1 = 7,
        InnerMidfield2 = 8,
        LeftWinger = 9,
        Forward1 = 10,
        Forward2 = 11
    };

    public enum PlayerCategory : int {
        Unavailable = -1,
        NoCategorySet = 0,
        Keeper = 1,
        Wingback = 2,
        CentralDefender = 3,
        Winger = 4,
        InnerMidfield = 5,
        Forward = 6,
        Substitute = 7,
        Reserve = 8,
        Extra1 = 9,
        Extra2 = 10
    };

    public enum FieldPositionCode : int {
        Unavailable = -1,
        Keeper = 1,
        Defender = 2,
        DefenderOffensive = 3,
        DefenderTowardsWing = 4,
        Wingback = 5,
        WingbackDefensive = 6,
        WingbackTowardsMiddle = 7,
        WingbackOffensive = 8,
        Winger = 9,
        WingerDefensive = 10,
        WingerTowardsMiddle = 11,
        WingerOffensive = 12,
        InnerMidfield = 13,
        InnerMidfieldDefensive = 14,
        InnerMidfieldTowardsWing = 15,
        InnerMidfieldOffensive = 16,
        Forward = 17,
        ForwardDefensive = 18,
        ForwardTowardsWing = 19
    };

    public enum Behaviour : int {
        Unavailable = -1,
        Normal = 0,
        Offensive = 1,
        Defensive = 2,
        TowardsMiddle = 3,
        TowardsWing = 4,
        ExtraForward = 5,
        ExtraInnerMidfield = 6,
        ExtraDefender = 7
    };

    public enum PlayerSkillTypes : int {
        Form = 0,
        Stamina = 1,
        Experience = 2,
        Leadership = 3,
        Loyalty = 4,
        Keeper = 5,
        Defending = 6,
        Playmaking = 7,
        Winger = 8,
        Passing = 9,
        Scoring = 10,
        SetPieces = 11,
        MotherClubMonus = 12
    };

    public enum ColumnTables : int {
        Players = 0,
        LeagueDetails = 1,
        LeagueFixtures = 2
    };

    public enum TableColumns : int {
        Undefined = -1,
        Player_ID = 0,
        Player_FirstName = 1,
        Player_LastName = 2,
        Player_FullName = 3,
        Player_Number = 4,
        Player_Nationality = 5,
        Player_LastPosition = 6,
        Player_Health = 7,
        Player_Warnings = 8,
        Player_Category = 9,
        Player_AgeYears = 10,
        Player_AgeDays = 11,
        Player_AgeFull = 12,
        Player_TSI = 13,
        Player_Form = 14,
        Player_Stamina = 15,
        Player_Keeping = 16,
        Player_Defending = 17,
        Player_Wing = 18,
        Player_Playmaking = 19,
        Player_Passing = 20,
        Player_Scoring = 21,
        Player_SetPieces = 22
    };
}
