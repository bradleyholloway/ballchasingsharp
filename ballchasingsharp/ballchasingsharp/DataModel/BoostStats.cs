
namespace BallchasingSharp
{
    public class BoostStats
    {
        internal BoostStats()
        {
        }

        public double? BPM { get; internal set; }
        public double? BCPM { get; internal set; }
        public double? AverageAmount { get; internal set; }
        public double AmountCollected { get; internal set; }
        public double AmountStolen { get; internal set; }
        public double AmountCollectedBig { get; internal set; }
        public double AmountStolenBig { get; internal set; }
        public double AmountCollectedSmall { get; internal set; }
        public double AmountStolenSmall { get; internal set; }
        public double AmountOverfill { get; internal set; }
        public double AmountOverfillStolen { get; internal set; }
        public double AmountUsedWhileSupersonic { get; internal set; }
        public double CountCollectedBig { get; internal set; }
        public double CountCollectedSmall { get; internal set; }
        public double CountStolenBig { get; internal set; }
        public double CountStolenSmall { get; internal set; }
        public double TimeZeroBoost { get; internal set; }
        public double? PercentZeroBoost { get; internal set; }
        public double TimeFullBoost { get; internal set; }
        public double? PercentFullBoost { get; internal set; }
        public double TimeBoost_0_25 { get; internal set; }
        public double TimeBoost_25_50 { get; internal set; }
        public double TimeBoost_50_75 { get; internal set; }
        public double TimeBoost_75_100 { get; internal set; }
        public double? PercentBoost_0_25 { get; internal set; }
        public double? PercentBoost_25_50 { get; internal set; }
        public double? PercentBoost_50_75 { get; internal set; }
        public double? PercentBoost_75_100 { get; internal set; }

        internal static BoostStats Cumulative(BoostStats a, BoostStats b, double? totalDuration)
        {
            return new BoostStats()
            {
                AmountCollected = a.AmountCollected + b.AmountCollected,
                AmountStolen = a.AmountStolen + b.AmountStolen,
                AmountCollectedBig = a.AmountCollectedBig + b.AmountCollectedBig,
                AmountStolenBig = a.AmountStolenBig + b.AmountStolenBig,
                AmountCollectedSmall = a.AmountCollectedSmall + b.AmountCollectedSmall,
                AmountStolenSmall = a.AmountStolenSmall + b.AmountStolenSmall,
                AmountOverfill = a.AmountOverfill + b.AmountOverfill,
                AmountOverfillStolen = a.AmountOverfillStolen + b.AmountOverfillStolen,
                AmountUsedWhileSupersonic = a.AmountUsedWhileSupersonic + b.AmountUsedWhileSupersonic,
                CountCollectedBig = a.CountCollectedBig + b.CountCollectedBig,
                CountCollectedSmall = a.CountCollectedSmall + b.CountCollectedSmall,
                CountStolenBig = a.CountStolenBig + b.CountStolenBig,
                CountStolenSmall = a.CountStolenSmall + b.CountStolenSmall,
                TimeZeroBoost = a.TimeZeroBoost + b.TimeZeroBoost,
                TimeFullBoost = a.TimeFullBoost + b.TimeFullBoost,
                TimeBoost_0_25 = a.TimeBoost_0_25 + b.TimeBoost_0_25,
                TimeBoost_25_50 = a.TimeBoost_25_50 + b.TimeBoost_25_50,
                TimeBoost_50_75 = a.TimeBoost_50_75 + b.TimeBoost_50_75,
                TimeBoost_75_100 = a.TimeBoost_75_100 + b.TimeBoost_75_100,
                PercentZeroBoost = (a.TimeZeroBoost + b.TimeZeroBoost) * 100 / totalDuration,
                PercentFullBoost = (a.TimeFullBoost + b.TimeFullBoost) * 100 / totalDuration,
                PercentBoost_0_25 = (a.TimeBoost_0_25 + b.TimeBoost_0_25) * 100 / totalDuration,
                PercentBoost_25_50 = (a.TimeBoost_25_50 + b.TimeBoost_25_50) * 100 / totalDuration,
                PercentBoost_50_75 = (a.TimeBoost_50_75 + b.TimeBoost_50_75) * 100 / totalDuration,
                PercentBoost_75_100 = (a.TimeBoost_75_100 + b.TimeBoost_75_100) * 100 / totalDuration,
            };
        }
    }
}
