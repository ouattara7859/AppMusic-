using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Preject2netAsp.Models;

namespace Preject2netAsp.Controllers
{
    public class DisplayAllFriendsController : Controller
    {
        private readonly UsersContext _context;

        public DisplayAllFriendsController(UsersContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        
         public IActionResult DisplayAllFriends( )
        {
            string email  = HttpContext.Session.GetString("EmailSession");
            if (ModelState.IsValid)
            {
                var listTOFriends = AllFriends(email);
                return View(listTOFriends);

            }
            return View();
        }
        public async Task<IActionResult> Delete(string email)
        {
            if (ModelState.IsValid)
            {
                var user = FriendsFound(email);
                if (user != null)
                {                        
                    _context.Remove(user);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(DisplayAllFriends));                 
                }

            }
            return View();

        }
        public async Task<IActionResult> DetailsPlayList(string email)
        {
            var playList = DisplayAllPlayListFriend(email);
            if (playList != null)
            {
                return View(playList);
            }
            return View();

        }
        private Friends FriendsFound(string email)
        {
            var utilisateur = from us in _context.friend
                              where us.Email == email
                              select us;
            var userItem = utilisateur.FirstOrDefault();
            return userItem;
        }
        private List<Friends> AllFriends(string email)
        {
            var listTOFriends = _context.friend.Where(f => f.EmailFriends == email).ToList();
            
            return listTOFriends;
        }
        private List<PlayListModel> DisplayAllPlayListFriend(string email)
        {
            var listTOFriends = _context.playList.Where(f => f.Email == email).ToList();

            return listTOFriends;
        }
    }
}