using System.Threading.Tasks;
using WeatherApi.Models;

namespace WeatherApi.Interfaces
{
    public interface IWeatherRepository
    {
        Task<WeatherResponse> GetCurrentWeatherByCityAsync(string city);
        Task<ForecastResponse> GetWeatherForecastByCityAsync(string city);
        Task<AirQualityResponse> GetAirQualityByCityAsync(string city);
        Task<WeatherResponse> GetCurrentWeatherByPincodeAsync(string pincode); // New method
    }


}
