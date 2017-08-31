using LineApiSharp.Api;

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
    }
}
