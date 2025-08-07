namespace My.OfferApp.Bll.Abstraction.Models.Offers;

public sealed record OfferData
{
    public IEnumerable<Offer> Data { get; init; }

    public int Total { get; init; }
}
