using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObooltNet;

namespace SocketTest
{
    class Client
    {
        static void Main(string[] args)
        {
            NetConnection client = new NetConnection();
            client.OnConnect += Client_OnConnect;
            client.OnDataReceived += Client_OnDataReceived;
            client.OnDisconnect += Client_OnDisconnect;

            client.Connect("localhost", 55555);

            while (true)
            {
                Console.WriteLine(">>>");
                client.Send(Encoding.UTF8.GetBytes(Console.ReadLine()));
            }
        }

        private static void Client_OnDataReceived(object sender, NetConnection connection, byte[] e)
        {
            Console.WriteLine("Message from server " + Encoding.UTF8.GetString(e));
        }

        private static void Client_OnDisconnect(object sender, NetConnection connection)
        {
            Console.WriteLine("Disconnected from " + connection.RemoteEndPoint);
        }

        private static void Client_OnConnect(object sender, NetConnection connection)
        {
            Console.WriteLine("Connection to " + connection.RemoteEndPoint);
        }
    }
}
