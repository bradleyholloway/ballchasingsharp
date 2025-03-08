using BallchasingSharp;

namespace BallchasingSharpClientTest;public class Program {    public static void Main()    {
        BallchasingConfiguration configuration = ConfigurationManager.BallchasingConfiguration;
        RequestManager rm = new RequestManager(configuration.BallchasingApiKey);

        var group = rm.GetReplaysInGroup("09-28-hottest-wheelies-vs-adobe--s2xf4u4liy").Result;


        //Replay replay = rm.GetReplay("be5243ce-ba23-4703-bd8d-ba8f2ad8ca76").Result;
        // ReplayGroup group = rm.GetReplayGroup("viva-rocket-lega-blue-vs-ford-br-ib7einsfry").Result;
        // ReplayList groupList = rm.GetReplaysInGroup("viva-rocket-lega-blue-vs-ford-br-ib7einsfry").Result;



        //rm.CreateReplayGroup("Test Replay Group Creation", "cea-spring-24-6zos2uhkn1").Wait();
        //rm.AddReplaysToGroup("test-replay-group-creation-b74rd42g7g", ).Wait();

        // Replay replay1 = rm.GetReplay("c128e487-9a7f-4375-8f6f-5804df4965c5").Result;
        // Replay replay2 = rm.GetReplay("02884a1e-df06-4d13-8a70-d803653461eb").Result;
        // Replay replay3 = rm.GetReplay("fb24e575-b8e5-4436-bb31-dfe08944cee6").Result;

        //string steamUserId = "76561198340871012";
        //List<Replay> replays = rm.ListReplays(string.Empty, $"steam:{steamUserId}", "private", replayDateAfter:new DateTime(2023, 10, 1), count: 30).Result;
        //List<Replay> populatedReplays = DedoupMatches(replays, rm);
        //List<Replay> BestOf5 = GetFirstToSeries(populatedReplays, 3);
        //string groupId = CreateReplayGroupForReplays("Test Best of 5 Group", BestOf5, rm, "cea-spring-2024-yr90oqm7gm");

        Console.WriteLine();
    }    public static string CreateReplayGroupForReplays(string groupName, List<Replay> replays, RequestManager rm, string parentGroup=null)
    {
        string groupId = rm.CreateReplayGroup(groupName, parentGroup).Result;

        foreach (Replay replay in replays)
        {
            rm.AddReplayToGroup(replay.ReplayId, groupId).Wait();
        }

        return groupId;
    }    public static List<Replay> DedoupMatches(List<Replay> replays, RequestManager rm)
    {
        HashSet<string> matchGuids = new HashSet<string>();
        return replays.Select(r => rm.GetReplay(r.ReplayId).Result).Where(r =>
        {
            if (matchGuids.Contains(r.MatchGuid))
            {
                return false;
            }
            matchGuids.Add(r.MatchGuid);
            return true;
        }).ToList();
    }    public static List<Replay> GetFirstToSeries(List<Replay> replays, int firstTo)
    {
        List<Replay> orderedReplays = replays.OrderByDescending(r => r.Date).ToList();
        List<Replay> results = new List<Replay>();
        int blueWins = 0, orangeWins = 0;
        foreach (Replay replay in orderedReplays)
        {
            if (replay.BlueTeam.Stats.Core.Goals > replay.OrangeTeam.Stats.Core.Goals)
            {
                blueWins++;
                results.Add(replay);
            }
            else if (replay.BlueTeam.Stats.Core.Goals < replay.OrangeTeam.Stats.Core.Goals)
            {
                orangeWins++;
                results.Add(replay);
            }

            if (blueWins >= firstTo || orangeWins >= firstTo)
            {
                break;
            }
        }

        results.Reverse();
        return results;
    }}