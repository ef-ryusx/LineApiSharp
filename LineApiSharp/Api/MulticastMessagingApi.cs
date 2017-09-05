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
        readonly string _channelAccessToken;
        IEnumerable<string> _to;
        IEnumerable<ILineMessage> _messages;

        internal MulticastMessagingApi(string channelAccessToken, IEnumerable<string> to, IEnumerable<ILineMessage> messages)
        {
            _channelAccessToken = channelAccessToken;
            _to = to;
            _messages = messages;
        }

        public string GetJsonContents() => Newtonsoft.Json.JsonConvert.SerializeObject(new
        {
            to = _to,
            messages = _messages
        });

        protected override HttpRequestMessage CreateHttpRequestMessage()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Url);
            request.Headers.Authorization = new AuthenticationHeaderValue($"Bearer {_channelAccessToken}");
            request.Content = new StringContent(GetJsonContents(), Enc, contentType);
            return request;
        }
    }
}
