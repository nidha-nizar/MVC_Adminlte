using Microsoft.EntityFrameworkCore;
using MVC_Adminlte.Models;

namespace MVC_Adminlte.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<hospital> hospital_tb { get; set; }
        public DbSet<doctor> doct_tb { get; set; }
        public DbSet<registers> reg_tb { get; set; }
    }
}
