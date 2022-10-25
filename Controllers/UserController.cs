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
                obj.PasswordHash();
                _db.Users.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
           }
           return View(obj);
            
        }

        //EDIT => GET
        public IActionResult Edit(long? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDb = _db.Users.FirstOrDefault(x=>x.Id==id);
            
            if (userFromDb ==null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }
        
        //EDIT => POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User obj)
        {
           if(ModelState.IsValid)
           {
                _db.Users.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
           }
           return View(obj);
            
        }
        //DELETE => GET
        public IActionResult Delete(long? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDb = _db.Users.FirstOrDefault(x=>x.Id==id);
            
            if (userFromDb ==null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }
        
        //DELETE => POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(long? id)
        {
            var objFromDb = _db.Users.FirstOrDefault(x=>x.Id==id);
            if (objFromDb == null)
            {
                return NotFound();
            }
           
                _db.Users.Remove(objFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");            
        }

    }
}