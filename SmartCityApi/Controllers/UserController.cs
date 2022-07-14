using Microsoft.AspNetCore.Mvc;
using SmartCityApi.Db;
using SmartCityApi.Models;

namespace SmartCityApi.Controllers;

[Route("api/[controller]")]
public class UserController : ControllerBase
{
	private readonly ApplicationContext _context;

	public UserController(ApplicationContext context)
	{
		_context = context;
	}
	[HttpPost]
	[Route("Login")]
	public IActionResult Login(string login,string password)
	{
		if (_context.Users.Any(u => u.Email == login && u.Password == password))
		{
			return Ok(_context.Users.Where(u => u.Email == login && u.Password == password));
		}
		else
		{
			return BadRequest("No user");
		}
	}

	[Route("Register")]
	public IActionResult Register([FromBody]User user)
	{
		if (_context.Users.Any(u => u.Email == user.Email))
		{
			return BadRequest("Email already exist");
		}
		else
		{
			return Ok(user);
		}
	}
}