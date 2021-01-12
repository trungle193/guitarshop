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
    public class PageController : Controller
    {
        AppDbContext _context;
        public PageController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Pages.Include(x => x.Category).ToListAsync());
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] Page page)
        {
            try
            {
                page.CreatedDate = DateTime.Now;
                await _context.Pages.AddAsync(page);
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
