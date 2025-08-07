using My.OfferApp.Bll.Abstraction.Models.Suppliers;

namespace My.OfferApp.Bll.Abstraction.Repositories;

public interface ISupplierRepository
{
    Task<IEnumerable<Supplier>> GetPopular();
}
