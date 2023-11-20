using examMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace examMVC.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
    }
}
