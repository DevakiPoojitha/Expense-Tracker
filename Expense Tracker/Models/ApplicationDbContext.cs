using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Models;

namespace Expense_Tracker.Models
{
    public class ApplicationDbContext:DbContext
    {
        internal object login;

        public ApplicationDbContext(DbContextOptions options):base(options)
        {}

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public object SignUp { get; internal set; }
        public DbSet<Expense_Tracker.Models.login> login_1 { get; set; }
        public DbSet<Expense_Tracker.Models.SignUp> SignUp_1 { get; set; }
    }
}
