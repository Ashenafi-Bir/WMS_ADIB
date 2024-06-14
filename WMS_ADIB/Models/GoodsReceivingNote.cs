using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WMS_ADIB.Models
{
    public class GoodsReceivingNote
    {
        [Key]
        public int GRNID { get; set; }

        [Required]
        public int PONumber { get; set; }

        [ForeignKey("PONumber")]
        public PurchaseOrder? PurchaseOrder { get; set; }

        [Required]
        public DateTime DateReceived { get; set; }

        [Required]
        public int DeliverUserID { get; set; }

        [ForeignKey("DeliverUserID")]
        public User? DeliverUser { get; set; }

        [Required]
        public int InspectUserID { get; set; }

        [ForeignKey("InspectUserID")]
        public User? InspectUser { get; set; }

        [Required]
        public int ReceiveUserID { get; set; }

        [ForeignKey("ReceiveUserID")]
        public User? ReceiveUser { get; set; }
    }
}
