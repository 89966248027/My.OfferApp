using FluentValidation;
using My.OfferApp.Bll.Abstraction.Models;
using My.OfferApp.Bll.Abstraction.Models.Offers;

namespace My.OfferApp.Bll.Validators;

internal sealed class OfferValidator : AbstractValidator<OfferAddEditModel>
{
    public OfferValidator()
    {
        RuleFor(x => x.Mark).NotEmpty();

        RuleFor(x => x.Model).NotEmpty();

        RuleFor(x => x.SupplierId).NotEmpty();
    }
}
