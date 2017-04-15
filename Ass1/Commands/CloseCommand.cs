using Ass1;
using System.IO;
using System;
using System.Net.Sockets;


namespace Server
{
    internal class CloseCommand : ICommand
    {
        private IModel model;

        public CloseCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            Game game = this.model.GetGame(name);
            if (game == null)
            {
                writer.WriteLine("The Game Is Not Exist!");
                writer.Flush();
                return "keep open";
            }
            else
            {
                this.model.DeleteGame(name);
                stream = game.GetFirstClient().GetStream();
                writer = new StreamWriter(stream);
                writer.WriteLine("the game is closed, close connection!");
                Console.WriteLine("Server- close connection"); ;
                stream = game.GetSecondClient().GetStream();
                writer = new StreamWriter(stream);
                writer.WriteLine("the game is closed, close connection!");
                return "close connection";
            }

        }
    }
}