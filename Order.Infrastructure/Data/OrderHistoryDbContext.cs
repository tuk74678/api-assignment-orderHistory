using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Data;

public class OrderHistoryDbContext: DbContext
{
    public OrderHistoryDbContext(DbContextOptions<OrderHistoryDbContext> options) : base(options)
    {
        
    }
    // Declare DbSet to create table in the DB
    public DbSet<Orders> Order { get; set; }
    public DbSet<OrderDetail> Order_Details { get; set; }
    
    // Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Orders>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<OrderDetail>()
            .HasKey(od => od.Id);

        modelBuilder.Entity<Orders>()
            .HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.Order_Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}