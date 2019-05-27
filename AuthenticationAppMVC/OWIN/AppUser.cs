using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthenticationAppMVC
{
    public class AppUser : IdentityUser
    {
        public string Country { get; set; }
    }
}