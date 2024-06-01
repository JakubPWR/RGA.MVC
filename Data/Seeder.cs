using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RGA.MVC.Data.Enum;
using RGA.MVC.Models;

namespace RGA.MVC.Data
{
    public class Seeder
    {
        private readonly ApplicationDbContext _dbContext;
        public Seeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Clubs.Any())
                {
                    var clubs = GetClubs();
                    _dbContext.Clubs.AddRange(clubs);
                    _dbContext.SaveChanges();
                }
                 if(!_dbContext.Races.Any())
                {
                    var races = GetRaces();
                    _dbContext.Races.AddRange(races);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Club> GetClubs()
        {
            var clubs = new List<Club>()
                    {
                        new Club()
                        {
                            Title = "Running Club 1",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first cinema",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                         },
                        new Club()
                        {
                            Title = "Running Club 2",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first cinema",
                            ClubCategory = ClubCategory.Endurance,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        },
                        new Club()
                        {
                            Title = "Running Club 3",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first club",
                            ClubCategory = ClubCategory.Trail,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        },
                    };
            return clubs; 
        }
        //Races
        private IEnumerable<Race> GetRaces()
        {
            var races = new List<Race>()
                {
                    new Race()
                    {
                        Title = "Running Race 1",
                        Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2022/09/woman-power-walking-outdoors.jpg?quality=82&strip=all",
                        Description = "This is the description of the first race",
                        RaceCategory = RaceCategory.Marathon,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    },
                    new Race()
                    {
                        Title = "Running Race 2",
                        Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2022/09/woman-power-walking-outdoors.jpg?quality=82&strip=all",
                        Description = "This is the description of the first race",
                        RaceCategory = RaceCategory.Ultra,
                        AddressId = 5,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    }
                };
            return races;
        }
    }
}
