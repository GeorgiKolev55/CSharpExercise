using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.HTTP.Headers
{
    class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;
        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }
        public void AddHeader(HttpHeader header)
        {
            headers.Add(header.Key,header);
        }

        public bool ContainsHeader(string key)
        {
            if (headers.ContainsKey(key))
            {
                return true;
            }
            return false;
        }

        public HttpHeader GetHeader(string key)
        {
            if (headers.ContainsKey(key))
            {
                return headers[key];
            }
            return null;
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.headers.Values.Select(x=>x.ToString
            ()));
        }
    }
}
