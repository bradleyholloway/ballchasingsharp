using PlayCEASharp.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayCEASharp.Configuration
{
    /// <summary>
    /// The configuration to scope to which tournaments to analyze.
    /// </summary>
    public class BallchasingConfiguration
    {
        /// <summary>
        /// List of MatchingConfigurations to listen to.
        /// </summary>
        public string BallchasingApiKey { get; set; }
    }
}
