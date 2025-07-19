using System.Reflection;
using LiquorStore.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {        
    }
    public DbSet<Role> Roles { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Category> Categorys { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductSuggestion> ProductSuggestions { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleDetail> SaleDetails { get; set; }
    public DbSet<SaleStatus> SaleStatus { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<SuggestionReason> SuggestionReasons { get; set; }
    public DbSet<User> Users { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>()
       .Property(p => p.UnitPrice)
       .HasPrecision(18, 2);

        modelBuilder.Entity<Sale>()
            .Property(s => s.Total)
            .HasPrecision(18, 2);

        modelBuilder.Entity<SaleDetail>()
            .Property(sd => sd.Subtotal)
            .HasPrecision(18, 2);

        modelBuilder.Entity<SaleDetail>()
            .Property(sd => sd.UnitPrice)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Offer>()
            .Property(o => o.OfferPrice)
            .HasPrecision(18, 2);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
