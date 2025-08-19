using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

internal class WebDevDBcontext : DbContext
{
    public WebDevDBcontext(DbContextOptions options) :
        base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<Product>()
            .ToTable("Product")
            .HasKey(o => o.Id);
    }

}
