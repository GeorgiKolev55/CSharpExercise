using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString,nameof(requestString));
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
        }
        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString.Split(new[] { GlobalConstants.HttpNewLine }, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }
            ParseRequestMethod(requestLine);
            ParseRequestUrl(requestLine);
            ParseRequestPath();
            ParseRequestHeaders(ParsePlainRequestHeaders(splitRequestContent).ToArray());
            ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }

        private void ParseRequestMethod (string[] requestLine)
        {
            HttpRequestMethod method;
            bool result= HttpRequestMethod.TryParse(requestLine[0],true,out method);
            if (!result)
            {
                throw new BadRequestException(string.Format(GlobalConstants.UnsupportedHttpMethodEceptionMessage,requestLine[0]));
            }
            this.RequestMethod = method;
        }
        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }
        private void ParseRequestPath() 
        {
            this.Path = this.Url.Split('?')[0];
        }
        private void ParseRequestParameters(string requestBody)
        {

        }
        private void ParseRequestQueryParameters()
        {
            this.Url.Split('?')[1].Split('&').Select(plainQueryParameter => plainQueryParameter.Split('='))
                 .ToList().ForEach(quertParameterKeyValuePair => this.QueryData[quertParameterKeyValuePair[0]] = quertParameterKeyValuePair[1]);
        }
        private void ParseRequestFormParameters (string requestBody)
        {
            requestBody.Split('?')[1].Split('&').Select(plainQueryParameter => plainQueryParameter.Split('='))
                 .ToList().ForEach(quertParameterKeyValuePair => this.FormData[quertParameterKeyValuePair[0]] = quertParameterKeyValuePair[1]);
        }
        private bool IsValidRequestLine(string[] requestLine)
        {
            if (requestLine.Length==3 && requestLine[2] == GlobalConstants.HttpOneProtocolFragment)
            {
                return true;
            }
            return false;
        }
        private void ParseRequestHeaders(string[] plainHeaders)
        {
            plainHeaders.Select(plainHeaders => plainHeaders.Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList().ForEach(headerKeyValuePair => this.Headers.AddHeader(new HttpHeader(headerKeyValuePair[0], headerKeyValuePair[1])));
        }
        private bool IsValidRequestedQueryString(string[] requestLine)
        {
            string[] splitQuery = requestLine[1].Split('=');
            if ((!string.IsNullOrEmpty(requestLine[1]))&& splitQuery.Length>=2)
            {
                return true;
            }
            return false;
        }
        private IEnumerable<string> ParsePlainRequestHeaders(string[] requestLines)
        {
            for (int i = 0; i < requestLines.Length -1; i++)
            {
                if (!string.IsNullOrEmpty(requestLines[i]))
                {
                    yield return requestLines[i];
                }
            }
        }
    }
}
