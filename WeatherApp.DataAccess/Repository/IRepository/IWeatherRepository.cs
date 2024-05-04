using WeatherApp.Models;
using WeatherApp.Models.DTO;

namespace WeatherApp.DataAccess.Repository.IRepository
{
    public interface IWeatherRepository : IRepository<Weather>
    {
        void Update(Weather weather);   
        Task<WeatherDetails> GetWeatherDataAsync(double latitude, double longitude);
    }
}
