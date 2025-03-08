namespace BallchasingSharp
{
    public class Team
    {
        internal Team()
        {
            Players = new List<Player>();
        }

        public string Name { get; internal set; }

        public int? Goals { get; internal set; }

        public List<Player> Players { get; internal set; }

        public Stats Stats { get; internal set; }

        public Stats CumulativeGroupStats { get; internal set; }

        public Stats GameAverageGroupStats { get; internal set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
