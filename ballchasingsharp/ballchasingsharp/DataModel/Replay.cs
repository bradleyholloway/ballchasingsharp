namespace BallchasingSharp
{
    public class Replay
    {
        internal Replay(string id)
        {
            this.ReplayId = id;
        }

        public override string ToString()
        {
            return this.ReplayId;
        }

        public string ReplayId { get; }

        public string RocketLeagueId { get; internal set; }

        public string MatchGuid { get; internal set; }

        public Team BlueTeam { get; internal set; }
        public Team OrangeTeam { get; internal set; }

        public string Link { get; internal set; }
        public string? MatchType { get; internal set; }
        public int? TeamSize { get; internal set; }
        public int Duration { get; internal set; }
        public bool Overtime { get; internal set; }
        public int? OvertimeSeconds { get; internal set; }
        public DateTime Date { get; internal set; }

        public List<ReplayGroup> ReplayGroups { get; internal set; }

    }
}
