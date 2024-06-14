
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_ADIB.Models
{
    public class Requisition
    {
        [Key]
        public int RequisitionID { get; set; }

        [Required]
        public int BranchID { get; set; }

        [ForeignKey("BranchID")]
        public Branch? Branch { get; set; }

        [Required]
        public int ItemID { get; set; }

        [ForeignKey("ItemID")]
        public Item? Item { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateRequested { get; set; }

        public DateTime? DateApproved { get; set; }

        public DateTime? DateDispatched { get; set; }

        [Required]
        [StringLength(50)]
        public string? Status { get; set; }

        [Required]
        public int RequisitionApprovedByUserID { get; set; }

        [ForeignKey("RequisitionApprovedByUserID")]
        public User? RequisitionApprovedByUser { get; set; }

        [Required]
        public int RequisitionAuthorizedByUserID { get; set; }

        [ForeignKey("RequisitionAuthorizedByUserID")]
        public User? RequisitionAuthorizedByUser { get; set; }

        [Required]
        public int IssuedByUserID { get; set; }

        [ForeignKey("IssuedByUserID")]
        public User? IssuedByUser { get; set; }
    }
}
