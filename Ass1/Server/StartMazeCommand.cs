using Ass1;
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
            MazeLib.Maze maze = this.model.GetMaze();
            model.AddWaitingGame(name, rows, cols);
            return "keep open";
        }
    }
}