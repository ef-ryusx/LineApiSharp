using System.Net.Http;
using System.Net.Http.Headers;

namespace LineApiSharp.Api
{
    public class AddFriendApi : LineApiBase
    {
        public override string Url => @"https://api.line.me/v2/profile";
        readonly string access_token;

        internal AddFriendApi(string access_token)
        {
            this.access_token = access_token;
        }

        protected override HttpRequestMessage CreateHttpRequestMessage()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Url);
            request.Headers.Authorization = new AuthenticationHeaderValue($"Bearer {access_token}");
            return request;
        }
    }
}
