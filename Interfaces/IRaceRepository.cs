using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RGA.MVC.Models;

namespace RGA.MVC.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetByIdAsync(int id);
        Task<IEnumerable<Race>> GetRaceByCity(string city);
        bool Add(Race club);
        bool Update(Race club);
        bool Delete(Race club);
        bool Save();
    }
}