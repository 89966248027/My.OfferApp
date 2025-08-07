using Microsoft.AspNetCore.Mvc;
using My.OfferApp.Bll.Abstraction.Models;
using My.OfferApp.Bll.Abstraction.Models.Offers;
using My.OfferApp.Bll.Abstraction.Models.Suppliers;
using My.OfferApp.Bll.Abstraction.Services;

namespace My.OfferApp.Web.Controllers;

[ApiController]
[Route("api/dict/supplier")]
public class SupplierController : ControllerBase
{
    private readonly ISupplierService _service;

    public SupplierController(ISupplierService service)
    {
        _service = service;
    }

    /// <summary>
    /// Метод со списком популярных поставщиков
    /// API (https://localhost:52420/api/dict/supplier/popular)
    ///
    /// Возвращает троих поставщиков с наибольшим количеством офферов,
    /// если кол-во офферов одинаковое сортирует по наименованию в алфавитном порядке
    /// </summary>
    [HttpGet("popular")]
    public async Task<IEnumerable<Supplier>> GetPopular()
    {
        return await _service.GetPopular();
    }
}
