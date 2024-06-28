using Microsoft.EntityFrameworkCore;

namespace ReponsitoryMVC.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        //private const string ConnectionString = "Data Source=DESKTOP-IPDB6V8;database=shopping;User ID=sa;Password=123;TrustServerCertificate=true;Trusted_Connection=True;";
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
