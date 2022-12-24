using Datta.AppDataAccessLayer.Entities.CookingBook;
using Microsoft.EntityFrameworkCore;

namespace Datta.AppDataAccessLayer
{
    public class AppDataContext: DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public AppDataContext(DbContextOptions<AppDataContext> options):base(options)
        {

        }
    }
}