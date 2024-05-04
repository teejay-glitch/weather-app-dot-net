using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.DataAccess.Data;
using WeatherApp.DataAccess.Repository.IRepository;

namespace WeatherApp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly HttpClient _httpClient;
        public IWeatherRepository WeatherRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db, HttpClient httpClient)
        {
            _db = db;
            _httpClient = httpClient;
            WeatherRepository = new WeatherRepository(_db, _httpClient);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
