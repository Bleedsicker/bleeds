using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class WebDevDBcontext : DbContext
{
    public WebDevDBcontext(DbContextOptions options) :
        base(options)
    {

    }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderProduct> OrderProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
    }
}
