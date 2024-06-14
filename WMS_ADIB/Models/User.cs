using ADIB_WMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMS_ADIB.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Username { get; set; }

        [Required]
        [StringLength(50)]
        public string? Role { get; set; }

        // Navigation properties for relationships
        //1 relation with GRN table
        public ICollection<GoodsReceivingNote>? GRNDeliverUser { get; set; }
        public ICollection<GoodsReceivingNote>? GRNInspectUser { get; set; }
        public ICollection<GoodsReceivingNote>? GRNReceiveUser { get; set; }

        //2 relation with PurchaseRequisition table table
        public ICollection<PurchaseRequisition>? PurchaseRequstionRequestedByUser { get; set; }
        public ICollection<PurchaseRequisition>? PurchaseRequstionAuthorizedBy { get; set; }
       public ICollection<PurchaseRequisition>? PurchaseOrderOrderedBy { get; set; }

        //3 relation with PurchaseOrder table table
        public ICollection<PurchaseOrder>? PurchaseOrderAuthorizedBy { get; set; }

        //4 relation with AssetTransfer table table
        public ICollection<AssetTransfer>? AssetTransferAuthorizedByUser { get; set; }

        //5 relation with AssetReturn table table
        public ICollection<AssetReturn>? AssetReturnReceivedBy { get; set; }
        public ICollection<AssetReturn>? AssetReturnApprovedBy { get; set; }

        //6 relation with Requisition table table
        public ICollection<Requisition>? RequisitionApprovedByUser { get; set; }
        public ICollection<Requisition>? RequisitionAuthorizedByUser { get; set; }
        public ICollection<Requisition>? IssuedByUser { get; set; }

        //7 relation with AssetDisposal table table
        public ICollection<AssetDisposal>? DisposedBy { get; set; }
         public ICollection<AssetDisposal>? DisposalApprovedBy { get; set; }
    }
}
