using Ass1;
using Newtonsoft.Json;
using System.IO;
using System.Net.Sockets;
using System;


namespace Server
{
    internal class PlayCommand : ICommand
    {
        private IModel model;

        public PlayCommand(IModel model)
        {
            this.model = model;
        }
        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        public string Execute(string[] args, TcpClient client = null)
        {
             string direction = args[0];
             Game game = this.model.FindGameByClient(client);
             NestedPlay play = new NestedPlay(game.GetMaze().Name,direction);
             TcpClient clientOpponent = game.GetOpponent(client);
             NetworkStream stream = clientOpponent.GetStream();
             StreamWriter writer = new StreamWriter(stream);
             writer.WriteLine(JsonConvert.SerializeObject(play));
             writer.Flush();
            return "keep open";
        }
        public class NestedPlay
        {
            public string Name;
            public string Direction;
            public NestedPlay(string name, string direction)
            {
                this.Name = name;
                this.Direction = direction;
            }
        }
    }
}