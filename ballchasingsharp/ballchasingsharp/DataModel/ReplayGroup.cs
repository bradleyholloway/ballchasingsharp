namespace BallchasingSharp
{
    public class ReplayGroup
    {
        internal ReplayGroup(string id)
        {
            this.GroupId = id;
            this.Players = new List<Player>();
            this.Teams = new List<Team>();
        }

        public override string ToString()
        {
            return this.GroupId;
        }

        public string GroupId { get; }

        public string Link { get; internal set; }

        public List<Player> Players { get; }
        public List<Team> Teams { get; }

    }
}
