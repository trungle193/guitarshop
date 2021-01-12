using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuitarShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(int? Id=null)
        {
            ViewBag.Id = Id;
            return View();
        }

      
    }
}
