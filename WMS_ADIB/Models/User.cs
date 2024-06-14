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

        // 1. Purchase Orders requested by this user
        public ICollection<PurchaseOrder>? PurchaseOrdersRequested { get; set; }

        // 2. Purchase Orders approved by this user
        public ICollection<PurchaseOrder>? PurchaseOrdersApproved { get; set; }

        // 3. Asset Transfers requested by this user
        public ICollection<AssetTransfer>? AssetTransfersRequested { get; set; }

        // 4. Asset Transfers authorized by this user
        public ICollection<AssetTransfer>? AssetTransfersAuthorized { get; set; }

        // 5. Asset Returns requested by this user
        public ICollection<AssetReturn>? AssetReturnsRequested { get; set; }

        // 6. Asset Returns authorized by this user
        public ICollection<AssetReturn>? AssetReturnsAuthorized { get; set; }

        // 7. Requisitions requested by this user
        public ICollection<Requisition>? RequisitionsRequested { get; set; }

        // 8. Requisitions approved by this user
        public ICollection<Requisition>? RequisitionsApproved { get; set; }

        // 9. Asset Disposals requested by this user
        public ICollection<AssetDisposal>? AssetDisposalsRequested { get; set; }

        // 10. Asset Disposals authorized by this user
        public ICollection<AssetDisposal>? AssetDisposalsAuthorized { get; set; }
    }
}
