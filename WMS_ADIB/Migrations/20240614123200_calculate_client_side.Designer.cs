﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WMS_ADIB.Data;

#nullable disable

namespace WMS_ADIB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240614123200_calculate_client_side")]
    partial class calculate_client_side
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WMS_ADIB.Models.AdditionalInfo", b =>
                {
                    b.Property<int>("InfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InfoID"));

                    b.Property<int>("GrandTotal")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("InfoID");

                    b.ToTable("AdditionalInfos");
                });

            modelBuilder.Entity("WMS_ADIB.Models.AssetDisposal", b =>
                {
                    b.Property<int>("DisposalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisposalID"));

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDisposed")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DisposalApprovedByUserID")
                        .HasColumnType("int");

                    b.Property<int>("DisposedByUserID")
                        .HasColumnType("int");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("DisposalID");

                    b.HasIndex("BranchID");

                    b.HasIndex("DisposalApprovedByUserID");

                    b.HasIndex("DisposedByUserID");

                    b.HasIndex("ItemID");

                    b.ToTable("AssetDisposals");
                });

            modelBuilder.Entity("WMS_ADIB.Models.AssetReturn", b =>
                {
                    b.Property<int>("ReturnID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReturnID"));

                    b.Property<int>("AssetReturnApprovedByID")
                        .HasColumnType("int");

                    b.Property<int>("AssetReturnReceivedByID")
                        .HasColumnType("int");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateReturned")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ReturnID");

                    b.HasIndex("AssetReturnApprovedByID");

                    b.HasIndex("AssetReturnReceivedByID");

                    b.HasIndex("BranchID");

                    b.HasIndex("ItemID");

                    b.ToTable("AssetReturns");
                });

            modelBuilder.Entity("WMS_ADIB.Models.AssetTransfer", b =>
                {
                    b.Property<int>("TransferID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransferID"));

                    b.Property<int>("AssetTransferAuthorizedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTransferred")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromBranchID")
                        .HasColumnType("int");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ToBranchID")
                        .HasColumnType("int");

                    b.HasKey("TransferID");

                    b.HasIndex("AssetTransferAuthorizedByUserID");

                    b.HasIndex("FromBranchID");

                    b.HasIndex("ItemID");

                    b.HasIndex("ToBranchID");

                    b.ToTable("AssetTransfers");
                });

            modelBuilder.Entity("WMS_ADIB.Models.Branch", b =>
                {
                    b.Property<int>("BranchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BranchID"));

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("BranchID");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("WMS_ADIB.Models.GoodsReceivingNote", b =>
                {
                    b.Property<int>("GRNID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GRNID"));

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<int>("GRNDeliverUserID")
                        .HasColumnType("int");

                    b.Property<int>("GRNInspectUserID")
                        .HasColumnType("int");

                    b.Property<int>("GRNReceiveUserID")
                        .HasColumnType("int");

                    b.Property<int>("PONumber")
                        .HasColumnType("int");

                    b.HasKey("GRNID");

                    b.HasIndex("GRNDeliverUserID");

                    b.HasIndex("GRNInspectUserID");

                    b.HasIndex("GRNReceiveUserID");

                    b.HasIndex("PONumber");

                    b.ToTable("GoodsReceivingNotes");
                });

            modelBuilder.Entity("WMS_ADIB.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("PONumber")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ItemID");

                    b.HasIndex("PONumber");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WMS_ADIB.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("POId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("POId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PONumber")
                        .HasColumnType("int");

                    b.Property<int>("PRNumber")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseOrderAuthorizedByID")
                        .HasColumnType("int");

                    b.Property<int?>("PurchaseOrderAuthorizedByUserID")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseOrderOrderedByID")
                        .HasColumnType("int");

                    b.Property<int?>("PurchaseOrderOrderedByUserID")
                        .HasColumnType("int");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.HasKey("POId");

                    b.HasIndex("PRNumber");

                    b.HasIndex("PurchaseOrderAuthorizedByID");

                    b.HasIndex("PurchaseOrderOrderedByUserID");

                    b.HasIndex("SupplierID");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("WMS_ADIB.Models.PurchaseRequisition", b =>
                {
                    b.Property<int>("PRNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PRNumber"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PurchaseRequstionAuthorizedById")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseRequstionRequestedByUserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PRNumber");

                    b.HasIndex("PurchaseRequstionAuthorizedById");

                    b.HasIndex("PurchaseRequstionRequestedByUserId");

                    b.HasIndex("UserID");

                    b.ToTable("PurchaseRequisitions");
                });

            modelBuilder.Entity("WMS_ADIB.Models.Requisition", b =>
                {
                    b.Property<int>("RequisitionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequisitionID"));

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateApproved")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDispatched")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("datetime2");

                    b.Property<int>("IssuedByUserID")
                        .HasColumnType("int");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RequisitionApprovedByUserID")
                        .HasColumnType("int");

                    b.Property<int>("RequisitionAuthorizedByUserID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RequisitionID");

                    b.HasIndex("BranchID");

                    b.HasIndex("IssuedByUserID");

                    b.HasIndex("ItemID");

                    b.HasIndex("RequisitionApprovedByUserID");

                    b.HasIndex("RequisitionAuthorizedByUserID");

                    b.ToTable("Requisitions");
                });

            modelBuilder.Entity("WMS_ADIB.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"));

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SupplierID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("WMS_ADIB.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WMS_ADIB.Models.AssetDisposal", b =>
                {
                    b.HasOne("WMS_ADIB.Models.Branch", "Branch")
                        .WithMany("AssetDisposals")
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.User", "DisposalApprovedBy")
                        .WithMany("DisposalApprovedBy")
                        .HasForeignKey("DisposalApprovedByUserID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WMS_ADIB.Models.User", "DisposedBy")
                        .WithMany("DisposedBy")
                        .HasForeignKey("DisposedByUserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.Item", "Item")
                        .WithMany("AssetDisposals")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("DisposalApprovedBy");

                    b.Navigation("DisposedBy");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WMS_ADIB.Models.AssetReturn", b =>
                {
                    b.HasOne("WMS_ADIB.Models.User", "AssetReturnApprovedBy")
                        .WithMany("AssetReturnApprovedBy")
                        .HasForeignKey("AssetReturnApprovedByID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.User", "AssetReturnReceivedBy")
                        .WithMany("AssetReturnReceivedBy")
                        .HasForeignKey("AssetReturnReceivedByID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.Branch", "Branch")
                        .WithMany("AssetReturns")
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.Item", "Item")
                        .WithMany("AssetReturns")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetReturnApprovedBy");

                    b.Navigation("AssetReturnReceivedBy");

                    b.Navigation("Branch");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WMS_ADIB.Models.AssetTransfer", b =>
                {
                    b.HasOne("WMS_ADIB.Models.User", "AssetTransferAuthorizedByUser")
                        .WithMany("AssetTransferAuthorizedByUser")
                        .HasForeignKey("AssetTransferAuthorizedByUserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.Branch", "FromBranch")
                        .WithMany("AssetTransfers")
                        .HasForeignKey("FromBranchID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.Item", "Item")
                        .WithMany("AssetTransfers")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.Branch", "ToBranch")
                        .WithMany()
                        .HasForeignKey("ToBranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetTransferAuthorizedByUser");

                    b.Navigation("FromBranch");

                    b.Navigation("Item");

                    b.Navigation("ToBranch");
                });

            modelBuilder.Entity("WMS_ADIB.Models.GoodsReceivingNote", b =>
                {
                    b.HasOne("WMS_ADIB.Models.User", "GRNDeliverUser")
                        .WithMany("GRNDeliverUser")
                        .HasForeignKey("GRNDeliverUserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.User", "GRNInspectUser")
                        .WithMany("GRNInspectUser")
                        .HasForeignKey("GRNInspectUserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.User", "GRNReceiveUser")
                        .WithMany("GRNReceiveUser")
                        .HasForeignKey("GRNReceiveUserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany()
                        .HasForeignKey("PONumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GRNDeliverUser");

                    b.Navigation("GRNInspectUser");

                    b.Navigation("GRNReceiveUser");

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("WMS_ADIB.Models.Item", b =>
                {
                    b.HasOne("WMS_ADIB.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany("Items")
                        .HasForeignKey("PONumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("WMS_ADIB.Models.PurchaseOrder", b =>
                {
                    b.HasOne("WMS_ADIB.Models.PurchaseRequisition", "PurchaseRequisition")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("PRNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.User", "PurchaseOrderAuthorizedBy")
                        .WithMany("PurchaseOrderAuthorizedBy")
                        .HasForeignKey("PurchaseOrderAuthorizedByID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.User", "PurchaseOrderOrderedBy")
                        .WithMany()
                        .HasForeignKey("PurchaseOrderOrderedByUserID");

                    b.HasOne("WMS_ADIB.Models.Supplier", "Supplier")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchaseOrderAuthorizedBy");

                    b.Navigation("PurchaseOrderOrderedBy");

                    b.Navigation("PurchaseRequisition");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("WMS_ADIB.Models.PurchaseRequisition", b =>
                {
                    b.HasOne("WMS_ADIB.Models.User", "PurchaseRequstionAuthorizedBy")
                        .WithMany("PurchaseRequstionAuthorizedBy")
                        .HasForeignKey("PurchaseRequstionAuthorizedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.User", "PurchaseRequstionRequestedByUser")
                        .WithMany("PurchaseRequstionRequestedByUser")
                        .HasForeignKey("PurchaseRequstionRequestedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.User", null)
                        .WithMany("PurchaseOrderOrderedBy")
                        .HasForeignKey("UserID");

                    b.Navigation("PurchaseRequstionAuthorizedBy");

                    b.Navigation("PurchaseRequstionRequestedByUser");
                });

            modelBuilder.Entity("WMS_ADIB.Models.Requisition", b =>
                {
                    b.HasOne("WMS_ADIB.Models.Branch", "Branch")
                        .WithMany("Requisitions")
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.User", "IssuedByUser")
                        .WithMany("IssuedByUser")
                        .HasForeignKey("IssuedByUserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.Item", "Item")
                        .WithMany("Requisitions")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.User", "RequisitionApprovedByUser")
                        .WithMany("RequisitionApprovedByUser")
                        .HasForeignKey("RequisitionApprovedByUserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS_ADIB.Models.User", "RequisitionAuthorizedByUser")
                        .WithMany("RequisitionAuthorizedByUser")
                        .HasForeignKey("RequisitionAuthorizedByUserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("IssuedByUser");

                    b.Navigation("Item");

                    b.Navigation("RequisitionApprovedByUser");

                    b.Navigation("RequisitionAuthorizedByUser");
                });

            modelBuilder.Entity("WMS_ADIB.Models.Branch", b =>
                {
                    b.Navigation("AssetDisposals");

                    b.Navigation("AssetReturns");

                    b.Navigation("AssetTransfers");

                    b.Navigation("Requisitions");
                });

            modelBuilder.Entity("WMS_ADIB.Models.Item", b =>
                {
                    b.Navigation("AssetDisposals");

                    b.Navigation("AssetReturns");

                    b.Navigation("AssetTransfers");

                    b.Navigation("Requisitions");
                });

            modelBuilder.Entity("WMS_ADIB.Models.PurchaseOrder", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WMS_ADIB.Models.PurchaseRequisition", b =>
                {
                    b.Navigation("PurchaseOrders");
                });

            modelBuilder.Entity("WMS_ADIB.Models.Supplier", b =>
                {
                    b.Navigation("PurchaseOrders");
                });

            modelBuilder.Entity("WMS_ADIB.Models.User", b =>
                {
                    b.Navigation("AssetReturnApprovedBy");

                    b.Navigation("AssetReturnReceivedBy");

                    b.Navigation("AssetTransferAuthorizedByUser");

                    b.Navigation("DisposalApprovedBy");

                    b.Navigation("DisposedBy");

                    b.Navigation("GRNDeliverUser");

                    b.Navigation("GRNInspectUser");

                    b.Navigation("GRNReceiveUser");

                    b.Navigation("IssuedByUser");

                    b.Navigation("PurchaseOrderAuthorizedBy");

                    b.Navigation("PurchaseOrderOrderedBy");

                    b.Navigation("PurchaseRequstionAuthorizedBy");

                    b.Navigation("PurchaseRequstionRequestedByUser");

                    b.Navigation("RequisitionApprovedByUser");

                    b.Navigation("RequisitionAuthorizedByUser");
                });
#pragma warning restore 612, 618
        }
    }
}