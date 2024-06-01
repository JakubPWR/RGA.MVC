using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RGA.MVC.Data;

namespace RGA.MVC.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public RaceController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;   
        }
        public IActionResult Index()
        {
            var races = _dbContext.Races.ToList();
            return View(races);
        }
         public IActionResult Detail(int id)
        {
            var race = _dbContext.Races.Include(c=>c.Address).FirstOrDefault(c=>c.Id == id);
            return View(race);
        }
    }
}