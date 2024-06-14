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
        public int GRNDeliverUserID { get; set; }

        [ForeignKey("GRNDeliverUserID")]
        public User? GRNDeliverUser { get; set; }

        [Required]
        public int GRNInspectUserID { get; set; }

        [ForeignKey("GRNInspectUserID")]
        public User? GRNInspectUser { get; set; }

        [Required]
        public int GRNReceiveUserID { get; set; }

        [ForeignKey("GRNReceiveUserID")]
        public User? GRNReceiveUser { get; set; }
    }
}
