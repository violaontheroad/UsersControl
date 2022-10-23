using Test.Data;
using Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _db;

        public UserController(DataContext db)
        {
            _db = db;
        }
          public IActionResult Index()
        {
            
            IEnumerable<User> userList = _db.Users;
            return View(userList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
           if(ModelState.IsValid)
           {
                _db.Users.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
           }
           return View(obj);
            
        }

    }
}