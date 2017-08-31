using LineApiSharp.Messages;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LineApiSharp.Api
{
    /// <summary>
    /// https://devdocs.line.me/ja/#multicast
    /// </summary>
    public class MulticastMessagingApi : LineApiBase
    {
        public override string Url => @"https://api.line.me/v2/bot/message/multicast";
        readonly string contentType = @"application/json";
        readonly string channelAccessToken;
        IEnumerable<string> to;
        IEnumerable<ILineMessage> messages;

        internal MulticastMessagingApi(string channelAccessToken, IEnumerable<string> to, IEnumerable<ILineMessage> messages)
        {
            this.channelAccessToken = channelAccessToken;
            this.to = to;
            this.messages = messages;
        }
        
        protected override HttpRequestMessage CreateHttpRequestMessage()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Url);
            request.Headers.Authorization = new AuthenticationHeaderValue($"Bearer {channelAccessToken}");
            return request;
        }
    }
}
