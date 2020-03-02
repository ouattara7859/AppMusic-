using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace Preject2netAsp.Controllers
{
    public class LogoutController : Controller
    {
       
        public IActionResult Logout()
        {
            //return View();
            HttpContext.Session.Remove("EmailSession");
            return RedirectToAction("Login" ,"Login");
        }
      
       
    }
}