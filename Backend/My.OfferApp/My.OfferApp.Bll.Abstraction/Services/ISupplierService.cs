using My.OfferApp.Bll.Abstraction.Models.Suppliers;

namespace My.OfferApp.Bll.Abstraction.Services;

public interface ISupplierService
{
    Task<IEnumerable<Supplier>> GetPopular();
}
