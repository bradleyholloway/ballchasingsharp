using Newtonsoft.Json.Linq;
using System.Numerics;

namespace BallchasingSharp
{
    /// <summary>
    /// Class for marshalling responses from ballchasing.com into C# objects.
    /// </summary>
    internal static class Marshaller
    {
        internal static Replay Replay(JToken replayToken)
        {
            Replay replay = new Replay((string)replayToken["id"]);
            replay.MatchGuid = (string)replayToken["match_guid"];
            replay.RocketLeagueId = (string)replayToken["rocket_league_id"];
            replay.BlueTeam = Team(replayToken["blue"]);
            replay.OrangeTeam = Team(replayToken["orange"]);
            replay.Date = (DateTime)replayToken["date"];
            replay.TeamSize = (int?)replayToken["team_size"];
            replay.MatchType = (string?)replayToken["match_type"];
            replay.Duration = (int)(replayToken["duration"] ?? 0);
            replay.Overtime = (bool)replayToken["overtime"];
            replay.OvertimeSeconds = (int?)replayToken["overtime_seconds"];
            replay.Link = (string)replayToken["link"];
            
            if (replayToken["groups"] != null)
            {
                replay.ReplayGroups = new List<ReplayGroup>();
                foreach (var groupToken in replayToken["groups"])
                {
                    replay.ReplayGroups.Add(new ReplayGroup((string)groupToken["id"]));
                }
            }

            return replay;
        }

        internal static ReplayList ReplayList(JToken replayListToken)
        {
            ReplayList replayList = new ReplayList();

            if (replayListToken["count"] == null)
            {
                replayList.Count = 0;
                return replayList;
            }

            replayList.Count = (int)replayListToken["count"];
            foreach (JToken replayToken in replayListToken["list"])
            {
                Replay replay = Replay(replayToken);
                replayList.Replays.Add(replay);
            }

            replayList.Replays.Sort((a,b) => a.Date.CompareTo(b.Date));

            return replayList;
        }

        internal static ReplayGroup ReplayGroup(JToken replayToken)
        {
            ReplayGroup replay = new ReplayGroup((string)replayToken["id"]);
            replay.Link = (string)replayToken["link"];

            if (replayToken["teams"] != null)
            {
                foreach (JToken teamToken in replayToken["teams"])
                {
                    replay.Teams.Add(Team(teamToken));
                }
            }

            if (replayToken["teams"] != null)
            {
                foreach (JToken playerToken in replayToken["players"])
                {
                    replay.Players.Add(Player(playerToken));
                }
            }
            
            return replay;
        }

        internal static Team Team(JToken teamToken)
        {
            Team team = new Team();
            team.Name = (string)teamToken["name"];
            team.Goals = (int?)teamToken["goals"];
            team.Stats = Stats(teamToken["stats"]);
            team.CumulativeGroupStats = Stats(teamToken["cumulative"]);
            team.GameAverageGroupStats = Stats(teamToken["game_average"]);
            if (teamToken["players"] != null)
            {
                foreach (JToken playerToken in teamToken["players"])
                {
                    team.Players.Add(Player(playerToken));
                }
            }

            return team;
        }

        internal static Player Player(JToken playerToken)
        {
            Player player = new Player();
            player.Name = (string)playerToken["name"];
            player.Score = (int?)playerToken["score"];
            player.Platform = (string)playerToken["platform"] ?? (string)playerToken["id"]["platform"];
            player.PlatformId = playerToken["id"] is JValue ? (string)playerToken["id"] : (string)playerToken["id"]["id"];
            player.Stats = Stats(playerToken["stats"]);
            player.CumulativeGroupStats = Stats(playerToken["cumulative"]);
            player.GameAverageGroupStats = Stats(playerToken["game_average"]);
            return player;
        }

        internal static Stats Stats(JToken statsToken)
        {
            if (statsToken == null)
            {
                return null;
            }

            Stats stats = new Stats();
            stats.Ball = BallStats(statsToken["ball"]);
            stats.Core = CoreStats(statsToken["core"]);
            stats.Boost = BoostStats(statsToken["boost"]);
            stats.Movement = MovementStats(statsToken["movement"]);
            stats.Positioning = PositioningStats(statsToken["positioning"]);
            stats.Demo = DemoStats(statsToken["demo"]);
            stats.Games = (int?)statsToken["games"];
            stats.Wins = (int?)statsToken["wins"];
            stats.WinPercentage = (double?)statsToken["win_percentage"];
            stats.PlayDuration = (double?)statsToken["play_duration"];
            return stats;
        }

