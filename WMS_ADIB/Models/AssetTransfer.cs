using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WMS_ADIB.Models;

namespace ADIB_WMS.Models
{
    public class AssetTransfer
    {
        [Key]
        public int TransferID { get; set; }

        [Required]
        public int FromBranchID { get; set; }

        [ForeignKey("FromBranchID")]
        public Branch? FromBranch { get; set; }

        [Required]
        public int ToBranchID { get; set; }

        [ForeignKey("ToBranchID")]
        public Branch? ToBranch { get; set; }

        [Required]
        public int ItemID { get; set; }

        [ForeignKey("ItemID")]
        public Item? Item { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateTransferred { get; set; }

        [Required]
        [StringLength(50)]
        public string? Status { get; set; }

        [Required]
        public int AssetTransferAuthorizedByUserID { get; set; }

        [ForeignKey("AssetTransferAuthorizedByUserID")]
        public User? AssetTransferAuthorizedByUser { get; set; }
    }
}
