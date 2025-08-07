using My.OfferApp.Bll.Abstraction.Models.Suppliers;
using My.OfferApp.Bll.Abstraction.Repositories;
using My.OfferApp.Bll.Abstraction.Services;

namespace My.OfferApp.Bll.Services;

internal sealed class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _repository;

    public SupplierService(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Supplier>> GetPopular()
    {
        return await _repository.GetPopular();
    }
}
