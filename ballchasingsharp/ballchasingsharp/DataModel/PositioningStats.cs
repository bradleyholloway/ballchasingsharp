
namespace BallchasingSharp
{
    public class PositioningStats
    {
        internal PositioningStats()
        {
        }

        public double? AverageDistanceToBall { get; internal set; }
        public double? AverageDistanceToBallPossession { get; internal set; }
        public double? AverageDistanceToBallNoPossession { get; internal set; }
        public double? AverageDistanceToMates { get; internal set; }
        public double TimeDefensiveThird { get; internal set; }
        public double TimeNeutralThird { get; internal set; }
        public double TimeOffensiveThird { get; internal set; }
        public double TimeDefensiveHalf { get; internal set; }
        public double TimeOffensiveHalf { get; internal set; }
        public double TimeBehindBall { get; internal set; }
        public double TimeInfrontBall { get; internal set; }
        public double? TimeMostBack { get; internal set; }
        public double? TimeMostForward { get; internal set; }
        public double? TimeClosestToBall { get; internal set; }
        public double? TimeFarthestFromBall { get; internal set; }
        public double? PercentDefensiveThird { get; internal set; }
        public double? PercentOffensiveThird { get; internal set; }
        public double? PercentNeutralThird { get; internal set; }
        public double? PercentDefensiveHalf { get; internal set; }
        public double? PercentOffensiveHalf { get; internal set; }
        public double? PercentBehindBall { get; internal set; }
        public double? PercentInfrontBall { get; internal set; }
        public double? PercentMostBack { get; internal set; }
        public double? PercentMostForward { get; internal set; }
        public double? PercentClosestToBall { get; internal set; }
        public double? PercentFarthestFromBall { get; internal set; }
        public double? GoalsAgainstWhileLastDefender { get; internal set; }

        internal static PositioningStats Cumulative(PositioningStats a, PositioningStats b, double? totalDuration)
        {
            return new PositioningStats()
            {
                TimeDefensiveThird = a.TimeDefensiveThird + b.TimeDefensiveThird,
                TimeNeutralThird = a.TimeNeutralThird + b.TimeNeutralThird,
                TimeOffensiveThird = a.TimeOffensiveThird + b.TimeOffensiveThird,
                TimeDefensiveHalf = a.TimeDefensiveHalf + b.TimeDefensiveHalf,
                TimeOffensiveHalf = a.TimeOffensiveHalf + b.TimeOffensiveHalf,
                TimeBehindBall = a.TimeBehindBall + b.TimeBehindBall,
                TimeInfrontBall = a.TimeInfrontBall + b.TimeInfrontBall,
                TimeMostBack = a.TimeMostBack + b.TimeMostBack,
                TimeMostForward = a.TimeMostForward + b.TimeMostForward,
                TimeClosestToBall = a.TimeClosestToBall + b.TimeClosestToBall,
                TimeFarthestFromBall = a.TimeFarthestFromBall + b.TimeFarthestFromBall,
                GoalsAgainstWhileLastDefender = a.GoalsAgainstWhileLastDefender + b.GoalsAgainstWhileLastDefender,
                PercentDefensiveThird = (a.TimeDefensiveThird + b.TimeDefensiveThird) * 100 / totalDuration,
                PercentNeutralThird = (a.TimeNeutralThird + b.TimeNeutralThird) * 100 / totalDuration,
                PercentOffensiveThird = (a.TimeOffensiveThird + b.TimeOffensiveThird) * 100 / totalDuration,
                PercentDefensiveHalf = (a.TimeDefensiveHalf + b.TimeDefensiveHalf) * 100 / totalDuration,
                PercentOffensiveHalf = (a.TimeOffensiveHalf + b.TimeOffensiveHalf) * 100 / totalDuration,
                PercentBehindBall = (a.TimeBehindBall + b.TimeBehindBall) * 100 / totalDuration,
                PercentInfrontBall = (a.TimeInfrontBall + b.TimeInfrontBall) * 100 / totalDuration,
                PercentMostBack = (a.TimeMostBack + b.TimeMostBack) * 100 / totalDuration,
                PercentMostForward = (a.TimeMostForward + b.TimeMostForward) * 100 / totalDuration,
                PercentClosestToBall = (a.TimeClosestToBall + b.TimeClosestToBall) * 100 / totalDuration,
                PercentFarthestFromBall = (a.TimeFarthestFromBall + b.TimeFarthestFromBall) * 100 / totalDuration,
            };
        }
    }
}
