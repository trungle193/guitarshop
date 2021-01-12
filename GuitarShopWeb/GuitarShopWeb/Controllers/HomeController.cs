using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GuitarShopWeb.Models;

namespace GuitarShopWeb.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(AppDbContext context) : base(context)
        {

        }

        public IActionResult Index()
        {
            ViewBag.Categories = base.Categories;
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Categories = base.Categories;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
