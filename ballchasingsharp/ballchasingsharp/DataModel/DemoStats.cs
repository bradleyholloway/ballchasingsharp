
namespace BallchasingSharp
{
    public class DemoStats
    {
        internal DemoStats()
        {
        }

        public double Inflicted { get; internal set; }
        public double Taken { get; internal set; }

        internal static DemoStats Cumulative(DemoStats demo1, DemoStats demo2)
        {
            return new DemoStats()
            {
                Inflicted = demo1.Inflicted + demo2.Inflicted,
                Taken = demo1.Taken + demo2.Taken
            };
        }
    }
}
