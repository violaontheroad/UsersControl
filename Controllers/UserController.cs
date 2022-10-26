using Test.Data;
using Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SecureIdentity.Password;

namespace Test.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _db;

        public UserController(DataContext db)
        {
            _db = db;
        }
        //GET
          public IActionResult Index()
        {
            try
            {
                IEnumerable<User> userList = _db.Users;
                return View(userList);
            }
            catch (DbUpdateException)
            {
                return StatusCode(400, ""); //coloca msg erro
            }
            
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User obj)
        {

           if(ModelState.IsValid)
           {
                var HashPassword = PasswordHasher.Hash(obj.Password);

                obj.Password = HashPassword;
                await _db.Users.AddAsync(obj);
                await _db.SaveChangesAsync();
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
            
            userFromDb.Password = "";

            return View(userFromDb);
        }
        
        //EDIT => POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User obj)
        {
           if(ModelState.IsValid)
           {    
                var HashPassword = PasswordHasher.Hash(obj.Password);

                obj.Password = HashPassword;
                _db.Users.Update(obj);
                await _db.SaveChangesAsync();
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
        public async Task<IActionResult> DeletePOST(long? id)
        {
            var objFromDb = _db.Users.FirstOrDefault(x=>x.Id==id);

            if (objFromDb == null)
            {
                return NotFound();
            }
           
                _db.Users.Remove(objFromDb);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");            
        }

    }
}