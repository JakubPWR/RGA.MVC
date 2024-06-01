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
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ClubController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;   
        }
        public IActionResult Index()
        {
            var clubs = _dbContext.Clubs.ToList();
            return View(clubs);
        }
        public IActionResult Detail(int id)
        {
            var club = _dbContext.Clubs.Include(c=>c.Address).FirstOrDefault(c=>c.Id == id);
            return View(club);
        }
    }
}