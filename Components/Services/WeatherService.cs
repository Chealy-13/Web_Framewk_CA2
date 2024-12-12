using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Web_Framewk_CA2.Components.Model;

namespace Web_Framewk_CA2.Components.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "827fe11b8a93db301004d8c098f762eb";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}?q={city}&appid={ApiKey}&units=metric");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<WeatherData>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return null;
        }
    }
}
