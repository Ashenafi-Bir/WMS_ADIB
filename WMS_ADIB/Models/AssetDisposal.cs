﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ADIB_WMS.Models; // Ensure you have the correct namespace for Item and Branch

namespace WMS_ADIB.Models
{
    public class AssetDisposal
    {
        [Key]
        public int DisposalID { get; set; }

        [Required]
        public int ItemID { get; set; }

        [ForeignKey("ItemID")]
        public Item? Item { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateDisposed { get; set; }

        [Required]
        [StringLength(500)]
        public string? Reason { get; set; }

        [Required]
        public int BranchID { get; set; }

        [ForeignKey("BranchID")]
        public Branch? Branch { get; set; }

        [Required]
        public int DisposedByUserID { get; set; }

        [ForeignKey("DisposedByUserID")]
        public User? DisposedBy { get; set; }

        public int? ApprovedByUserID { get; set; }

        [ForeignKey("ApprovedByUserID")]
        public User? ApprovedBy { get; set; }
    }
}