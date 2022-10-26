using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;
using Test.Data;
using Test.Models;
using UsersControl.Models;
using UsersControl.Services;

namespace UsersControl.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel loginModel,
    [FromServices]TokenService tokenService,
    [FromServices]DataContext context)
    {
        try
        {
            if (ModelState.IsValid)
            {
               var user = context.Users.FirstOrDefault(x => x.Email == loginModel.Email);
               
                if(user != null)
                {
                    if(PasswordHasher.Verify(user.Password, loginModel.Password))
                    {
                        var token = tokenService.GenerateToken(user);
                        
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["ErrorMessage"] = $"Password Invalid. Try again!";
                }
                
                TempData["ErrorMessage"] = $"Email/Password Invalid. Try again!";
                
            }
            
            return View("Index");
            
        }
        catch (Exception error)
        {
            TempData["ErrorMessage"] = $"Login Error! Try again";
            return RedirectToAction("Index");
        }
    }
}