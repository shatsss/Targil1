using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConnection
{
    public class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client(8000);
            c.Connect();
        }
    }
}
