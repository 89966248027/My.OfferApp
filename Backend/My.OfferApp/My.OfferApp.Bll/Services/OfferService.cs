using FluentValidation;
using FluentValidation.Results;
using My.OfferApp.Bll.Abstraction.Models;
using My.OfferApp.Bll.Abstraction.Models.Offers;
using My.OfferApp.Bll.Abstraction.Repositories;
using My.OfferApp.Bll.Abstraction.Services;

namespace My.OfferApp.Bll.Services;

internal sealed class OfferService : IOfferService
{
    private readonly IValidator<OfferAddEditModel> _validator;

    private readonly IOfferRepository _repository;

    public OfferService(IValidator<OfferAddEditModel> validator, IOfferRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }

    public async Task Add(OfferAddEditModel model)
    {
        ValidationResult result = await _validator.ValidateAsync(model);

        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        await _repository.Add(model with { RegistrationDate = DateTime.Now });
    }

    public async Task<OfferData> GetAll(string? mark, string? model, int? supplierId)
    {
        return await _repository.GetAll(mark, model, supplierId);
    }
}
