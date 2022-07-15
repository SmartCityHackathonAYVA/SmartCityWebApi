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
                return NotFound("test");
            }

            var category = await _context.Categories.FindAsync(categoryId);

            if (category == null)
            {
                return NotFound("test2");
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
            if (user == null)
            {
                return NotFound();
            }
            user.Categories?.Remove(await _context.Categories.SingleAsync(c => c.Id == categoryId));
            await  _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("GetUserCategory")]
        public async Task<IActionResult> GetUserCategory(int userId)
        {
            var user = await _context.Users.Include(p => p.Categories).SingleAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.Categories);
        }








        [HttpPost]
        [Route("SetUserEvent")]
        public async Task<IActionResult> SetUserEvent(int userId, int eventId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var even = await _context.Events.FindAsync(eventId);

            if (even == null)
            {
                return NotFound();
            }
            user.Events.Add(even);
            await _context.SaveChangesAsync();
            return Ok("Event added");
        }

        [HttpPost]
        [Route("DeleteUserEvent")]
        public async Task<IActionResult> DeleteUserEvent(int userId, int eventId)
        {
            var user = await _context.Users.Include(p => p.Events).SingleAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }
            user.Events?.Remove(await _context.Events.SingleAsync(c => c.Id == eventId));
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
