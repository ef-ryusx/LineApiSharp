using Newtonsoft.Json;

namespace LineApiSharp.Messages
{
    public class UriAction : ILineImagemapAction
    {
        internal UriAction(string linkUri, ImagemapArea imagemapArea)
        {
            LinkUri = linkUri;
            Area = imagemapArea;
        }

        [JsonProperty("type")]
        public string Type => LineMessageType.URI_ACTION;
        [JsonProperty("linkUri")]
        public string LinkUri { get; private set; }
        [JsonProperty("area")]
        public ImagemapArea Area { get; private set; }
    }
}
