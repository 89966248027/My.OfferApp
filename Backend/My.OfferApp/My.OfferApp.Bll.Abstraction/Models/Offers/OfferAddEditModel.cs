namespace My.OfferApp.Bll.Abstraction.Models.Offers;

public sealed record OfferAddEditModel
{
    public int? Id { get; init; }

    public string? Mark { get; init; }

    public string? Model { get; init; }

    public int? SupplierId { get; init; }

    public DateTime? RegistrationDate { get; init; }
}
