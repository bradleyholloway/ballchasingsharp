
namespace BallchasingSharp
{
    public class CoreStats
    {
        internal CoreStats()
        {
        }

        public double Shots { get; internal set; }
        public double ShotsAgainst { get; internal set; }
        public double Goals { get; internal set; }
        public double GoalsAgainst { get; internal set; }
        public double Saves { get; internal set; }
        public double Assists { get; internal set; }
        public double Score { get; internal set; }
        public bool? MVP { get; internal set; }
        public double ShootingPercentage { get; internal set; }

        internal static CoreStats Cumulative(CoreStats core1, CoreStats core2, double? totalDuration)
        {
            return new CoreStats()
            {
                Shots = core1.Shots + core2.Shots,
                ShotsAgainst = core1.ShotsAgainst + core2.ShotsAgainst,
                Goals = core1.Goals + core2.Goals,
                GoalsAgainst = core1.GoalsAgainst + core2.GoalsAgainst,
                Saves = core1.Saves + core2.Saves,
                Assists = core1.Saves + core2.Saves,
                Score = core1.Score + core2.Score,
                MVP = null,
                ShootingPercentage = (core1.Goals + core2.Goals) * 100 / (core1.Shots + core2.Shots)
            };
        }
    }
}
