namespace PlayCEASharp.DataModel
{
    /// <summary>
    /// Represents a single game in PlayCEA.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Creates a game with the given game id in PlayCEA.
        /// </summary>
        /// <param name="id">The gid field in PlayCEA.</param>
        internal Team()
        {
            Players = new List<Player>();
        }

        /// <summary>
        /// The gid in PlayCEA.
        /// </summary>
        public string Name { get; internal set; }

        public List<Player> Players { get; internal set; }
    }
}
