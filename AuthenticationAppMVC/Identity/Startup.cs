using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

namespace AuthenticationAppMVC
{
    public class Startup
    {
        public static Func<UserManager<AppUser>> UserManagerFactory { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });

            // configure the user manager 
            UserManagerFactory = () =>
            {
                var userManager = new UserManager<AppUser>(
                    new UserStore<AppUser>(new AppDbContext()));

                // allow alphanumeric characters in username 

                userManager.UserValidator = new UserValidator<AppUser>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                // use out custom claims provider
                userManager.ClaimsIdentityFactory = new AppUserClaimsIdentityFactory();

                return userManager;
            };
        }
    }
}