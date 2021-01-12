using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarShopWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuitarShopWeb.Controllers
{
    public class PageController : BaseController
    {
        private readonly AppDbContext _context;
        public PageController(AppDbContext context) : base(context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index(int CategoryId)
        {
            ViewBag.Categories = base.Categories;
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == CategoryId);
            var page = await _context.Pages.SingleOrDefaultAsync(x => x.CategoryId == CategoryId);

            ViewData["Title"] = category.Name;
            ViewBag.CategoryName = category.Name;
            return View(page);
        }
    }
}
