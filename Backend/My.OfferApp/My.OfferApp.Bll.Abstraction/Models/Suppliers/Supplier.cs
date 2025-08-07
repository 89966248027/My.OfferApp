namespace My.OfferApp.Bll.Abstraction.Models.Suppliers;

public sealed record Supplier
{
    public int Id { get; init; }

    public string Name { get; init; }

    public int OffersCount { get; init; }
}
