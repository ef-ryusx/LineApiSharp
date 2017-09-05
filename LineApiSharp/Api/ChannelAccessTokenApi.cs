using System;
using System.Collections.Generic;
using System.Net.Http;

namespace LineApiSharp.Api
{
    public class ChannelAccessTokenApi : LineApiBase
    {
        public override string Url => @"https://api.line.me/v2/oauth/accessToken";
        static readonly string grant_type = "client_credentials";
        readonly string client_id;
        readonly string client_secret;

        internal ChannelAccessTokenApi(string client_id, string client_secret)
        {
            this.client_id = client_id;
            this.client_secret = client_secret;
        }

        /*
         * {
         *      Method: POST,
         *      RequestUri: 'https://api.line.me/v2/oauth/accessToken',
         *      Version: 1.1,
         *      Content: System.Net.Http.FormUrlEncodedContent,
         *      Headers: {
         *          Content-Type: application/x-www-form-urlencoded
         *          Content-Length:xx
         *      }
         *  }
         */
        protected override HttpRequestMessage CreateHttpRequestMessage() 
            => new HttpRequestMessage(HttpMethod.Post, Url) { Content = CreateRequestContent() };

        FormUrlEncodedContent CreateRequestContent() => (client_id.IsNullOrEmpty() || client_secret.IsNullOrEmpty())
            ? throw new Exception($"Unexpected parameter error:{GetType().FullName}")
            : new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", grant_type },
                { "client_id", client_id },
                { "client_secret", client_secret }
            });
    }
}
