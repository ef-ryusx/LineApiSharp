using Newtonsoft.Json;
using System.Collections.Generic;

namespace LineApiSharp.Messages
{
    public class ImagemapMessage : ILineMessage
    {
        internal ImagemapMessage(
            string baseUrl,
            string altText,
            int width,
            int height,
            IEnumerable<ILineImagemapAction> actions)
        {
            BaseUrl = baseUrl;
            AltText = altText;
            Width = width;
            Height = height;
            Actions = actions;
        }

        [JsonProperty("type")]
        public string Type => LineMessageType.IMAGEMAP;
        [JsonProperty("baseUrl")]
        public string BaseUrl { get; private set; }
        [JsonProperty("altText")]
        public string AltText { get; private set; }
        [JsonProperty("width")]
        public int Width { get; private set; }
        [JsonProperty("height")]
        public int Height { get; private set; }
        [JsonProperty("actions")]
        public IEnumerable<ILineImagemapAction> Actions { get; private set; }
    }
}
