
namespace BallchasingSharp
{
    public class MovementStats
    {
        internal MovementStats()
        {
        }

        public double? AverageSpeed { get; internal set; }
        public double TotalDistance { get; internal set; }
        public double TimeSupersonicSpeed { get; internal set; }
        public double TimeBoostSpeed { get; internal set; }
        public double TimeSlowSpeed { get; internal set; }
        public double TimeGround { get; internal set; }
        public double TimeLowAir { get; internal set; }
        public double TimeHighAir { get; internal set; }
        public double TimePowerslide { get; internal set; }
        public double CountPowerslide { get; internal set; }
        public double? AveragePowerslideDuration { get; internal set; }
        public double? AverageSpeedPercentage { get; internal set; }
        public double? PercentSlowSpeed { get; internal set; }
        public double? PercentBoostSpeed { get; internal set; }
        public double? PercentSupersonicSpeed { get; internal set; }
        public double? PercentGround { get; internal set; }
        public double? PercentLowAir { get; internal set; }
        public double? PercentHighAir { get; internal set; }

        internal static MovementStats Cumulative(MovementStats a, MovementStats b, double? totalDuration)
        {
            return new MovementStats()
            {
                TotalDistance = a.TotalDistance + b.TotalDistance,
                TimeSupersonicSpeed = a.TimeSupersonicSpeed + b.TimeSupersonicSpeed,
                TimeBoostSpeed = a.TimeBoostSpeed + b.TimeBoostSpeed,
                TimeSlowSpeed = a.TimeSlowSpeed + b.TimeSlowSpeed,
                TimeGround = a.TimeGround + b.TimeGround,
                TimeLowAir = a.TimeLowAir + b.TimeLowAir,
                TimeHighAir = a.TimeHighAir + b.TimeHighAir,
                TimePowerslide = a.TimePowerslide + b.TimePowerslide,
                CountPowerslide = a.CountPowerslide + b.CountPowerslide,
                AveragePowerslideDuration = (a.TimePowerslide + b.TimePowerslide) * 100 / (a.CountPowerslide + b.CountPowerslide),
                PercentSupersonicSpeed = (a.TimeSupersonicSpeed + b.TimeSupersonicSpeed) * 100 / totalDuration,
                PercentBoostSpeed = (a.TimeBoostSpeed + b.TimeBoostSpeed) * 100 / totalDuration,
                PercentSlowSpeed = (a.TimeSlowSpeed + b.TimeSlowSpeed) * 100 / totalDuration,
                PercentGround = (a.TimeGround + b.TimeGround) * 100 / totalDuration,
                PercentLowAir = (a.TimeLowAir + b.TimeLowAir) * 100 / totalDuration,
                PercentHighAir = (a.TimeHighAir + b.TimeHighAir) * 100 / totalDuration,
            };
        }
    }
}
