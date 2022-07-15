using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCityApi.Db;
using SmartCityApi.Models;

namespace SmartCityApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BindController : Controller
    {
        private readonly ApplicationContext _context;

        public BindController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("SetUserCategory")]
        public async Task<IActionResult> SetUserCategory(int userId, int categoryId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }
            user.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok("Category added");
        }

        [HttpPost]
        [Route("DeleteUserCategory")]
        public async Task<IActionResult> DeleteUserCategory(int userId, int categoryId)
        {
            var user = await _context.Users.Include(p => p.Categories).SingleAsync(u => u.Id == userId);
            user.Categories?.Remove(await _context.Categories.SingleAsync(c => c.Id == categoryId));
            await  _context.SaveChangesAsync();
            return Ok();
        }

    }
}
