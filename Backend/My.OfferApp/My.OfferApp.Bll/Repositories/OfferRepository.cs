using Microsoft.EntityFrameworkCore;
using My.OfferApp.Bll.Abstraction.Models;
using My.OfferApp.Bll.Abstraction.Models.Offers;
using My.OfferApp.Bll.Abstraction.Repositories;
using My.OfferApp.Dal.Contexts;
using My.OfferApp.Dal.Entities;

namespace My.OfferApp.Bll.Repositories;

internal sealed class OfferRepository : IOfferRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OfferRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(OfferAddEditModel model)
    {
        var entity = new OfferEntity()
        {
            Mark = model.Mark,
            Model = model.Model,
            SupplierId = model.SupplierId!.Value,
            RegistrationDate = model.RegistrationDate!.Value,
        };

        _dbContext.Offer.Add(entity);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<OfferData> GetAll(string? mark, string? model, int? supplierId)
    {
        var q = _dbContext.Offer.OrderBy(x => x.Id).Include(x => x.Supplier).AsNoTracking();

        if (!string.IsNullOrEmpty(mark))
        {
            q = q.Where(x => x.Mark.StartsWith(mark));
        }

        if (!string.IsNullOrEmpty(model))
        {
            q = q.Where(x => x.Model.StartsWith(model));
        }

        if (supplierId.HasValue)
        {
            q = q.Where(x => x.SupplierId == supplierId);
        }

        IEnumerable<Offer> data = await q.Select(x => new Offer()
            {
                Id = x.Id,
                Mark = x.Mark,
                Model = x.Model,
                SupplierName = x.Supplier.Name,
                RegistrationDate = x.RegistrationDate,
            })
            .ToArrayAsync();

        int total = await q.CountAsync();

        return new OfferData() { Data = data, Total = total };
    }
}
