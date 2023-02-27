using Newtonsoft.Json.Linq;
using PlayCEASharp.Configuration;
using PlayCEASharp.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PlayCEASharp.RequestManagement
{
    /// <summary>
    /// Class for marshalling responses from ballchasing.com into C# objects.
    /// </summary>
    internal static class Marshaller
    {
        internal static Replay Replay(JToken replayToken)
        {
            Replay replay = new Replay((string)replayToken["id"]);
            replay.BlueTeam = Team(replayToken["blue"]);
            replay.OrangeTeam = Team(replayToken["orange"]);
            replay.BlueGoals = int.Parse((string)replayToken["blue"]["stats"]["core"]["goals"]);
            replay.OrangeGoals = int.Parse((string)replayToken["orange"]["stats"]["core"]["goals"]);
            return replay;
        }

        internal static Team Team(JToken teamToken)
        {
            Team team = new Team();
            team.Name = (string)teamToken["name"];
            foreach (JToken playerToken in teamToken["players"])
            {
                team.Players.Add(Player(playerToken));
            }

            return team;
        }

        internal static Player Player(JToken playerToken)
        {
            Player player = new Player();
            player.Name = (string)playerToken["name"];
            player.Platform = (string)playerToken["id"]["platform"];
            player.PlatformId = (string)playerToken["id"]["id"];
            return player;
        }


    }
}
