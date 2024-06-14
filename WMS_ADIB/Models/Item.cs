namespace WMS_ADIB.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Item
{
    [Key]
    public int ItemID { get; set; }

    [Required]
    [StringLength(200)]
    public string? Description { get; set; }

    [Required]
    [StringLength(50)]
    public string? Unit { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public decimal UnitPrice { get; set; }

    [Required]
    //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal TotalPrice { get; private set; }

    [Required]
    public int PONumber { get; set; }

    [ForeignKey("PONumber")]
    public PurchaseOrder? PurchaseOrder { get; set; }
    public ICollection<Requisition>? Requisitions { get; set; }
    public ICollection<AssetTransfer>? AssetTransfers { get; set; }
    public ICollection<AssetReturn>? AssetReturns { get; set; }
    public ICollection<AssetDisposal>? AssetDisposals { get; set; }
}