using Ass1;
using System.IO;
using System.Net.Sockets;


namespace Server
{
    internal class JoinMazeCommand : ICommand
    {
        private IModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="JoinMazeCommand"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public JoinMazeCommand(IModel model)
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
            string name = args[0];
            Game game = this.model.FindGame(name);
            if (game != null)
            {
                game.Join(client);
                return "keep open";
            }
            else
            {
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine("U Cannt Join This Game!");
                return "close connection";
            }
        }
    }
}