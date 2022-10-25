using Microsoft.AspNetCore.Mvc;
using UsersControl.Services;

namespace UsersControl.Controllers;

public class AccountController : Controller
{
    // private readonly TokenService _tokenService;

    // public AccountController(TokenService tokenService)
    // {
    //     _tokenService = tokenService;
    // }

    [HttpPost("v1/login")]
    public IActionResult Login([FromServices]TokenService tokenService)
    {
        var token = tokenService.GenerateToken(null);

        return Ok(token);
    }
}