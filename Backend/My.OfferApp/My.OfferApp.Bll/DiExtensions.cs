using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using My.OfferApp.Bll.Abstraction.Models;
using My.OfferApp.Bll.Abstraction.Models.Offers;
using My.OfferApp.Bll.Abstraction.Repositories;
using My.OfferApp.Bll.Abstraction.Services;
using My.OfferApp.Bll.Repositories;
using My.OfferApp.Bll.Services;
using My.OfferApp.Bll.Validators;

namespace My.OfferApp.Bll;

public static class DiExtensions
{
    public static IServiceCollection AddBll(this IServiceCollection services)
    {
        return services
            .AddScoped<IValidator<OfferAddEditModel>, OfferValidator>()
            .AddScoped<IOfferService, OfferService>()
            .AddScoped<IOfferRepository, OfferRepository>()
            .AddScoped<ISupplierService, SupplierService>()
            .AddScoped<ISupplierRepository, SupplierRepository>();
    }
}
