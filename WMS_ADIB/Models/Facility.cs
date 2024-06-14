using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WMS_ADIB.Models
{
    public class Facility
    {
        [Key]
        public int FacilityID { get; set; }

        [Required]
        public int TransferID { get; set; }

        [ForeignKey("TransferID")]
        public AssetTransfer Transfer { get; set; }

        [Required]
        public DateTime DateHandled { get; set; }

        [Required]
        [StringLength(50)]
        public string? Status { get; set; }
    }
}
