using Newtonsoft.Json;

namespace LineApiSharp.Messages
{
    public class MessageAction : ILineImagemapAction
    {
        internal MessageAction(string text, ImagemapArea area)
        {
            Text = text;
            Area = area;
        }

        [JsonProperty("type")]
        public string Type => LineMessageType.MESSAGE_ACTION;
        [JsonProperty("text")]
        public string Text { get; private set; }
        [JsonProperty("area")]
        public ImagemapArea Area { get; private set; }
    }
}
