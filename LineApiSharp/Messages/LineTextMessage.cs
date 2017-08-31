namespace LineApiSharp.Messages
{
    public class LineTextMessage : ILineMessage
    {
        public string Type => LineMessageType.TEXT;
        public string Text;
    }
}
