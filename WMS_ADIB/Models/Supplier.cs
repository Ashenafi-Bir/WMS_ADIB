namespace WMS_ADIB.Models;
using System.ComponentModel.DataAnnotations;

public class Supplier
{
    [Key]
    public int SupplierID { get; set; }

    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    [Required]
    [StringLength(100)]
    public string? InvoiceNumber { get; set; } // Make sure to add unique constraint in the context

    //navigation
    public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
}

