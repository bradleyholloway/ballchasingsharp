﻿using PlayCEASharp.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayCEASharp.Configuration
{
    /// <summary>
    /// The configuration used to model the relation of brackets for a League.
    /// This configuration is generated by the ConfigurationGenerator at runtime.
    /// </summary>
    public class BracketConfiguration
    {
        /// <summary>
        /// The lists of bracketIds that comprise the bracket sets for the league.
        /// </summary>
        public string[][] bracketSets { get; internal set; }

        /// <summary>
        /// Mapping from roundName => stageName for each round.
        /// </summary>
        public Dictionary<string, string> stageConfiguration { get; internal set; }

        /// <summary>
        /// The collection of stage groups for each stage.
        /// </summary>
        public StageGroup[] stageGroups { get; internal set; }

        /// <summary>
        /// Lookup the stage for a given round.
        /// </summary>
        /// <param name="roundName">The stage name if the stage exists.</param>
        /// <returns></returns>
        public string StageLookup(string roundName)
        {
            string str;
            return this.stageConfiguration.TryGetValue(roundName, out str) ? str : "default_stage";
        }
    }
}
