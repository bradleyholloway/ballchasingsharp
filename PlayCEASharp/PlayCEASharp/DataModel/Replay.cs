namespace PlayCEASharp.DataModel
{
    /// <summary>
    /// Represents a single game in PlayCEA.
    /// </summary>
    public class Replay
    {
        /// <summary>
        /// Creates a game with the given game id in PlayCEA.
        /// </summary>
        /// <param name="id">The gid field in PlayCEA.</param>
        internal Replay(string id)
        {
            this.ReplayId = id;
        }

        /// <summary>
        /// Gets a string representation of the game result.
        /// </summary>
        /// <returns>A string representing the game.</returns>
        public override string ToString()
        {
            return this.ReplayId;
        }

        /// <summary>
        /// The gid in PlayCEA.
        /// </summary>
        public string ReplayId { get; }

        public int BlueGoals { get; internal set; }

        public int OrangeGoals { get; internal set; }

        public Team BlueTeam { get; internal set; }
        public Team OrangeTeam { get; internal set; }
    }
}
