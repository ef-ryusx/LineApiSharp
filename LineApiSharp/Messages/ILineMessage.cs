namespace LineApiSharp.Messages
{
    /// <summary>
    /// https://devdocs.line.me/ja/#send-message-object
    /// </summary>
    public interface ILineMessage
    {
        string Type { get; }
    }

    public interface ILineImagemapAction : ILineMessage
    { }

    public class LineMessageType
    {
        public const string TEXT = "text";
        public const string IMAGEMAP = "imagemap";
        public const string URI_ACTION = "uri";
        public const string MESSAGE_ACTION = "message";
    }
}
