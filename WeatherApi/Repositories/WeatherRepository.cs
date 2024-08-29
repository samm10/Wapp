using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApi.Interfaces;
using WeatherApi.Models;

namespace WeatherApi.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "66cfa1adefeb37a57ab07594116d2b52"; 
        private readonly string _baseUrl = "https://api.openweathermap.org/data/2.5";

        public WeatherRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherResponse> GetCurrentWeatherByCityAsync(string city)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/weather?q={city}&appid={_apiKey}&units=metric");
            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<WeatherResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }


        public async Task<WeatherResponse> GetCurrentWeatherByPincodeAsync(string pincode)
        {
            // First fetch the coordinates using the postal code
            var coordResponse = await _httpClient.GetAsync($"{_baseUrl}/weather?zip={pincode}&appid={_apiKey}");

            if (!coordResponse.IsSuccessStatusCode)
            {
                return null;
            }

            var coordJson = await coordResponse.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherResponse>(coordJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Fetch the weather data using the coordinates
            var lat = weatherData.Coord.Lat;
            var lon = weatherData.Coord.Lon;

            var weatherResponse = await _httpClient.GetAsync($"{_baseUrl}/weather?lat={lat}&lon={lon}&appid={_apiKey}");

            if (weatherResponse.IsSuccessStatusCode)
            {
                var json = await weatherResponse.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<WeatherResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }
        

        public async Task<ForecastResponse> GetWeatherForecastByCityAsync(string city)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/forecast?q={city}&appid={_apiKey}&units=metric");
            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ForecastResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }

        public async Task<AirQualityResponse> GetAirQualityByCityAsync(string city)
        {
            // Fetching coordinates using the current weather API (you could use a dedicated Geocoding API as well)
            var weatherResponse = await _httpClient.GetAsync($"{_baseUrl}/weather?q={city}&appid={_apiKey}");
            
            if (!weatherResponse.IsSuccessStatusCode)
            {
                return null;
            }

            var weatherJson = await weatherResponse.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherResponse>(weatherJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Now use the coordinates to fetch air quality data
            var lat = weatherData.Coord.Lat;
            var lon = weatherData.Coord.Lon;

            var response = await _httpClient.GetAsync($"{_baseUrl}/air_pollution?lat={lat}&lon={lon}&appid={_apiKey}");
            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<AirQualityResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }

    }
}
