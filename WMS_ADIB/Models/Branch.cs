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
    }
}
