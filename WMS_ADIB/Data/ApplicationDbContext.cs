
using Microsoft.EntityFrameworkCore;
using WMS_ADIB.Models;

namespace WMS_ADIB.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AdditionalInfo> AdditionalInfos { get; set; }
        public DbSet<AssetDisposal> AssetDisposals { get; set; }
        public DbSet<AssetReturn> AssetReturns { get; set; }
        public DbSet<AssetTransfer> AssetTransfers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<GoodsReceivingNote> GoodsReceivingNotes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseRequisition> PurchaseRequisitions { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Supplier one-to-many PurchaseOrder
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(po => po.Supplier)
                .WithMany(s => s.PurchaseOrders)
                .HasForeignKey(po => po.SupplierID);

            // PurchaseRequisition one-to-many PurchaseOrder
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(po => po.PurchaseRequisition)
                .WithMany(pr => pr.PurchaseOrders)
                .HasForeignKey(po => po.PRNumber);

            // PurchaseOrder one-to-many Item
            modelBuilder.Entity<Item>()
                .HasOne(i => i.PurchaseOrder)
                .WithMany(po => po.Items)
                .HasForeignKey(i => i.PONumber);

            // PurchaseOrder one-to-one GoodsReceivingNote
            //modelBuilder.Entity<GoodsReceivingNote>()
            //    .HasOne(grn => grn.PurchaseOrder)
            //    .WithOne(po => po.GoodsReceivingNote)
            //    .HasForeignKey<GoodsReceivingNote>(grn => grn.PONumber);

            // Item one-to-many Requisition
            modelBuilder.Entity<Requisition>()
                .HasOne(r => r.Item)
                .WithMany(i => i.Requisitions)
                .HasForeignKey(r => r.ItemID);

            // Item one-to-many AssetTransfer
            modelBuilder.Entity<AssetTransfer>()
                .HasOne(at => at.Item)
                .WithMany(i => i.AssetTransfers)
                .HasForeignKey(at => at.ItemID);

            // Item one-to-many AssetReturn
            modelBuilder.Entity<AssetReturn>()
                .HasOne(ar => ar.Item)
                .WithMany(i => i.AssetReturns)
                .HasForeignKey(ar => ar.ItemID);

            // Item one-to-many AssetDisposal
            modelBuilder.Entity<AssetDisposal>()
                .HasOne(ad => ad.Item)
                .WithMany(i => i.AssetDisposals)
                .HasForeignKey(ad => ad.ItemID);

            // Branch one-to-many Requisition
            modelBuilder.Entity<Requisition>()
                .HasOne(r => r.Branch)
                .WithMany(b => b.Requisitions)
                .HasForeignKey(r => r.BranchID);

            // Branch one-to-many AssetTransfer
            modelBuilder.Entity<AssetTransfer>()
                .HasOne(at => at.FromBranch)        // AssetTransfer has one FromBranch
                .WithMany(b => b.AssetTransfers)   // Branch has many AssetTransfers
                .HasForeignKey(at => at.FromBranchID)
                .OnDelete(DeleteBehavior.Restrict); // Optional: specify delete behavior

            // Branch one-to-many AssetReturn
            modelBuilder.Entity<AssetReturn>()
                .HasOne(ar => ar.Branch)
                .WithMany(b => b.AssetReturns)
                .HasForeignKey(ar => ar.BranchID);

            // Branch one-to-many AssetDisposal
            modelBuilder.Entity<AssetDisposal>()
                .HasOne(ad => ad.Branch)
                .WithMany(b => b.AssetDisposals)
                .HasForeignKey(ad => ad.BranchID);

            // GoodsReceivingNote one-to-many User
            modelBuilder.Entity<GoodsReceivingNote>()
                .HasOne(grn => grn.GRNDeliverUser)
                .WithMany(u => u.GRNDeliverUser)
                .HasForeignKey(grn => grn.GRNDeliverUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GoodsReceivingNote>()
                .HasOne(grn => grn.GRNInspectUser)
                .WithMany(u => u.GRNInspectUser)
                .HasForeignKey(grn => grn.GRNInspectUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GoodsReceivingNote>()
                .HasOne(grn => grn.GRNReceiveUser)
                .WithMany(u => u.GRNReceiveUser)
                .HasForeignKey(grn => grn.GRNReceiveUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // AssetTransfer one-to-many User
            modelBuilder.Entity<AssetTransfer>()
                .HasOne(at => at.AssetTransferAuthorizedByUser)
                .WithMany(u => u.AssetTransferAuthorizedByUser)
                .HasForeignKey(at => at.AssetTransferAuthorizedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // AssetReturn one-to-many User
            modelBuilder.Entity<AssetReturn>()
                .HasOne(ar => ar.AssetReturnReceivedBy)
                .WithMany(u => u.AssetReturnReceivedBy)
                .HasForeignKey(ar => ar.AssetReturnReceivedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AssetReturn>()
                .HasOne(ar => ar.AssetReturnApprovedBy)
                .WithMany(u => u.AssetReturnApprovedBy)
                .HasForeignKey(ar => ar.AssetReturnApprovedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // AssetDisposal one-to-many User
            modelBuilder.Entity<AssetDisposal>()
                .HasOne(ad => ad.DisposedBy)
                .WithMany(u => u.DisposedBy)
                .HasForeignKey(ad => ad.DisposedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AssetDisposal>()
                .HasOne(ad => ad.DisposalApprovedBy)
                .WithMany(u => u.DisposalApprovedBy)
                .HasForeignKey(ad => ad.DisposalApprovedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Requisition one-to-many User
            modelBuilder.Entity<Requisition>()
                .HasOne(r => r.RequisitionApprovedByUser)
                .WithMany(u => u.RequisitionApprovedByUser)
                .HasForeignKey(r => r.RequisitionApprovedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Requisition>()
                .HasOne(r => r.RequisitionAuthorizedByUser)
                .WithMany(u => u.RequisitionAuthorizedByUser)
                .HasForeignKey(r => r.RequisitionAuthorizedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Requisition>()
                .HasOne(r => r.IssuedByUser)
                .WithMany(u => u.IssuedByUser)
                .HasForeignKey(r => r.IssuedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // PurchaseOrder one-to-many User
            //modelBuilder.Entity<PurchaseOrder>()
            //    .HasOne(po => po.PurchaseOrderOrderedBy)
            //    .WithMany(u => u.PurchaseOrderOrderedBy)
            //    .HasForeignKey(po => po.PurchaseOrderOrderedByID)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(po => po.PurchaseOrderAuthorizedBy)
                .WithMany(u => u.PurchaseOrderAuthorizedBy)
                .HasForeignKey(po => po.PurchaseOrderAuthorizedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // PurchaseRequisition one-to-many User
            modelBuilder.Entity<PurchaseRequisition>()
                .HasOne(pr => pr.PurchaseRequstionRequestedByUser)
                .WithMany(u => u.PurchaseRequstionRequestedByUser)
                .HasForeignKey(pr => pr.PurchaseRequstionRequestedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseRequisition>()
                .HasOne(pr => pr.PurchaseRequstionAuthorizedBy)
                .WithMany(u => u.PurchaseRequstionAuthorizedBy)
                .HasForeignKey(pr => pr.PurchaseRequstionAuthorizedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
