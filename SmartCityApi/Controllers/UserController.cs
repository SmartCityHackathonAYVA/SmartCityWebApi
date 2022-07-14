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
		return Ok();
	}

	[Route("Register")]
	public IActionResult Register([FromBody]User user)
	{
		return Ok();
	}
}