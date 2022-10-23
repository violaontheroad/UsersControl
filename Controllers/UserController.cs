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

        public IActionResult Create()
        {
            return View();
        }
        

    }
}