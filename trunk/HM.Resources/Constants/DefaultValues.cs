using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Resources.Constants {
    public static class DefaultValues {
        public const decimal ArenaBasicIncome = 65M;
        public const decimal ArenaTerracesIncome = 95M;
        public const decimal ArenaRoofIncome = 180M;
        public const decimal ArenaVipIncome = 325M;
        public const decimal ArenaBasicCost = 5M;
        public const decimal ArenaTerracesCost = 7M;
        public const decimal ArenaRoofCost = 10M;
        public const decimal ArenaVipCost = 25M;
        public const decimal ArenaBasicBuild = 450M;
        public const decimal ArenaTerracesBuild = 770M;
        public const decimal ArenaRoofBuild = 900M;
        public const decimal ArenaVipBuild = 3000M;
        public const decimal ArenaBasicDemolish = 60M;
        public const decimal ArenaTerracesDemolish = 60M;
        public const decimal ArenaRoofDemolish = 60M;
        public const decimal ArenaVipDemolish = 60M;
        public static string[] PlayerSkillNames = {"Non Existent", "Disastrous", "Wretched", "Poor", "Weak", "Inadequate", "Passable", "Solid", "Excellent", "Formidable", "Outstanding", "Brilliant", "Magnificent", "World Class", "Supernatural", "Titanic", "Extra Terrestrial", "Mythical", "Magical", "Utopian", "Divine"};
        public static Dictionary<int, string> MatchRoles = new Dictionary<int, string> { { 17, "Set Pieces"}, { 18, "Captain"}, { 19, "Replaced Player #1"}, { 20, "Replaced Player #2"}, { 21, "Replaced Player #3"}, { 22, "Penalty Taker (1)"}, { 23, "Penalty Taker (2)"}, { 24, "Penalty Taker (3)"}, { 25, "Penalty Taker (4)"}, { 26, "Penalty Taker (5)"}, { 27, "Penalty Taker (6)"}, { 28, "Penalty Taker (7)"}, { 29, "Penalty Taker (8)"}, { 30, "Penalty Taker (9)"}, { 31, "Penalty Taker (10)"}, { 32, "Penalty Taker (11)"}, { 100, "Keeper"}, { 101, "Right Back"}, { 102, "Right Central Defender"}, { 103, "Middle Central Defender"}, { 104, "Left Central Defender"}, { 105, "Left Back"}, { 106, "Right Winger"}, { 107, "Right Inner Midfield"}, { 108, "Middle Inner Midfield"}, { 109, "Left Inner Midfield"}, { 110, "Left Winger"}, { 111, "Right Forward"}, { 112, "Middle Forward"}, { 113, "Left Forward"}, { 114, "Substitution (Keeper)"}, { 115, "Substitution (Defender)"}, { 116, "Inner Midfield"}, { 117, "Substitution (Winger)"}, { 118, "Substitution (Forward)"}};
    }
}
