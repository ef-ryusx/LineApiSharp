using Newtonsoft.Json;

namespace LineApiSharp.Messages
{
    public class ImagemapArea
    {
        internal ImagemapArea(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        [JsonProperty("x")]
        public int X { get; private set; }
        [JsonProperty("y")]
        public int Y { get; private set; }
        [JsonProperty("width")]
        public int Width { get; private set; }
        [JsonProperty("heigh")]
        public int Height { get; private set; }
    }
}
