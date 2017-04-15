using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using MazeGeneratorLib;
using MazeLib;
namespace Ass1
{
    public class Game
    {
        TcpClient client1;
        TcpClient client2;
        Maze maze;
        public Game(TcpClient client, Maze maze)
        {
            this.client1 = client;
            this.maze = maze;
        }
        public void Join(TcpClient client)
        {
            this.client2 = client;
        }
    }
}
