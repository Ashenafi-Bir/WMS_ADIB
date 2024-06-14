using System.ComponentModel.DataAnnotations;

namespace WMS_ADIB.Models
{
    public class Branch
    {
        [Key]
        public int BranchID { get; set; }

        [Required]
        [StringLength(100)]
        public string? BranchName { get; set; }
        public ICollection<Requisition>? Requisitions { get; set; }
        public ICollection<AssetTransfer>? AssetTransfers { get; set; }
        public ICollection<AssetReturn>? AssetReturns { get; set; }
        public ICollection<AssetDisposal>? AssetDisposals { get; set; }
    }
}
