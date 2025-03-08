namespace BallchasingSharp
{
    public class Stats
    {
        internal Stats()
        {
        }

        public BallStats Ball { get; internal set; }
        public CoreStats Core { get; internal set; }

        public BoostStats Boost { get; internal set; }

        public MovementStats Movement { get; internal set; }
        public PositioningStats Positioning { get; internal set; }
        public DemoStats Demo { get; internal set; }
        public int? Games { get; internal set; }
        public int? Wins { get; internal set; }
        public double? WinPercentage { get; internal set; }
        public double? PlayDuration { get; internal set; }

        public static Stats Cumulative(Stats a, Stats b)
        {
            double? totalDuration = a.PlayDuration + b.PlayDuration;
            return new Stats() {
                Core = CoreStats.Cumulative(a.Core, b.Core, totalDuration),
                Boost = BoostStats.Cumulative(a.Boost, b.Boost, totalDuration),
                Movement = MovementStats.Cumulative(a.Movement, b.Movement, totalDuration),
                Positioning = PositioningStats.Cumulative(a.Positioning, b.Positioning, totalDuration),
                Demo = DemoStats.Cumulative(a.Demo, b.Demo),
                Games = a.Games + b.Games,
                Wins = a.Wins + b.Wins,
                WinPercentage = (a.Wins + b.Wins) * 100 / (a.Games + b.Games),
                PlayDuration = totalDuration
            };
        }
    }
}
