using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LineApiSharp.Api
{
    public interface ILineApi
    {
        string Url { get; }
        Encoding Encoding { get; }
        Task<string> Request();
    }

    public abstract class LineApiBase : ILineApi
    {
        public abstract string Url { get; }
        public virtual Encoding Encoding => Encoding.UTF8;
        static HttpClient client = new HttpClient();
        
        protected abstract HttpRequestMessage CreateHttpRequestMessage();
        
        // https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
        // https://www.infoq.com/jp/news/2016/09/HttpClient
        public async Task<string> Request()
        {
            var jsonResult = "";
            try
            {
                var response = await client.SendAsync(CreateHttpRequestMessage());
                jsonResult = await response.Content.ReadAsStringAsync();
            }
            catch(HttpRequestException e)
            {
                throw new System.Exception(e.Message);
            }
            
            return jsonResult;
        }
    }
}
