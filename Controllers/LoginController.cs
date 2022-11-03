using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;
using Test.Data;
using Test.Models;
using UsersControl.Helper;
using UsersControl.Models;
using UsersControl.Services;

namespace UsersControl.Controllers;

public class LoginController : Controller
{

    public IActionResult Index(
        [FromServices]IUserSession session)
    {
        //if user is logged, redirect to Home
        if(session.SearchUserSession()!= null) return RedirectToAction("Index", "Home");
        return View(); 
    }

    public IActionResult Logout(
        [FromServices]IUserSession session)
    {
        session.removeUserSession();
        return RedirectToAction("Index", "Login");
    }

    [HttpPost]
    public IActionResult Login(LoginModel loginModel,
    [FromServices]TokenService tokenService,
    [FromServices]DataContext context,
    [FromServices]IUserSession session)
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
                        session.addUserSession(user);
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["ErrorMessage"] = $"Password Invalid. Try again!";
                }
                
                TempData["ErrorMessage"] = $"Email/Password Invalid. Try again!";
                
            }
            
            return View("Index");
            
        }
        catch (Exception)
        {
            TempData["ErrorMessage"] = $"Login Error! Try again";
            
            return RedirectToAction("Index");
        }
        
    }
}