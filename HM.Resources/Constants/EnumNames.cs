using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Resources.Constants {
    public class EnumNames {
        public static string[] PlayerSkillNames = { "Non Existent", "Disastrous", "Wretched", "Poor", "Weak", "Inadequate", "Passable", "Solid", "Excellent", "Formidable", "Outstanding", "Brilliant", "Magnificent", "World Class", "Supernatural", "Titanic", "Extra Terrestrial", "Mythical", "Magical", "Utopian", "Divine" };
        public static string[] PlayerFormNames = { "Non Existent", "Disastrous", "Wretched", "Poor", "Weak", "Inadequate", "Passable", "Solid", "Excellent" };
        public static string[] PlayerLeadershipNames = { "Non Existent", "Disastrous", "Wretched", "Poor", "Weak", "Inadequate", "Passable", "Solid", "Excellent" };

        public static Dictionary<Role, string> MatchRoles = new Dictionary<Role, string> { { Role.SetPieces, "Set Pieces" }, { Role.Captain, "Captain" }, { Role.ReplacedPlayer1, "Replaced Player #1" }, { Role.ReplacedPlayer2, "Replaced Player #2" }, { Role.ReplacedPlayer3, "Replaced Player #3" }, { Role.PenaltyTaker1, "Penalty Taker (1)" }, { Role.PenaltyTaker2, "Penalty Taker (2)" }, { Role.PenaltyTaker3, "Penalty Taker (3)" }, { Role.PenaltyTaker4, "Penalty Taker (4)" }, { Role.PenaltyTaker5, "Penalty Taker (5)" }, { Role.PenaltyTaker6, "Penalty Taker (6)" }, { Role.PenaltyTaker7, "Penalty Taker (7)" }, { Role.PenaltyTaker8, "Penalty Taker (8)" }, { Role.PenaltyTaker9, "Penalty Taker (9)" }, { Role.PenaltyTaker10, "Penalty Taker (10)" }, { Role.PenaltyTaker11, "Penalty Taker (11)" }, { Role.Keeper, "Keeper" }, { Role.RightBack, "Right Back" }, { Role.RightCentralDefender, "Right Central Defender" }, { Role.MiddleCentralDefender, "Middle Central Defender" }, { Role.LeftCentralDefender, "Left Central Defender" }, { Role.LeftBack, "Left Back" }, { Role.RightWinger, "Right Winger" }, { Role.RightInnerMidfield, "Right Inner Midfield" }, { Role.MiddleInnerMidfield, "Middle Inner Midfield" }, { Role.LeftInnerMidfield, "Left Inner Midfield" }, { Role.LeftWinger, "Left Winger" }, { Role.RightForward, "Right Forward" }, { Role.MiddleForward, "Middle Forward" }, { Role.LeftForward, "Left Forward" }, { Role.SubstitutionKeeper, "Substitution (Keeper)" }, { Role.SubstitutionDefender, "Substitution (Defender)" }, { Role.InnerMidfield, "Inner Midfield" }, { Role.SubstitutionWinger, "Substitution (Winger)" }, { Role.SubstitutionForward, "Substitution (Forward)" } };
    }
}
