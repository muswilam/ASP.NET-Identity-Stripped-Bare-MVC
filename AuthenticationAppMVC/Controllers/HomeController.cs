using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;


namespace AuthenticationAppMVC.Controllers
{
    public class HomeController : AppController
    {
        // GET: Home
        public ActionResult Index()
        {
            //var claimIdentity = User.Identity as ClaimsIdentity;
            //ViewBag.Country = claimIdentity.FindFirst(ClaimTypes.Country).Value;
            
            //ViewBag.country = CurrentUser.Country;
            return View();
        }
    }
}