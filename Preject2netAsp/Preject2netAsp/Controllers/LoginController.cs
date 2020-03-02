using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Preject2netAsp.Models;

namespace Preject2netAsp.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsersContext _context;

        

        public LoginController(UsersContext context)
        {
            _context = context;
            
        }
       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login( Users user)
        {
            
            HttpContext.Session.SetString("EmailSession", user.Email);
         
         
            var isValidemail = EmailExists( user.Email);
            
            
            if (isValidemail == true)
            {

                var utilisateur = from us in _context.user
                             where us.Email == user.Email
                             select us;
                var userItem = utilisateur.FirstOrDefault();
                var role = userItem.Role;
                HttpContext.Session.SetString("role", role);
               
                return RedirectToAction("Index", "User");
                

            }
           
            return View();

        }
        private bool EmailExists(string email)
        {
            
            return _context.user.Any(e => e.Email == email);
        }
       
    }
}