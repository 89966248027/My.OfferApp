using My.OfferApp.Bll.Abstraction.Models;
using My.OfferApp.Bll.Abstraction.Models.Offers;

namespace My.OfferApp.Bll.Abstraction.Repositories;

public interface IOfferRepository
{
    Task Add(OfferAddEditModel model);

    Task<OfferData> GetAll(string? mark, string? model, int? supplierId);
}
