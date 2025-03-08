using System.Globalization;
using System.Text;
using Newtonsoft.Json.Linq;
namespace BallchasingSharp
{
    public class RequestManager
    {
        private readonly HttpClient client = new HttpClient();

        private const string apiEndpoint = "https://ballchasing.com/api";

        private string endpoint;

        private string apiKey;

        public RequestManager(string apiKey, string? optionalEndpoint=null)
        {
            this.endpoint = optionalEndpoint ?? apiEndpoint;
            this.apiKey = apiKey;
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Add("User-Agent", "BallchasingSharp");
            this.client.DefaultRequestHeaders.Add("Authorization", apiKey);
        }

        public async Task<Replay> GetReplay(string replayId)
        {
            string content = await GetContentWithRetryBackoff($"{endpoint}/replays/{replayId}");
            JObject jObject = JObject.Parse(content);
            Replay replay = Marshaller.Replay(jObject);
            return replay;
        }

        public async Task<ReplayGroup> GetReplayGroup(string groupId)
        {
            string content = await GetContentWithRetryBackoff($"{endpoint}/groups/{groupId}");
            JObject jObject = JObject.Parse(content);
            ReplayGroup group = Marshaller.ReplayGroup(jObject);
            return group;
        }

        public async Task<ReplayList> GetReplaysInGroup(string groupId)
        {
            string content = await GetContentWithRetryBackoff($"{endpoint}/replays?group={groupId}");
            JObject jObject = JObject.Parse(content);
            ReplayList replayList = Marshaller.ReplayList(jObject);
            return replayList;
        }

        public async Task<List<Replay>> ListReplays(string playerName, string playerId, string playlist=null, string uploaderSteamId=null, DateTime? replayDateAfter=null, DateTime? replayDateBefore=null, int count=10)
        {
            StringBuilder ps = new StringBuilder();
            ps.Append($"player-name={playerName}");
            ps.Append($"&player-id={playerId}");
            if (playlist!= null)
            {
                ps.Append($"&playlist={playlist}");
            }
            if (uploaderSteamId != null)
            {
                ps.Append($"&uploader={uploaderSteamId}");
            }
            if (replayDateAfter != null)
            {
                ps.Append($"&replay-date-after={ToRfc3339String(replayDateAfter)}");
            }
            if (replayDateBefore != null)
            {
                ps.Append($"&replay-date-before={ToRfc3339String(replayDateBefore)}");
            }
            ps.Append($"&count={count}");

            string content = await GetContentWithRetryBackoff($"{endpoint}/replays?{ps.ToString()}");
            JObject jObject = JObject.Parse(content);
            List<Replay> replays = new List<Replay>();
            foreach (JObject replayObject in jObject["list"])
            {
                Replay replay = Marshaller.Replay(replayObject);
                replays.Add(replay);
            }

            return replays;
        }

        private async Task<string> GetContentWithRetryBackoff(string requestPath)
        {
            HttpResponseMessage response;

            int MaxRetryCount = 5;
            for (int i = 0; i <= MaxRetryCount; i++)
            {
                response = await this.client.GetAsync(requestPath);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests && i < MaxRetryCount)
                {
                    await Task.Delay(1000);
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                }
            }

            return null;
        }

        public async Task<string> CreateReplayGroup(string name, string parentId=null, bool playerById=true, bool canSub=true)
        {
            string player_identitification = playerById ? "by-id" : "by-name";
            string team_identification = canSub ? "by-player-clusters" : "by-distinct-players";
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.Append("{");
            contentBuilder.Append($"\"name\": \"{name}\",");
            if (parentId != null)
            {
                contentBuilder.Append($"\"parent\": \"{parentId}\",");
            }

            contentBuilder.Append($"\"player_identification\": \"{player_identitification}\",");
            contentBuilder.Append($"\"team_identification\": \"{team_identification}\"");
            contentBuilder.Append("}");

            HttpContent httpContent = new StringContent(contentBuilder.ToString());
            string content = await PostWithRetryBackoff($"{endpoint}/groups", httpContent);
            JObject jObject = JObject.Parse(content);
            
            return (string)jObject["id"];
        }

        private async Task<string> PostWithRetryBackoff(string requestPath, HttpContent content)
        {
            HttpResponseMessage response;

            int MaxRetryCount = 5;
            for (int i = 0; i <= MaxRetryCount; i++)
            {
                response = await this.client.PostAsync(requestPath, content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests && i < MaxRetryCount)
                {
                    await Task.Delay(1000);
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                }
            }

            return null;
        }

        public async Task AddReplayToGroup(string replayId, string replayGroupId)
        {
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.Append("{");
            contentBuilder.Append($"\"group\": \"{replayGroupId}\"");
            contentBuilder.Append("}");

            HttpContent httpContent = new StringContent(contentBuilder.ToString());
            await PatchWithRetryBackoff($"{endpoint}/replays/{replayId}", httpContent);
        }

        private async Task PatchWithRetryBackoff(string requestPath, HttpContent content)
        {
            HttpResponseMessage response;

            int MaxRetryCount = 5;
            for (int i = 0; i <= MaxRetryCount; i++)
            {
                response = await this.client.PatchAsync(requestPath, content);
                if (response.IsSuccessStatusCode)
                {
                    return;
                }

                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests && i < MaxRetryCount)
                {
                    await Task.Delay(1000);
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        private static string ToRfc3339String(DateTime? dateTime)
        {
            return dateTime.Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);
        }
    }
}
