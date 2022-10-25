using Microsoft.AspNetCore.Mvc;
using UsersControl.Models;

namespace UsersControl.Controllers;

public class LoginController : Controller
{
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
                if(loginModel.Login == "viola@gmail.com" && loginModel.Password == "123")
                {
                    return RedirectToAction("Index", "Home");
                }
                TempData["ErrorMessage"] = $"..."; //colocar msg erro
                
            }


            return View("Index");
            
        }
        catch (Exception error)
        {
            TempData["ErrorMessage"] = $"..."; //colocar msg erro
            return RedirectToAction("Index");
        }
    }
}