        internal static BallStats BallStats(JToken ballStatsToken)
        {
            if (ballStatsToken == null)
            {
                return null;
            }

            BallStats stats = new BallStats();
            stats.PossessionTime = (double?)ballStatsToken["possession_time"];
            stats.TimeInSide = (double?)ballStatsToken["time_in_side"];
            return stats;
        }

        internal static CoreStats CoreStats(JToken coreStatsToken)
        {
            CoreStats coreStats = new CoreStats();
            coreStats.Shots = (double)coreStatsToken["shots"];
            coreStats.ShotsAgainst = (double)coreStatsToken["shots_against"];
            coreStats.Goals = (double)coreStatsToken["goals"];
            coreStats.GoalsAgainst = (double)coreStatsToken["goals_against"];
            coreStats.Saves = (double)coreStatsToken["saves"];
            coreStats.Assists = (double)coreStatsToken["assists"];
            coreStats.Score = (double)coreStatsToken["score"];
            coreStats.MVP = (bool?)coreStatsToken["mvp"];
            coreStats.ShootingPercentage = (double)coreStatsToken["shooting_percentage"];
            return coreStats;
        }

        internal static BoostStats BoostStats(JToken boostStatsToken)
        {
            BoostStats boostStats = new BoostStats();
            boostStats.BPM = (double?)boostStatsToken["bpm"];
            boostStats.BCPM = (double?)boostStatsToken["bcpm"];
            boostStats.AverageAmount = (double?)boostStatsToken["avg_amount"];
            boostStats.AmountCollected = (double)boostStatsToken["amount_collected"];
            boostStats.AmountStolen = (double)boostStatsToken["amount_stolen"];
            boostStats.AmountCollectedBig = (double)boostStatsToken["amount_collected_big"];
            boostStats.AmountCollectedSmall = (double)boostStatsToken["amount_collected_small"];
            boostStats.AmountStolenBig = (double)boostStatsToken["amount_stolen_big"];
            boostStats.AmountStolenSmall = (double)boostStatsToken["amount_stolen_small"];
            boostStats.AmountOverfill = (double)boostStatsToken["amount_overfill"];
            boostStats.AmountOverfillStolen = (double)boostStatsToken["amount_overfill_stolen"];
            boostStats.AmountUsedWhileSupersonic = (double)boostStatsToken["amount_used_while_supersonic"];
            boostStats.CountCollectedBig = (double)boostStatsToken["count_collected_big"];
            boostStats.CountCollectedSmall = (double)boostStatsToken["count_collected_small"];
            boostStats.CountStolenBig = (double)boostStatsToken["count_stolen_big"];
            boostStats.CountStolenSmall = (double)boostStatsToken["count_stolen_small"];
            boostStats.TimeZeroBoost = (double)boostStatsToken["time_zero_boost"];
            boostStats.TimeFullBoost = (double)boostStatsToken["time_full_boost"];
            boostStats.TimeBoost_0_25 = (double)boostStatsToken["time_boost_0_25"];
            boostStats.TimeBoost_25_50 = (double)boostStatsToken["time_boost_25_50"];
            boostStats.TimeBoost_50_75 = (double)boostStatsToken["time_boost_50_75"];
            boostStats.TimeBoost_75_100 = (double)boostStatsToken["time_boost_75_100"];
            boostStats.PercentZeroBoost = (double?)boostStatsToken["percent_zero_boost"];
            boostStats.PercentFullBoost = (double?)boostStatsToken["percent_full_boost"];
            boostStats.PercentBoost_0_25 = (double?)boostStatsToken["percent_boost_0_25"];
            boostStats.PercentBoost_25_50 = (double?)boostStatsToken["percent_boost_25_50"];
            boostStats.PercentBoost_50_75 = (double?)boostStatsToken["percent_boost_50_75"];
            boostStats.PercentBoost_75_100 = (double?)boostStatsToken["percent_boost_75_100"];
            return boostStats;
        }

