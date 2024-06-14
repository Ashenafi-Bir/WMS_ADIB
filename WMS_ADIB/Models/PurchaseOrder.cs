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

        [Required]
        public int SupplierID { get; set; }

        [ForeignKey("SupplierID")]
        public Supplier? Supplier { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int OrderedByUserID { get; set; }

        [ForeignKey("OrderedByUserID")]
        public User? OrderedBy { get; set; }

        public int AuthorizedByUserID { get; set; }

        [ForeignKey("AuthorizedByUserID")]
        public User? AuthorizedBy { get; set; }

        // Navigation property for the related items
        public ICollection<Item>? Items { get; set; }
    }
}
