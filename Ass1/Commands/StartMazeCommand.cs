using Ass1;
using System.IO;
using System.Net.Sockets;


namespace Server
{
    internal class StartMazeCommand : ICommand
    {
        private IModel model;

        public StartMazeCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            MazeLib.Maze maze = this.model.GetMaze(name, rows, cols);
            Game game = new Game(client, maze);
            bool exist = this.model.AddStartGame(game, name);
            if (!exist)
            {
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine("The Game Is Exist!");
                writer.Flush();
                return "close connection";
            }
            return "keep open";
        }
    }
}