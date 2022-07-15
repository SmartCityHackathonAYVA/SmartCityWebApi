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
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(u => u.Id == categoryId);

            if (category == null)
            {
                return NotFound();
            }

            user.Categories.Remove(category);
            category.Users.Remove(user);

            //var newCategories = new List<Category>(user.Categories);
            //newCategories.Remove(category);
            //user.Categories = newCategories;


            //_context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
