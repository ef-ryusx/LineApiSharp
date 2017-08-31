using System;
using System.Collections.Generic;
using System.Net.Http;

namespace LineApiSharp.Api
{
    /// <summary>
    /// https://developers.line.me/web-api/integrating-web-login
    /// </summary>
    public class LoginAccessTokenApi : LineApiBase
    {
        public override string Url => @"https://api.line.me/v2/oauth/accessToken";
        static readonly string grant_type = "authorization_code";
        readonly string code;
        readonly string client_id;
        readonly string client_secret;
        readonly string redirect_uri;

        internal LoginAccessTokenApi(string client_id, string client_secret, string code, string redirect_uri)
        {
            this.client_id = client_id;
            this.client_secret = client_secret;
            this.code = code;
            this.redirect_uri = redirect_uri;
        }

        protected override HttpRequestMessage CreateHttpRequestMessage() 
            => new HttpRequestMessage(HttpMethod.Post, Url) { Content = CreateRequestContent() };
        
        FormUrlEncodedContent CreateRequestContent()
            => (client_id.IsNullOrEmpty() || client_secret.IsNullOrEmpty() || code.IsNullOrEmpty() || redirect_uri.IsNullOrEmpty())
            ? throw new Exception($"Unexpected parameter error:{GetType().FullName}")
            : new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", grant_type },
                { "code",   code },
                { "client_id", client_id },
                { "client_secret", client_secret },
                { "redirect_uri", redirect_uri }
            });
    }
}
