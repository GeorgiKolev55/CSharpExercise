using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responses;
using SIS.WebServer;
using SIS.WebServer.Result;
using SIS.WebServer.Routhing;
using System;
using System.Globalization;
using System.Text;

namespace webServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(HttpRequestMethod.Get, "/", httpRequest
                =>
            {
                return new HtmlResult("<h1>Hello World!<h1>", HttpResponseStatusCode.Ok);
            });

            Server server = new Server(8000, serverRoutingTable);
            server.Run();
        }
    }
}
