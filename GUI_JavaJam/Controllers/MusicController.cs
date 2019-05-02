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
    public class MusicController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public MusicController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "JavaJam Home";
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView();
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
