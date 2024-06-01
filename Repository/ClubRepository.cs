using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RGA.MVC.Data;
using RGA.MVC.Interfaces;
using RGA.MVC.Models;

namespace RGA.MVC.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ClubRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Club>> GetAll()
        {
            var clubs = _dbContext.Clubs.ToListAsync();
            return await clubs;
        }
        public async Task<Club> GetByIdAsync(int id)
        {
            var club = _dbContext.Clubs.FirstOrDefaultAsync(c=>c.Id == id);
            return await club;
        }
        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            var clubs = _dbContext.Clubs.Where(c => c.Address.City.Contains(city)).ToListAsync();
            return await clubs;
        }
        public bool Add(Club club)
        {
            _dbContext.Add(club);
            return Save();
        }
        public bool Update(Club club)
        {
            throw new NotImplementedException();
        }
        public bool Delete(Club club)
        {
            _dbContext.Remove(club);
            return Save();
        }
        public bool Save()
        {
            var change = _dbContext.SaveChanges();
            return change > 0 ? true :false;
        }
    }
}