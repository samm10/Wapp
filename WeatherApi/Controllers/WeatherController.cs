using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeatherApi.Interfaces;
using WeatherApi.Models;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherController(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        [HttpGet("currentWeather")]
        public async Task<IActionResult> GetCurrentWeather(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest("City parameter is required.");
            }

            try
            {
                var weather = await _weatherRepository.GetCurrentWeatherByCityAsync(city);

                if (weather == null)
                {
                    return NotFound("Weather data not found.");
                }

                return Ok(weather);
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("currentWeatherByZip")]
        public async Task<IActionResult> GetCurrentWeatherByPincode(string pincode = null)
        {
            if (string.IsNullOrEmpty(pincode))
            {
                return BadRequest("Pincode parameter is required.");
            }

            try
            {
                var weatherResponse = await _weatherRepository.GetCurrentWeatherByPincodeAsync(pincode);

                if (weatherResponse == null)
                {
                    return NotFound("Weather data not found.");
                }

                return Ok(weatherResponse);
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("forecast")]
        public async Task<IActionResult> GetWeatherForecast(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest("City parameter is required.");
            }

            try
            {
                var forecast = await _weatherRepository.GetWeatherForecastByCityAsync(city);

                if (forecast == null)
                {
                    return NotFound("Forecast data not found.");
                }

                return Ok(forecast);
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("airquality")]
        public async Task<IActionResult> GetAirQuality(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest("City parameter is required.");
            }

            try
            {
                var airQuality = await _weatherRepository.GetAirQualityByCityAsync(city);

                if (airQuality == null)
                {
                    return NotFound("Air quality data not found.");
                }

                return Ok(airQuality);
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
