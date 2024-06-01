using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RGA.MVC.Models;

namespace RGA.MVC.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAll();
        Task<Club> GetByIdAsync(int id);
        Task<IEnumerable<Club>> GetClubByCity(string city);
        bool Add(Club club);
        bool Update(Club club);
        bool Delete(Club club);
        bool Save();
    }
}