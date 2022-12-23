using Data.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Identity
{
    public class IdentityContext: DbContext
    {
        public DbSet<AppUserEntity> AppUsers { get; set; }
        public IdentityContext(DbContextOptions<IdentityContext> options)
           : base(options)
        {
        }
    }
}