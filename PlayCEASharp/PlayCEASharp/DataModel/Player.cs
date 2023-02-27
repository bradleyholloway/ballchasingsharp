namespace PlayCEASharp.DataModel
{
    /// <summary>
    /// Represents a single game in PlayCEA.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Creates a game with the given game id in PlayCEA.
        /// </summary>
        /// <param name="id">The gid field in PlayCEA.</param>
        internal Player()
        {
        }

        public string Name { get; internal set; }

        public string Platform { get; internal set; }

        public string PlatformId { get; internal set; }
    }
}
