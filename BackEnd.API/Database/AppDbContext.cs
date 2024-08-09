using BackEnd.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.API.Database;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // User Configuration...
        modelBuilder.Entity<User>().ToTable("Users");

        modelBuilder.Entity<User>().HasKey(user => user.Id);

        modelBuilder.Entity<User>().Property(user => user.Name).HasMaxLength(50).IsRequired();

        modelBuilder.Entity<User>().Property(user => user.Bio).HasMaxLength(50).IsRequired();

        modelBuilder.Entity<User>().Property(user => user.UserName).HasMaxLength(50).IsRequired();

        modelBuilder.Entity<User>().Property(user => user.Email).HasMaxLength(50).IsRequired();

        modelBuilder.Entity<User>().Property(user => user.Password).HasMaxLength(50).IsRequired();


        // Product Configuration...
        modelBuilder.Entity<Product>().ToTable("Products");

        modelBuilder.Entity<Product>().HasKey(user => user.Id);

        modelBuilder.Entity<Product>().Property(user => user.Name).HasMaxLength(50).IsRequired();

        modelBuilder.Entity<Product>().Property(user => user.Description).HasMaxLength(500).IsRequired();

        modelBuilder.Entity<Product>().Property(user => user.Price).HasColumnType("decimal(18,2)").IsRequired();

        modelBuilder.Entity<Product>().Property(user => user.Stock).IsRequired();
    }
}
