using Microsoft.AspNetCore.Mvc;
using WeatherApp.DataAccess.Repository.IRepository;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public WeatherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> GetWeatherDataByLocationAsync([FromBody] Coord coord)
        {
            try
            {
                var weatherData = await _unitOfWork.WeatherRepository.GetWeatherDataAsync(coord.Lat, coord.Lon);
                return Ok(new { success = true, message = "Data received.", data = weatherData });
            } catch (Exception ex)
            {
                return Ok(new { success = false, message = "Failed to fetch data", error = ex.Message });
            }
        }
    }
}
