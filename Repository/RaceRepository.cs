using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RGA.MVC.Data;
using RGA.MVC.Models;

namespace RGA.MVC.Repository
{
    public class RaceRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public RaceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Race>> GetAll()
        {
            var clubs = _dbContext.Races.ToListAsync();
            return await clubs;
        }
        public async Task<Race> GetByIdAsync(int id)
        {
            var club = _dbContext.Races.FirstOrDefaultAsync(c=>c.Id == id);
            return await club;
        }
        public async Task<IEnumerable<Race>> GetRaceByCity(string city)
        {
            var races = _dbContext.Races.Where(c => c.Address.City.Contains(city)).ToListAsync();
            return await races;
        }
        public bool Add(Race race)
        {
            _dbContext.Add(race);
            return Save();
        }
        public bool Update(Race race)
        {
            throw new NotImplementedException();
        }
        public bool Delete(Race race)
        {
            _dbContext.Remove(race);
            return Save();
        }
        public bool Save()
        {
            var change = _dbContext.SaveChanges();
            return change > 0 ? true :false;
        }
    }
}