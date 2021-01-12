using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuitarShopWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuitarShopWeb.Api
{


    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet("")]
        public async Task<ActionResult> Get([FromQuery] int? type = null)
        {
            if (type == 0)
            {
                return Ok(await _context.Categories.Where(x => x.CategoryType == type.Value).AsNoTracking().ToListAsync());
            }
            else if (type == 1)
            {
                return Ok(await _context.Categories.Where(x => x.CategoryType == 1 && x.Level == 0).IncludeHierarchy(3, nameof(Category.Childrens)).AsNoTracking().ToListAsync());
            }
            else
            {
                return Ok(await _context.Categories.Where(x => x.Level == 0).IncludeHierarchy(3, nameof(Category.Childrens)).AsNoTracking().ToListAsync());
            }
        }



        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById([FromRoute] int Id)
        {
            return Ok(await _context.Categories.FindAsync(Id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] Category category)
        {
            try
            {
                if (category.Id == 0)
                {
                    await _context.Categories.AddAsync(category);
                    await _context.SaveChangesAsync();
                    return Ok("thanh cong");
                }
                else
                {
                    var cate = await _context.Categories.FindAsync(category.Id);
                    cate.Name = category.Name;
                    cate.CategoryType = category.CategoryType;
                    cate.ParentId = category.ParentId;
                    await _context.SaveChangesAsync();
                    return Ok("thanh cong");
                }
            }
            catch (Exception ex)
            {
                return Ok("that bai");
            }
        }
    }

    public static class IncludeHierachyExtendions
    {
        public static IQueryable<T> IncludeHierarchy<T>(this IQueryable<T> source, uint depth, string propertyName) where T : Category
        {
            var temp = source;

            for (var i = 1; i <= depth; i++)
            {
                var sb = new StringBuilder();

                for (var j = 0; j < i; j++)
                {
                    if (j > 0)
                    {
                        sb.Append(".");
                    }

                    sb.Append(propertyName);
                }

                var path = sb.ToString();

                temp = temp.Include(path);
            }

            var result = temp;

            return result;
        }
    }
}
