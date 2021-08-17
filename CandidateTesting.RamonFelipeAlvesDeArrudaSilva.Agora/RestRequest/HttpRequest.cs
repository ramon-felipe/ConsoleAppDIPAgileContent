using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.RestRequest
{
    public class HttpRequest : IHttpRequest
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient httpClient;

        public HttpRequest(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            httpClient = _httpClientFactory.CreateClient();
        }

        public async Task<string> Get(string uri)
        {
            var response = await httpClient.GetStringAsync(uri);

            return response;
        }
    }
}
