using System.Net.Http;
using System.Net.Http.Headers;

namespace LineApiSharp.Api
{
    /// <summary>
    /// Getting user profiles
    /// https://devdocs.line.me/ja/#getting-user-profiles
    /// </summary>
    public class UserProfileApi : LineApiBase
    {
        public override string Url => @"https://api.line.me/v2/profile";
        readonly string access_token;

        internal UserProfileApi(string access_token)
        {
            this.access_token = access_token;
        }

        protected override HttpRequestMessage CreateHttpRequestMessage()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            request.Headers.Authorization = new AuthenticationHeaderValue($"Bearer {access_token}");
            return request;
        }
    }
}
