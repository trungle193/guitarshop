using System;
using System.Collections.Generic;
using System.Linq;
using GuitarShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShopWeb.Controllers
{
    public class BaseController : Controller
    {
        public List<Category> Categories { get; set; }
        private readonly AppDbContext _context;

        public BaseController(AppDbContext context)
        {
            _context = context;
            this.Categories = _context.Categories.ToList();
        }
    }
}
