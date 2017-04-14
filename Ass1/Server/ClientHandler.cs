﻿using System;
using System.IO;
using System.Threading.Tasks;
using Server;
using System.Net.Sockets;

namespace Server
{
    public class ClientHandler: IClientHandler
    {
            private IController controller;
            public ClientHandler()
            {
                controller = new Controller();
            }
            public void HandleClient(TcpClient client)
            {
                new Task(() =>
                {

                    using (NetworkStream stream = client.GetStream())
                    using (StreamReader reader = new StreamReader(stream))
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        string commandLine = reader.ReadLine();
                        Console.WriteLine("Got command: {0}", commandLine);
                        string result = controller.ExecuteCommand(commandLine, client);
                        writer.Flush();
                        writer.Write(result);

                    }
                    //                client.Close();
                }).Start();
            }
        }
    }


