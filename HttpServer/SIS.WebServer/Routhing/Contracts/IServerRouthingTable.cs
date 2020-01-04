using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer.Routhing.Contracts
{
    public interface IServerRouthingTable
    {
        void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpResponse> func);
        bool Contains(HttpRequestMethod requestMethod,string path);
        Func<IHttpRequest,IHttpResponse> Get(HttpRequestMethod requestMethod,string path);
    }
}
