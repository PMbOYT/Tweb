using System.Collections.Generic;
using System.Data.Entity;

namespace BudgetBliss.web.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }
    }
}
