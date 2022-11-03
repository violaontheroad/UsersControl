using Test.Data;
using Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SecureIdentity.Password;
using Microsoft.AspNetCore.Authorization;
using UsersControl.Services;
using UsersControl.Models;

namespace Test.Controllers
{
    public class UserController : Controller
    {
        //GET
        public IActionResult Index(
            [FromServices]DataContext db)
            {
                try
                {
                    IEnumerable<User> userList = db.Users;
                    return View(userList);
                }
                catch (System.Exception)
                {
                
                throw new Exception("Error001");
                }
            }
        
        public IActionResult Create()
        {
            return View();
        }
        
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj,
        [FromServices]DataContext db)
        {

           try
           {
                if(ModelState.IsValid)
                {
                    var HashPassword = PasswordHasher.Hash(obj.Password);

                    obj.Password = HashPassword;
                    db.Users.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(obj);
           
           }
           catch (System.Exception)
           {
            
            throw new Exception("Error002");
           }
           
            
        }

        //EDIT => GET
        public IActionResult Edit(long? id,
        [FromServices]DataContext db)
        {
           try
           {
                if(id == null || id == 0)
                    return NotFound();
                
                var userFromDb = db.Users.FirstOrDefault(x=>x.Id==id);
                
                if (userFromDb ==null)
                    return NotFound();
                
                userFromDb.Password = "";

                return View(userFromDb);
           }
           catch (System.Exception)
           {
            
            throw new Exception("Error003");
           }
        }
        
        //EDIT => POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User obj,
        [FromServices]DataContext db)
        {
           try
           {
                if(ModelState.IsValid)
                {    
                    var HashPassword = PasswordHasher.Hash(obj.Password);

                    obj.Password = HashPassword;
                    db.Users.Update(obj);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(obj);
           }
           catch (System.Exception)
           {
            
            throw new Exception("Error004");
           }
            
        }
        //DELETE => GET
        public IActionResult Delete(long? id,
        [FromServices]DataContext db)
        {
           try
           {
             if(id == null || id == 0)
                return NotFound();
            
            var userFromDb = db.Users.FirstOrDefault(x => x.Id == id);
            
            if (userFromDb ==null)
                return NotFound();

            return View(userFromDb);
           }
           catch (System.Exception)
           {
            
            throw new Exception("Error005");
           }
        }
        
        //DELETE => POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(long? id,
        [FromServices]DataContext db)
        {
            try
            {
                var objFromDb = db.Users.FirstOrDefault(x => x.Id == id);

                if (objFromDb == null)
                    return NotFound();
            
                db.Users.Remove(objFromDb);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");        
            }
            catch (System.Exception)
            {
                
                throw new Exception("Error006");
            }    
        }

    }
}