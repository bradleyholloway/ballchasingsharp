namespace BallchasingSharp
{
    public class ReplayList
    {
        internal ReplayList()
        {
            Replays = new List<Replay>();
        }

        public int Count { get; internal set; }

        public List<Replay> Replays { get; }
    }
}
