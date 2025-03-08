using System.Text.Json;

namespace BallchasingSharp
{
    internal class ConfigurationManager
    {
        private const string configurationPath = "Resources/configuration.json";
        private static object fileLock = new object();

        static ConfigurationManager()
        {
            ReadConfiguration();
        }

        internal static void ReadConfiguration()
        {
            object fileLock = ConfigurationManager.fileLock;
            lock (fileLock)
            {
                string configString = File.ReadAllText(configurationPath);
                BallchasingConfiguration = JsonSerializer.Deserialize<BallchasingConfiguration>(configString);
            }
        }

        internal static BallchasingConfiguration BallchasingConfiguration { get; private set; }
    }
}
