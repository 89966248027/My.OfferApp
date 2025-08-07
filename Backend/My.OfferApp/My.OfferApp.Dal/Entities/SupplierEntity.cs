using System.ComponentModel.DataAnnotations.Schema;

namespace My.OfferApp.Dal.Entities;

[Table("Supplier", Schema = "dict")]
public sealed class SupplierEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public List<OfferEntity> Offers { get; set; }
}