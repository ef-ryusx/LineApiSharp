using LineApiSharp.Api;
using LineApiSharp.Messages;
using System.Collections.Generic;

namespace LineApiSharp
{
    /// <summary>
    /// Factory to create Line Api class
    /// </summary>
    public class LineApiFactory
    {
        public static LineWebLoginHelper CreateLineWebLoginHelper(string client_id, string redirect_uri, string state)
            => new LineWebLoginHelper(client_id, redirect_uri, state);

        public static ILineApi CreateLoginAccessTokenApi(string client_id, string client_secret, string code, string redirect_uri)
            => new LoginAccessTokenApi(client_id, client_secret, code, redirect_uri);

        public static ILineApi CreateChannelAccessTokenApi(string client_id, string client_secret)
            => new ChannelAccessTokenApi(client_id, client_secret);

        public static ILineApi CreateUserProfileApi(string access_token) => new UserProfileApi(access_token);

        public static ILineApi CreateAddFriendApi(string access_token) => new AddFriendApi(access_token);

        public static ILineApi CreateMulticastMessagingApi(string channelAccessToken, IEnumerable<string> to, IEnumerable<ILineMessage> messages)
            => new MulticastMessagingApi(channelAccessToken, to, messages);

        public static ILineMessage CreateTextMessage(string text) => new TextMessage(text);

        public static ILineImagemapAction CreateUriAction(string linkUri, int x, int y, int width, int height)
            => new UriAction(linkUri, CreateImagemapArea(x, y, width, height));

        public static ILineImagemapAction CreateUriAction(string linkUri, ImagemapArea imagemapArea) => new UriAction(linkUri, imagemapArea);

        public static ILineImagemapAction CreateMessageAction(string text, int x, int y, int width, int height)
            => new UriAction(text, CreateImagemapArea(x, y, width, height));

        public static ILineImagemapAction CreateMessageAction(string text, ImagemapArea imagemapArea) => new UriAction(text, imagemapArea);

        public static ImagemapArea CreateImagemapArea(int x, int y, int width, int height) => new ImagemapArea(x, y, width, height);

        public static ILineMessage CreateImagemapMessage(string baseUrl, string altText, int width, int height, IEnumerable<ILineImagemapAction> actions) 
            => new ImagemapMessage(baseUrl, altText, width, height, actions);

    }
}
