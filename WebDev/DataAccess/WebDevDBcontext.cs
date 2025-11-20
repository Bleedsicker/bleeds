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

    public DbSet<Coupon> Coupons { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderProduct> OrderProducts { get; set; }


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

        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(b => b.Orders)
            .HasForeignKey(o => o.UserId);

        modelBuilder.Entity<Order>()
            .ToTable("Orders")
            .HasKey(o => o.OrderId);

        modelBuilder.Entity<OrderProduct>()
            .ToTable("OrderProduct")
            .HasKey(o => new { o.OrderId, o.ProductId });

        modelBuilder.Entity<OrderProduct>()
            .HasOne(b => b.Order)
            .WithMany(b => b.OrderProducts)
            .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<OrderProduct>()
            .HasOne(o => o.Product)
            .WithMany(b => b.OrderProducts)
            .HasForeignKey(op => op.ProductId);
    }
}
