using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthenticationAppMVC
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() 
            : base("AuthDb")
        {

        }
    }
}