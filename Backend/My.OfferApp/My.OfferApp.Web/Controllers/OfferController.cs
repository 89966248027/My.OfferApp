using Microsoft.AspNetCore.Mvc;
using My.OfferApp.Bll.Abstraction.Models;
using My.OfferApp.Bll.Abstraction.Models.Offers;
using My.OfferApp.Bll.Abstraction.Services;

namespace My.OfferApp.Web.Controllers;

[ApiController]
[Route("api/common/offer")]
public class OfferController : ControllerBase
{
    private readonly IOfferService _service;

    public OfferController(IOfferService service)
    {
        _service = service;
    }

    /// <summary>
    /// Метод создания оффера.
    /// API (https://localhost:52420/api/common/offer)
    ///
    /// Перед сохранением данных валидируются поля на NULL
    ///
    /// Пример модели:
    ///{
    /// "Mark": "test",
    /// "Model": "test",
    /// "SupplierId": 1
    ///}
    /// </summary>
    [HttpPost]
    public async Task Add([FromBody] OfferAddEditModel model)
    {
        await _service.Add(model);
    }

    /// <summary>
    /// Метод с поиском
    /// API (https://localhost:52420/api/common/offer)
    ///
    /// Фильтры работают следующим образом:
    /// Model, Mark - забирает данные, у которых Model и Mark начинается с введеной строки соответственно
    /// SupplierId - забирает данные, у которых SupplierId = введеному значению
    ///
    /// В Data приходят отфильтрованные данные
    /// В Total - кол-во данных, подходящие под фильтры (Сделано для удобства в дальнейшем добавить пагинацию)
    /// </summary>
    [HttpGet]
    public async Task<OfferData> GetAll(
        [FromQuery] string? mark,
        [FromQuery] string? model,
        [FromQuery] int? supplierId
    )
    {
        return await _service.GetAll(mark, model, supplierId);
    }
}
