﻿using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
        }
        public HttpResponse(HttpResponseStatusCode statusCode) :this()
        {
            CoreValidator.ThrowIfNull(statusCode, nameof(statusCode));
            this.StatusCode = statusCode;
        }
        public HttpResponseStatusCode StatusCode { get ; set ; }

        public IHttpHeaderCollection Headers { get;}

        public byte[] Content { get ; set; }

        public void AddHeader(HttpHeader header)
        {
            Headers.AddHeader(header);
        }

        public byte[] GetBytes()
        {
            byte[] httpResponseBytesWithoutBody= Encoding.UTF8.GetBytes(ToString());
            byte[] httpResponseBytesWithBody = new byte[httpResponseBytesWithoutBody.Length + Content.Length];

            for (int i =0; i < httpResponseBytesWithoutBody.Length; i++)
            {
                httpResponseBytesWithBody[i] = httpResponseBytesWithoutBody[i];
            }
            for (int i= 0;i < httpResponseBytesWithBody.Length-httpResponseBytesWithoutBody.Length; i++)
            {
                httpResponseBytesWithBody[i+httpResponseBytesWithoutBody.Length-1] = Content[i];
            }
            return httpResponseBytesWithBody;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetStatusLine()}").Append(GlobalConstants.HttpNewLine)
                .Append(this.Headers).Append(GlobalConstants.HttpNewLine);
            result.Append(GlobalConstants.HttpNewLine);
            return result.ToString(); 
        }
    }
}
