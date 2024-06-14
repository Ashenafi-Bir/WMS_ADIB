namespace WMS_ADIB.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PurchaseRequisition
    {
        [Key]
        public int PRNumber { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("PurchaseRequstionRequestedByUser")]
        public int PurchaseRequstionRequestedByUserId { get; set; }

        [Required]
        [ForeignKey("PurchaseRequstionAuthorizedByUser")]
        public int PurchaseRequstionAuthorizedById { get; set; }

        public User? PurchaseRequstionRequestedByUser { get; set; }

        public User? PurchaseRequstionAuthorizedBy { get; set; }
    }
}
