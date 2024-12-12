using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Web_Framewk_CA2.Components.Model;

namespace Web_Framewk_CA2.Components.Services
{
    public class NewsService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "a0c6949c4aa34e2ea90837755067d894";
        private const string BaseUrl = "https://newsapi.org/v2/everything";

        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            if (!_httpClient.DefaultRequestHeaders.UserAgent.Any())
            {
                _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("myApp/1.0");
            }
        }

        public async Task<Article[]> GetNewsAsync(string city)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}?q={city}&apiKey={ApiKey}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var newsData = JsonSerializer.Deserialize<NewsData>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return newsData?.Articles;
        }
        return null;

    }
    }
}
