using Microsoft.AspNetCore.Mvc;
using Test.Models;
using UsersControl.Models;
using UsersControl.Repository;

namespace UsersControl.Controllers;

public class LoginController : Controller
{
    private readonly IUserRepository _userRepository;

    public LoginController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Enter(LoginModel loginModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
               User user = _userRepository.SearchByEmail(loginModel.Email);

                if(user != null)
                {
                    if(user.ValidPassword(loginModel.Password))
                    {
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