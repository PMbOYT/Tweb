using System.Data.Entity;
using System.Collections.Generic;
namespace BudgetBliss.Web.Models

{
    public class UserContext : DbContext
    {
        public UserContext() : base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }
    }
}