using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Preject2netAsp.Models;

namespace Preject2netAsp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UsersContext _context;

        public AdminController(UsersContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {   
            return View();
        }
        public IActionResult Admin()
        {
            var listOfUser=DisplayAllPlayListFriend();
            if (listOfUser != null)
            {
                return View(listOfUser);
            }
            return View();
        }
        public new async Task<IActionResult> DeleteUser(string email)
        {
            var user = UserFound(email);
            if (user.Role == "User") {
                _context.playList.Where(p => p.Email == email).ToList().ForEach(p => _context.playList.Remove(p));
                _context.friend.Where(f => f.Email == email).ToList().ForEach(f => _context.friend.Remove(f));
                _context.user.Where(u => u.Email == email).ToList().ForEach(u => _context.user.Remove(u));
               
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Admin));
            }
            return RedirectToAction(nameof(Admin));

        }
        public new async Task<IActionResult> Promovoir(string email)
        {
            var user = UserFound(email);
            if (user!=null)
            {
                user.Role = "admin";
                _context.Update(user);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Admin));
            }
            return RedirectToAction(nameof(Admin));

        }
        private List<Users> DisplayAllPlayListFriend()
        {
            var listTOFriends = _context.user.ToList();

            return listTOFriends;
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