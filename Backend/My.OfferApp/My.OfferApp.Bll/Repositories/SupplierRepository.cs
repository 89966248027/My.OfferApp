using Microsoft.EntityFrameworkCore;
using My.OfferApp.Bll.Abstraction.Models.Suppliers;
using My.OfferApp.Bll.Abstraction.Repositories;
using My.OfferApp.Dal.Contexts;

namespace My.OfferApp.Bll.Repositories;

internal sealed class SupplierRepository : ISupplierRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SupplierRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Supplier>> GetPopular()
    {
        return await _dbContext
            .Supplier.Include(x => x.Offers)
            .OrderByDescending(x => x.Offers.Count)
            .ThenBy(x => x.Name)
            .AsNoTracking()
            .Take(3)
            .Select(x => new Supplier()
            {
                Id = x.Id,
                Name = x.Name,
                OffersCount = x.Offers.Count,
            })
            .ToArrayAsync();
    }
}
