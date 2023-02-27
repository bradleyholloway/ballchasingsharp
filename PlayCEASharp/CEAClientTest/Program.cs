using PlayCEASharp.Configuration;
using PlayCEASharp.DataModel;
using PlayCEASharp.RequestManagement;

namespace BallchasingSharpClientTest;public class Program {    public static void Main()    {
        BallchasingConfiguration configuration = ConfigurationManager.BallchasingConfiguration;
        RequestManager rm = new RequestManager(configuration.BallchasingApiKey);
        Replay replay = rm.GetReplay("c82c5a4a-3092-43fd-9e43-e1c9bc16fcd6").Result;

        Console.WriteLine(replay);
    }}