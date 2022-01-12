using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.Entities;

namespace WebAPI.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string myDbConnectionString = Configuration.GetConnectionString("myDb");
            optionsBuilder.UseMySQL(myDbConnectionString);
        }
        public DbSet<User> Users { get; set; }
    }
}
