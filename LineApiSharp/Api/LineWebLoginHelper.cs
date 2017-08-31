using System;

namespace LineApiSharp.Api
{
    /// <summary>
    /// https://developers.line.me/web-api/integrating-web-login
    /// </summary>
    public class LineWebLoginHelper
    {
        static readonly string baseUrl = @"https://access.line.me/dialog/oauth/weblogin";
        static readonly string response_type = "code";
        readonly string client_id;
        readonly string redirect_uri; // need to url encode
        readonly string state;

        internal LineWebLoginHelper(string client_id, string redirect_uri, string state)
        {
            this.client_id = client_id;
            this.redirect_uri = redirect_uri;
            this.state = state;
        }

        public Uri CreateUri() => new Uri(CreateUrlString());

        public string CreateUrlString() => (client_id.IsNullOrEmpty() || redirect_uri.IsNullOrEmpty() || state.IsNullOrEmpty())
            ? throw new Exception("Unexpected parameter error")
            : $"{baseUrl}?response_type={response_type}&client_id={client_id}&redirect_uri={System.Web.HttpUtility.UrlEncode(redirect_uri)}&state={state}";
    }
}
