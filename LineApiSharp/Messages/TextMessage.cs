using Newtonsoft.Json;

namespace LineApiSharp.Messages
{
    public class TextMessage : ILineMessage
    {
        internal TextMessage(string text)
        {
            Text = text;
        }

        [JsonProperty("type")]
        public string Type => LineMessageType.TEXT;
        [JsonProperty("text")]
        public string Text { get; private set; }
    }
}
