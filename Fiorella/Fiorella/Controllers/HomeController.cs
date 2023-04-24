using Fiorella.DAL;
using Fiorella.Models;
using Fiorella.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorella.Controllers
{
    public class HomeController : Controller
    {
      private readonly AppDbContext _Db;
        public HomeController(AppDbContext Db)
        {
                _Db = Db;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                products = await _Db.Products.ToListAsync(),
                category = await _Db.Categories.ToListAsync(),
                Bio = await _Db.Bio.ToListAsync(),
                Sliders = await _Db.Sliders.ToListAsync(),
            };
            return View(homeVM);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
