using Microsoft.EntityFrameworkCore;
using Technical_Assesment.Data.Models;

namespace Technical_Assesment.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
