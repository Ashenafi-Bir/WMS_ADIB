using ADIB_WMS.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_ADIB.Models
{
    public class AssetReturn
    {
        [Key]
        public int ReturnID { get; set; }

        [Required]
        public int BranchID { get; set; }

        [ForeignKey("BranchID")]
        public Branch? Branch { get; set; }

        [Required]
        public int ItemID { get; set; }

        [ForeignKey("ItemID")]
        public Item? Item { get; set; }

        [Required]
        public DateTime DateReturned { get; set; }

        [Required]
        [StringLength(50)]
        public string? Status { get; set; }

        [Required]
        public int ReceivedByID { get; set; }

        [ForeignKey("ReceivedByID")]
        public User? ReceivedBy { get; set; }

        [Required]
        public int ApprovedByID { get; set; }

        [ForeignKey("ApprovedByID")]
        public User? ApprovedBy { get; set; }
    }
}