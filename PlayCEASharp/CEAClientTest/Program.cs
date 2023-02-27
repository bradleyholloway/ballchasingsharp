﻿

namespace RlClientTest;
        // LeagueManager.EndpointOverride = "https://z36ny63i72.execute-api.us-east-1.amazonaws.com/staging";
        // LeagueManager.NewBracketRounds += NewRounds;
        // LeagueManager.UpdatedMatches += UpdatedMatches;
        // League league = LeagueManager.League;
        // Console.WriteLine("Done Loading.");

        // Console.WriteLine("Breakpoint before forcerefresh.");
        // LeagueManager.ForceUpdate();

        /*
        // Ad-hoc for getting info on orgs finals performances.
        TournamentConfiguration tc = ConfigurationManager.TournamentConfigurations.configurations.First();
        RequestManager rm = new RequestManager(null);
        Dictionary<string, int> wins = new Dictionary<string, int>();
        Dictionary<string, int> finals = new Dictionary<string, int>();
        foreach (KeyValuePair<Tournament, MatchResult> result in finalsMatches)
        {
            Team winner = (result.Value.HomeGamesWon > result.Value.AwayGamesWon) ? result.Value.HomeTeam : result.Value.AwayTeam;
            Team loser = (result.Value.HomeGamesWon > result.Value.AwayGamesWon) ? result.Value.AwayTeam : result.Value.HomeTeam;
            wins[winner.Org] = wins.GetValueOrDefault(winner.Org) + 1;
            finals[winner.Org] = finals.GetValueOrDefault(winner.Org) + 1;
            finals[loser.Org] = finals.GetValueOrDefault(loser.Org) + 1;
            Console.WriteLine($"{result.Value.HomeGamesWon == result.Value.AwayGamesWon}--{winner.Org},{loser.Org},{winner.Name},{loser.Name},{result.Key.GameName},{result.Key.GameId},{result.Key.TournamentName},{result.Key.SeasonYear},{result.Key.SeasonSeason}");
        }
        {
            int win = wins.GetValueOrDefault(org);
            //Console.WriteLine($"{org} {win} {finals[org]}");
        }

        PrintLeagueStats();

        // Prevent ending execution.
        Thread.Sleep(TimeSpan.FromDays(1));
    {
        Bracket playoffBracket = rm.GetBracket(t.Playoffs.BracketId, tc).Result;
        return playoffBracket.Rounds.Last().Matches.Last();
    }
    {
        foreach (KeyValuePair<BracketRound, League> r in newRounds)
        {
            Console.WriteLine($"{r.Value.GameId} {r.Key.RoundName} {r.Key.RoundId}");
        }
    }
    {
        foreach (KeyValuePair<MatchResult, League> m in updatedMatches)
        {
            Console.WriteLine($"{m.Value.GameId} {m.Key.ToString()}");
        }
    }
    {
        League league = LeagueManager.League;
        {
            foreach (Team t in round.Matches.SelectMany(m => m.Teams))
            {
                rLookup[t] = round;
            }
        }
        {
            TeamStatistics stats = teams[i].StageCumulativeRoundStats[rLookup[teams[i]]];
            //Console.WriteLine($"[{i}][{stats.MatchWins}][{stats.TotalGoalDifferential}] {teams[i]}");
            Console.WriteLine($"{teams[i]},{stats.ToCSV()}");
        }
    }