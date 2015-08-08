using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObooltNet;

namespace SocketTest_server
{
    class Server
    {
        static void Main(string[] args)
        {
            NetConnection server = new NetConnection();
            server.OnConnect += Server_OnConnect;
            server.OnDataReceived += Server_OnDataReceived;
            server.OnDisconnect += Server_OnDisconnect;

            // server start
            server.Start(55555);

            while (true) ;
        }

        private static void Server_OnDisconnect(object sender, NetConnection connection)
        {
            Console.WriteLine("Disconnected from " + connection.RemoteEndPoint);
        }

        private static void Server_OnDataReceived(object sender, NetConnection connection, byte[] e)
        {
            Console.WriteLine("Message from " + connection.RemoteEndPoint + " : " + Encoding.UTF8.GetString(e));
        }

        private static void Server_OnConnect(object sender, NetConnection connection)
        {
            Console.WriteLine("Connection from " + connection.RemoteEndPoint);
        }
    }
}
