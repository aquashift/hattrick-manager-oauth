﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Resources.Constants {
    public static class QueryString {
        public const string Achievements = "file=achievements&version=1.1";
        public const string ArenaDetails = "file=arenadetails&version=1.4";
        public const string Club = "file=club&version=1.2";
        public const string Economy = "file=economy&version=1.2";
        public const string Fans = "file=fans&version=1.1";
        public const string LeagueDetails = "file=leaguedetails&version=1.4";
        public const string LeagueFixtures = "file=leaguefixtures&version=1.2";
        public const string Matches = "file=matches&version=2.6";
        public const string MatchesArchiveAll = "file=matchesarchive&teamID={0}&FirstMatchDate={1}&LastMatchDate={2}&isYouth={3}&version=1.1";
        public const string MatchesArchiveCurrent = "file=matchesarchive&teamID={0}&isYouth={1}&version=1.1";
        public const string MatchDetails = "file=matchdetails&matchID={0}&matchEvents=true&version=1.8";
        public const string MatchLineup = "file=matchlineup&teamid={0}&matchID={1}&version=1.4";
        public const string Players = "file=players&orderby=PlayerID&includeMatchInfo=true&version=2.2";
        public const string PlayerDetails = "file=playerdetails&includeMatchInfo=true&playerId={0}&version=2.3";
        public const string TeamDetails = "file=team&teamId={0}&version=2.3";
        public const string Training = "file=training&version=1.5";
        public const string TransfersTeam = "file=transfersTeam&TeamID={0}&pageIndex={1}&version=1.1";
        public const string TransfersPlayer = "file=transfersPlayer&playerID={0}&version=1.1";
        public const string UserBasicData = "file=teamdetails&version=2.6";
        public const string WorldDetails = "file=worlddetails&version=1.4";
    }
}
