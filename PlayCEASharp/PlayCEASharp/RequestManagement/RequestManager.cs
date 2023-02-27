using Newtonsoft.Json.Linq;
using PlayCEASharp.Configuration;
using PlayCEASharp.DataModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlayCEASharp.RequestManagement
{
    /// <summary>
    /// Wraps requests to the api endpoints for PlayCEA.
    /// </summary>
    internal class RequestManager
    {
        /// <summary>
        /// The HttpClient to use when issuing requests.
        /// </summary>
        private readonly HttpClient client = new HttpClient();

        /// <summary>
        /// The base api endpoint for PlayCEA.
        /// </summary>
        private const string apiEndpoint = "https://ballchasing.com/api";

        /// <summary>
        /// The endpoint override.
        /// </summary>
        private string endpoint;

        /// <summary>
        /// The api key to use for authorization.
        /// </summary>
        private string apiKey;

        /// <summary>
        /// Creates a new request manager.
        /// </summary>
        internal RequestManager(string apiKey, string? optionalEndpoint=null)
        {
            this.endpoint = optionalEndpoint ?? apiEndpoint;
            this.apiKey = apiKey;
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Add("User-Agent", "BallchasingSharp");
            this.client.DefaultRequestHeaders.Add("Authorization", apiKey);
        }

        /// <summary>
        /// Gets a bracket from PlayCEA.
        /// </summary>
        /// <param name="bracketId">The bracket id to read.</param>
        /// <returns>The fully populated Bracket.</returns>
        internal async Task<Replay> GetReplay(string replayId)
        {
            string content = await this.client.GetStringAsync($"{endpoint}/replays/{replayId}");
            JObject jObject = JObject.Parse(content);
            Replay replay = Marshaller.Replay(jObject);
            return replay;
        }

        
    }
}
