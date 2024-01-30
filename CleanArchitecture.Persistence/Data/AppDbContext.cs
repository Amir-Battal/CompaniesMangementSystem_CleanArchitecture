using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitecture.Persistence.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produce>()
                .ToTable("produces")
                .HasKey(b => new { b.BranchId, b.ProductId });

        modelBuilder.Entity<Supply>()
                .ToTable("supplys")
                .HasKey(b => new { b.BranchId, b.ProductId });

        modelBuilder.Entity<Report>()
                .ToTable("reports")
                .HasKey(b => new { b.from, b.to });
    }

    public DbSet<Company> companies { get; set; }
    public DbSet<Branch> branches { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Produce> produces { get; set; }
    public DbSet<Supply> supplys { get; set; }
    public DbSet<Report> reports { get; set; }


}
