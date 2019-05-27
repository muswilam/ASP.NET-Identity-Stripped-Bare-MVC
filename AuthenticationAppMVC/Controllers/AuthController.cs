using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticationAppMVC.Models;
using System.Security.Claims;

namespace AuthenticationAppMVC.Controllers
{
    [AllowAnonymous] // necessary so people can log in 
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult LogIn(string returUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returUrl
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //don't do this in production , just for tutorial 
            if(model.Email == "admin@admin.com" && model.Password == "password")
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, "Sully"),
                    new Claim(ClaimTypes.Email, "a@b.com"),
                    new Claim(ClaimTypes.Country, "England")
                }, "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }
            
            // user auth Failed !! 
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if(string.IsNullOrEmpty(returnUrl) || Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }
    }
}