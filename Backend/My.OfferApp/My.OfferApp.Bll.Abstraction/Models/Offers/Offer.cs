namespace My.OfferApp.Bll.Abstraction.Models.Offers;

public sealed record Offer
{
    public int Id { get; init; }

    public string Mark { get; init; }

    public string Model { get; init; }

    public string SupplierName { get; init; }

    public DateTime RegistrationDate { get; init; }
}
