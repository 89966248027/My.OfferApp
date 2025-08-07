using System.ComponentModel.DataAnnotations.Schema;

namespace My.OfferApp.Dal.Entities;

[Table("Offer", Schema = "common")]
public sealed class OfferEntity
{
    public int Id { get; set; }
    
    public string Mark { get; set; }
    
    public string Model { get; set; }
    
    public int SupplierId { get; set; }
    
    public SupplierEntity Supplier { get; set; }
    
    public DateTime RegistrationDate { get; set; }
}