using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class WebDevDBcontext : DbContext
{
    public WebDevDBcontext(DbContextOptions options) :
        base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Coupon> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<Product>()
            .ToTable("Product")
            .HasKey(o => o.Id);

        modelBuilder.Entity<Coupon>()
            .ToTable("Coupons")
            .HasKey(o => o.Id);
    }
}
