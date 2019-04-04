using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GUI_JavaJam.Data;
using Microsoft.AspNetCore.Mvc;
using GUI_JavaJam.Models;
using GUI_JavaJam.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GUI_JavaJam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "JavaJam Home";

            return View();
        }

        public IActionResult Menu()
        {
            ViewData["Title"] = "JavaJam Menu";
            var menuItems = _dbContext.MenuItemModels.Include(m=>m.PriceModels).ToList();
            var menuViewModel = new MenuViewModel() {MenuItems = menuItems};
            return View(menuViewModel);
        }

        public IActionResult Music()
        {
            ViewData["Message"] = "JavaJam Music";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