        internal static MovementStats MovementStats(JToken movementStatsToken)
        {
            MovementStats movementStats = new MovementStats();
            movementStats.AverageSpeed = (double?)movementStatsToken["avg_speed"];
            movementStats.TotalDistance = (double)movementStatsToken["total_distance"];
            movementStats.TimeSupersonicSpeed = (double)movementStatsToken["time_supersonic_speed"];
            movementStats.TimeBoostSpeed = (double)movementStatsToken["time_boost_speed"];
            movementStats.TimeSlowSpeed = (double)movementStatsToken["time_slow_speed"];
            movementStats.TimeGround = (double)movementStatsToken["time_ground"];
            movementStats.TimeLowAir = (double)movementStatsToken["time_low_air"];
            movementStats.TimeHighAir = (double)movementStatsToken["time_high_air"];
            movementStats.TimePowerslide = (double)movementStatsToken["time_powerslide"];
            movementStats.CountPowerslide = (double)movementStatsToken["count_powerslide"];
            movementStats.AveragePowerslideDuration = (double?)movementStatsToken["avg_powerslide_duration"];
            movementStats.AverageSpeedPercentage = (double?)movementStatsToken["avg_speed_percentage"];
            movementStats.PercentSlowSpeed = (double?)movementStatsToken["percent_slow_speed"];
            movementStats.PercentBoostSpeed = (double?)movementStatsToken["percent_boost_speed"];
            movementStats.PercentSupersonicSpeed = (double?)movementStatsToken["percent_supersonic_speed"];
            movementStats.PercentGround = (double?)movementStatsToken["percent_ground"];
            movementStats.PercentLowAir = (double?)movementStatsToken["percent_low_air"];
            movementStats.PercentHighAir = (double?)movementStatsToken["percent_high_air"];
            return movementStats;
        }

        internal static PositioningStats PositioningStats(JToken positioningStatsToken)
        {
            PositioningStats positioningStats = new PositioningStats();
            positioningStats.AverageDistanceToBall = (double?)positioningStatsToken["avg_distance_to_ball"];
            positioningStats.AverageDistanceToBallPossession = (double?)positioningStatsToken["avg_distance_to_ball_possession"];
            positioningStats.AverageDistanceToBallNoPossession = (double?)positioningStatsToken["avg_distance_to_ball_no_possession"];
            positioningStats.AverageDistanceToMates = (double?)positioningStatsToken["avg_distance_to_mates"];
            positioningStats.TimeDefensiveThird = (double)positioningStatsToken["time_defensive_third"];
            positioningStats.TimeNeutralThird = (double)positioningStatsToken["time_neutral_third"];
            positioningStats.TimeOffensiveThird = (double)positioningStatsToken["time_offensive_third"];
            positioningStats.TimeDefensiveHalf = (double)positioningStatsToken["time_defensive_half"];
            positioningStats.TimeOffensiveHalf = (double)positioningStatsToken["time_offensive_half"];
            positioningStats.TimeBehindBall = (double)positioningStatsToken["time_behind_ball"];
            positioningStats.TimeInfrontBall = (double)positioningStatsToken["time_infront_ball"];
            positioningStats.TimeMostBack = (double?)positioningStatsToken["time_most_back"];
            positioningStats.TimeMostForward = (double?)positioningStatsToken["time_most_forward"];
            positioningStats.GoalsAgainstWhileLastDefender = (double?)positioningStatsToken["goals_against_while_last_defender"];
            positioningStats.TimeClosestToBall = (double?)positioningStatsToken["time_closest_to_ball"];
            positioningStats.TimeFarthestFromBall = (double?)positioningStatsToken["time_farthest_from_ball"];
            positioningStats.PercentDefensiveThird = (double?)positioningStatsToken["percent_defensive_third"];
            positioningStats.PercentNeutralThird = (double?)positioningStatsToken["percent_neutral_third"];
            positioningStats.PercentOffensiveThird = (double?)positioningStatsToken["percent_offensive_third"];
            positioningStats.PercentDefensiveHalf = (double?)positioningStatsToken["percent_defensive_half"];
            positioningStats.PercentOffensiveHalf = (double?)positioningStatsToken["percent_offensive_half"];
            positioningStats.PercentBehindBall = (double?)positioningStatsToken["percent_behind_ball"];
            positioningStats.PercentInfrontBall = (double?)positioningStatsToken["percent_infront_ball"];
            positioningStats.PercentMostBack = (double?)positioningStatsToken["percent_most_back"];
            positioningStats.PercentMostForward = (double?)positioningStatsToken["percent_most_forward"];
            positioningStats.PercentClosestToBall = (double?)positioningStatsToken["percent_closest_to_ball"];
            positioningStats.PercentFarthestFromBall = (double?)positioningStatsToken["percent_farthest_from_ball"];
            return positioningStats;
        }

        internal static DemoStats DemoStats(JToken demoStatsToken)
        {
            DemoStats demoStats = new DemoStats();
            demoStats.Taken = (double)demoStatsToken["taken"];
            demoStats.Inflicted = (double)demoStatsToken["inflicted"];
            return demoStats;
        }
    }
}
