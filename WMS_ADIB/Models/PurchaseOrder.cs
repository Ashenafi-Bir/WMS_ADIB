using ADIB_WMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_ADIB.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int POId { get; set; }

        [Required]
        public int PONumber { get; set; }

        [Required]
        public int PRNumber { get; set; }

        [ForeignKey("PRNumber")]
        public PurchaseRequisition? PurchaseRequisition { get; set; }

        [Required]
        public int SupplierID { get; set; }

        [ForeignKey("SupplierID")]
        public Supplier? Supplier { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int PurchaseOrderOrderedByID { get; set; }

        [ForeignKey("PurchaseOrderOrderedByUserID")]
        public User? PurchaseOrderOrderedBy { get; set; }

        public int PurchaseOrderAuthorizedByID { get; set; }

        [ForeignKey("PurchaseOrderAuthorizedByUserID")]
        public User? PurchaseOrderAuthorizedBy { get; set; }

        // Navigation property for the related items
        public ICollection<Item>? Items { get; set; }
     
    }
}

