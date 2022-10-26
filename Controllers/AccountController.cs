using Microsoft.AspNetCore.Mvc;
using UsersControl.Services;

namespace UsersControl.Controllers;

public class AccountController : Controller
{
    [HttpPost("v1/login")]
    public IActionResult Login([FromServices]TokenService tokenService)
    {
        var token = tokenService.GenerateToken(null);

        return Ok(token);
    }
}