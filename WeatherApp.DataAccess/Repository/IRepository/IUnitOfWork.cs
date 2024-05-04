using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IWeatherRepository WeatherRepository { get; }
    }
}
