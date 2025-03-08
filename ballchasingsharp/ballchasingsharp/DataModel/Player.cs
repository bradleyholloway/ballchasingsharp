namespace BallchasingSharp
{
    public class Player
    {
        internal Player()
        {
        }

        public string Name { get; internal set; }

        public string Platform { get; internal set; }

        public string PlatformId { get; internal set; }

        public Stats Stats { get; internal set; }

        public Stats CumulativeGroupStats { get; internal set; }

        public Stats GameAverageGroupStats { get; internal set; }

        public int? Score { get; internal set; }
    }
}
