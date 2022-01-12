using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace WebAPI.Helpers
{
    public class SqlDataContext : DataContext
    {
        public SqlDataContext(IConfiguration configuration) : base(configuration) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connect to sqlite database
            string myDbConnectionString = Configuration.GetConnectionString("myDb");
            optionsBuilder.UseMySQL(myDbConnectionString);
        }
    }
}
