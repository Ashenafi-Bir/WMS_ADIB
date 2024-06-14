using ADIB_WMS.Models;
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
        public int ApprovedByUserID { get; set; }

        [ForeignKey("ApprovedByUserID")]
        public User? ApprovedByUser { get; set; }

        [Required]
        public int AuthorizedByUserID { get; set; }

        [ForeignKey("AuthorizedByUserID")]
        public User? AuthorizedByUser { get; set; }

        [Required]
        public int IssuedByUserID { get; set; }

        [ForeignKey("IssuedByUserID")]
        public User? IssuedByUser { get; set; }
    }
}
