using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherApp.DataAccess.Data;
using WeatherApp.DataAccess.Repository.IRepository;
using WeatherApp.Models;
using WeatherApp.Models.DTO;
using WeatherApp.Utility;

namespace WeatherApp.DataAccess.Repository
{
    public class WeatherRepository : Repository<Weather>, IWeatherRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly HttpClient _httpClient;

        public WeatherRepository(ApplicationDbContext db, HttpClient httpClient) : base(db)
        {
            _db = db;
            _httpClient = httpClient;
        }
        public void Update(Weather weather)
        {
            _db.Update(weather);
        }

        public async Task<WeatherDetails> GetWeatherDataAsync(double latitude, double longitude)
        {
            string url = StaticDetails.GetWeatherUrl(latitude, longitude);
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<WeatherDetails>(jsonString);
            return jsonObject;
        }
    }
}
