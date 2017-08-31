namespace LineApiSharp.Messages
{
    /// <summary>
    /// https://devdocs.line.me/ja/#send-message-object
    /// </summary>
    public interface ILineMessage
    {
        string Type { get; }
    }

    public class LineMessageType
    {
        public const string TEXT = "text";
    }
}
