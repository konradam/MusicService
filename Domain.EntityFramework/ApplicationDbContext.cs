using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Album> Albums { get; set; }
    }
}