using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Preject2netAsp.Models;

namespace Preject2netAsp.Controllers
{
    public class AddFriendsController : Controller
    {
        private readonly UsersContext _context;

        public AddFriendsController(UsersContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult AddFriends()
        {
            ViewData["isFirst"] = true;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFriends([Bind("Names")] Name name)
        {
            if (ModelState.IsValid)
            {
                var isValidEmail = EmailExists(name.Names);

                if (isValidEmail == true)
                {
                    Users U = UserFound(name.Names);
                    
                    await _context.SaveChangesAsync();
                    ViewData["isFirst"] = false;
                    return View(U);
                }
                else
                {

                    ModelState.AddModelError("Error", "User Not Found");

                }
            }
          
            return View();

        }

        public async Task<IActionResult> Add(string email)
        {
            if (ModelState.IsValid)
            {
                var user = UserFound(email);

                if (user != null)
                {
                   
                    
                    string emailFriends = HttpContext.Session.GetString("EmailSession");
                    Friends fr = new Friends()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        EmailFriends = emailFriends

                    };
                    _context.Add(fr);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(AddFriends));
                    
                   
                }
              
            }

            return RedirectToAction(nameof(AddFriends));

        }

        private bool EmailExists(string email)
        {
            return _context.user.Any(e => e.Email == email);
        }

        private bool FriendExists(string email)
        {
            return _context.friend.Any(e => e.EmailFriends == email);
        }


        private Users UserFound(string email)
        {
            var utilisateur = from us in _context.user
                              where us.Email == email
                              select us;
            var userItem = utilisateur.FirstOrDefault();
            return userItem;
        }


    }
}