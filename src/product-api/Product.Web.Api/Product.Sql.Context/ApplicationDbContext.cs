using Product.Sql.Context;
using Microsoft.EntityFrameworkCore;
using Product.Sql.Context.Configurations;

namespace Product.Sql.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}