using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarShopWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuitarShopWeb.Api
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? CategoryId = null)
        {
            if (CategoryId.HasValue)
            {
                return Ok(await _context.Products.Where(x => x.CategoryId == CategoryId.Value).AsNoTracking().ToListAsync());
            }
            else
            {
                return Ok(await _context.Products.AsNoTracking().ToListAsync());
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] Product product)
        {
            try
            {
                product.CreatedDate = DateTime.Now;
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return Ok("thanh cong");
            }
            catch (Exception ex)
            {
                return Ok("that bai");
            }
        }
    }
}
