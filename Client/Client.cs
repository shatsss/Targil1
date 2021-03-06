﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientConnection
{
    class Client
    {
        private int port;
        private bool isOnline;
        public Client(int port)
        {
            this.port = port;
            isOnline = false;
        }

        public void Connect()
        {
            //try
            //{
            //    IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), this.port);
            //    TcpClient client = new TcpClient();
            //    client.Connect(ep);
            //    Console.WriteLine("You are connected");
            //    using (NetworkStream stream = client.GetStream())
            //    using (StreamReader reader = new StreamReader(stream))
            //    using (StreamWriter writer = new StreamWriter(stream))
            //    using (StreamWriter buffer = new StreamWriter(stream))
            //    {
            //        Task t = new Task(() =>
            //        {
            //            Console.Write("Please enter a command: \n");

            //            while (true)
            //            {

            //                string input = reader.ReadLine();
            //                if (input != null)
            //                {
            //                    Console.WriteLine(input);
            //                }
            //            }

            //        });
            //        t.Start();
            //        // Send data to server

            //        while (true)
            //        {
            //            buffer.Flush();
            //            buffer.Write(Console.ReadLine() + "\n");
            //        }
            //        client.Close();

            //    }
            //}
            //catch (SocketException)
            //{
            //    Console.WriteLine("EXCEPTION!");
            //}

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), this.port);
            TcpClient client = null;
            NetworkStream stream = null;
            StreamReader reader = null;
            StreamWriter writer = null;
            Thread sendThread = null;
            Task recieveTask = null;
            Action action = new Action(() =>
            {
                while (true)
                {
                    try
                    {
                        string result = reader.ReadLine();
                        if (result.Contains("close connection"))
                        {
                            isOnline = false;
                            client.Close();
                            break;
                        }
                        if (result.Contains("keep open"))
                        {
                            continue;
                        }
                        if (result != "")
                        {
                            Console.WriteLine(result);
                        }
                    }
                    catch (Exception)
                    {
                        isOnline = false;
                        client.Close();
                    }
                }
            });
            sendThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Please enter a command: \n");
                        string input = Console.ReadLine();
                        if (!isOnline)
                        {

                            //  Console.WriteLine("You are connected");
                            client = new TcpClient();
                            client.Connect(ep);
                            stream = client.GetStream();
                            reader = new StreamReader(stream);
                            writer = new StreamWriter(stream);
                            isOnline = true;
                            recieveTask = new Task(action);
                            recieveTask.Start();
                        }
                        writer.WriteLine(input);
                        writer.Flush();
                        Thread.Sleep(200);
                    }
                    catch (Exception)
                    {
                        isOnline = false;
                        client.Close();
                    }
                }
            });
            sendThread.Start();
        }


    }
}