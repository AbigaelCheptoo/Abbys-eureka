using Microsoft.EntityFrameworkCore;

namespace WbApi.Models
{
    public class APIDBContext :DbContext
    {
        public APIDBContext(DbContextOptions<APIDBContext>options) : base(options) 
        {
        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
 