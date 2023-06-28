using InvoiceManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.DataAccess;

public class InvoiceManagerDbContext : DbContext
{
    public InvoiceManagerDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceProduct> InvoiceProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=localhost;Initial Catalog=InvoiceManager; User Id=InvoiceManager;Password=InvoiceManager123;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>()
            .HasMany(e => e.Products)
            .WithMany(e => e.Invoices)
            .UsingEntity<InvoiceProduct>();
    }
}