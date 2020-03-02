using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Preject2netAsp.Models;

namespace Preject2netAsp.Controllers
{
    
    public class RegisterController : Controller
    {

       private readonly UsersContext _context;
      
        public RegisterController(UsersContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,FirstName,LastName,Email,Creation,Role")] Users user)
        {
            
            if (ModelState.IsValid)
            {
                user.Role = "User";
                DateTime date1 = DateTime.Now;
                user.Creation = date1;
                //user.Id = 1;
                //_context.Add(user);
                var isValidEmail=EmailExists(user.Email);
                if (isValidEmail != true)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                   
                   
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    
                    ModelState.AddModelError("Error", "already existing email in the database");
                    Console.WriteLine(isValidEmail);
                }
           
            }
           return View();
           //return RedirectToAction("Register");
        }

        private bool EmailExists(string email)
        {
            return _context.user.Any(e => e.Email == email);
        }

    }
}