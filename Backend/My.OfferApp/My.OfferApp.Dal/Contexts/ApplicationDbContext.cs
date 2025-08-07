using Microsoft.EntityFrameworkCore;
using My.OfferApp.Dal.Entities;

namespace My.OfferApp.Dal.Contexts;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
    
    public DbSet<SupplierEntity> Supplier { get; set; }
    
    public DbSet<OfferEntity> Offer { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder
            .HasSequence<int>("SupplierId", "dict")
            .StartsAt(1)
            .IncrementsBy(1)
            .IsCyclic(false);

        builder
            .Entity<SupplierEntity>()
            .Property(x => x.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dict.SupplierId");
        
        builder
            .HasSequence<int>("OfferId", "common")
            .StartsAt(1)
            .IncrementsBy(1)
            .IsCyclic(false);

        builder
            .Entity<OfferEntity>()
            .Property(x => x.Id)
            .HasDefaultValueSql("NEXT VALUE FOR common.OfferId");
        
        builder
            .Entity<OfferEntity>()
            .HasOne(x => x.Supplier)
            .WithMany(x => x.Offers);
    }
}
