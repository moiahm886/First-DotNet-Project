using First_DotNet_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace First_DotNet_Project.Data
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
