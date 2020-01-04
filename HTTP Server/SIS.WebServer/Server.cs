using SIS.HTTP.Common;
using SIS.WebServer.Routhing;
using SIS.WebServer.Routhing.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SIS.WebServer
{
    public class Server
    {
        private const string LocalHostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener tcpListener;

        private IServerRouthingTable serverRoutingTable;

        private bool isRunning;

        public Server(int port, ServerRoutingTable serverRoutingTable)
        {
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));

            this.port = port;
            this.serverRoutingTable = serverRoutingTable;

            this.tcpListener = new TcpListener(IPAddress.Parse(LocalHostIpAddress), port);
        }

        private void Listen(Socket client)
        {
            var connectionHandler = new ConnectionHandler(client, this.serverRoutingTable);
            connectionHandler.ProcessRequest();
        }

        public void Run()
        {
            this.tcpListener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalHostIpAddress}:{this.port}");

            while (this.isRunning)
            {
                Console.WriteLine("Waiting for client...");

                var client = this.tcpListener.AcceptSocket();

                this.Listen(client);
            }
        }
    }
}
