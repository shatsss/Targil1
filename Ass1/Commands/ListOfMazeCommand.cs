
using Ass1;
using System;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    internal class ListOfMazeCommand : ICommand
    {
        private IModel model;

        public ListOfMazeCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(JsonConvert.SerializeObject(model.GetList()));
            writer.Flush();
            return "close connection";
        }
    }
}
