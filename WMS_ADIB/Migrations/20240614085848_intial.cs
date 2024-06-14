using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS_ADIB.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalInfos",
                columns: table => new
                {
                    InfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalInfos", x => x.InfoID);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequisitions",
                columns: table => new
                {
                    PRNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseRequstionRequestedByUserId = table.Column<int>(type: "int", nullable: false),
                    PurchaseRequstionAuthorizedById = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequisitions", x => x.PRNumber);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitions_Users_PurchaseRequstionAuthorizedById",
                        column: x => x.PurchaseRequstionAuthorizedById,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitions_Users_PurchaseRequstionRequestedByUserId",
                        column: x => x.PurchaseRequstionRequestedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    POId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PONumber = table.Column<int>(type: "int", nullable: false),
                    PRNumber = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseOrderOrderedByID = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderOrderedByUserID = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderAuthorizedByID = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderAuthorizedByUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.POId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_PurchaseRequisitions_PRNumber",
                        column: x => x.PRNumber,
                        principalTable: "PurchaseRequisitions",
                        principalColumn: "PRNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Users_PurchaseOrderAuthorizedByID",
                        column: x => x.PurchaseOrderAuthorizedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Users_PurchaseOrderOrderedByUserID",
                        column: x => x.PurchaseOrderOrderedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceivingNotes",
                columns: table => new
                {
                    GRNID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PONumber = table.Column<int>(type: "int", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GRNDeliverUserID = table.Column<int>(type: "int", nullable: false),
                    GRNInspectUserID = table.Column<int>(type: "int", nullable: false),
                    GRNReceiveUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceivingNotes", x => x.GRNID);
                    table.ForeignKey(
                        name: "FK_GoodsReceivingNotes_PurchaseOrders_PONumber",
                        column: x => x.PONumber,
                        principalTable: "PurchaseOrders",
                        principalColumn: "POId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceivingNotes_Users_GRNDeliverUserID",
                        column: x => x.GRNDeliverUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceivingNotes_Users_GRNInspectUserID",
                        column: x => x.GRNInspectUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceivingNotes_Users_GRNReceiveUserID",
                        column: x => x.GRNReceiveUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PONumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Items_PurchaseOrders_PONumber",
                        column: x => x.PONumber,
                        principalTable: "PurchaseOrders",
                        principalColumn: "POId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetDisposals",
                columns: table => new
                {
                    DisposalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateDisposed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    DisposedByUserID = table.Column<int>(type: "int", nullable: false),
                    DisposalApprovedByUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDisposals", x => x.DisposalID);
                    table.ForeignKey(
                        name: "FK_AssetDisposals_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetDisposals_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetDisposals_Users_DisposalApprovedByUserID",
                        column: x => x.DisposalApprovedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetDisposals_Users_DisposedByUserID",
                        column: x => x.DisposedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetReturns",
                columns: table => new
                {
                    ReturnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    DateReturned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AssetReturnReceivedByID = table.Column<int>(type: "int", nullable: false),
                    AssetReturnApprovedByID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetReturns", x => x.ReturnID);
                    table.ForeignKey(
                        name: "FK_AssetReturns_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetReturns_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetReturns_Users_AssetReturnApprovedByID",
                        column: x => x.AssetReturnApprovedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetReturns_Users_AssetReturnReceivedByID",
                        column: x => x.AssetReturnReceivedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetTransfers",
                columns: table => new
                {
                    TransferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromBranchID = table.Column<int>(type: "int", nullable: false),
                    ToBranchID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateTransferred = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AssetTransferAuthorizedByUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTransfers", x => x.TransferID);
                    table.ForeignKey(
                        name: "FK_AssetTransfers_Branches_FromBranchID",
                        column: x => x.FromBranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetTransfers_Branches_ToBranchID",
                        column: x => x.ToBranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetTransfers_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetTransfers_Users_AssetTransferAuthorizedByUserID",
                        column: x => x.AssetTransferAuthorizedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requisitions",
                columns: table => new
                {
                    RequisitionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateApproved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDispatched = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequisitionApprovedByUserID = table.Column<int>(type: "int", nullable: false),
                    RequisitionAuthorizedByUserID = table.Column<int>(type: "int", nullable: false),
                    IssuedByUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisitions", x => x.RequisitionID);
                    table.ForeignKey(
                        name: "FK_Requisitions_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisitions_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisitions_Users_IssuedByUserID",
                        column: x => x.IssuedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requisitions_Users_RequisitionApprovedByUserID",
                        column: x => x.RequisitionApprovedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requisitions_Users_RequisitionAuthorizedByUserID",
                        column: x => x.RequisitionAuthorizedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetDisposals_BranchID",
                table: "AssetDisposals",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDisposals_DisposalApprovedByUserID",
                table: "AssetDisposals",
                column: "DisposalApprovedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDisposals_DisposedByUserID",
                table: "AssetDisposals",
                column: "DisposedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDisposals_ItemID",
                table: "AssetDisposals",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetReturns_AssetReturnApprovedByID",
                table: "AssetReturns",
                column: "AssetReturnApprovedByID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetReturns_AssetReturnReceivedByID",
                table: "AssetReturns",
                column: "AssetReturnReceivedByID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetReturns_BranchID",
                table: "AssetReturns",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetReturns_ItemID",
                table: "AssetReturns",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransfers_AssetTransferAuthorizedByUserID",
                table: "AssetTransfers",
                column: "AssetTransferAuthorizedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransfers_FromBranchID",
                table: "AssetTransfers",
                column: "FromBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransfers_ItemID",
                table: "AssetTransfers",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransfers_ToBranchID",
                table: "AssetTransfers",
                column: "ToBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivingNotes_GRNDeliverUserID",
                table: "GoodsReceivingNotes",
                column: "GRNDeliverUserID");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivingNotes_GRNInspectUserID",
                table: "GoodsReceivingNotes",
                column: "GRNInspectUserID");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivingNotes_GRNReceiveUserID",
                table: "GoodsReceivingNotes",
                column: "GRNReceiveUserID");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivingNotes_PONumber",
                table: "GoodsReceivingNotes",
                column: "PONumber");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PONumber",
                table: "Items",
                column: "PONumber");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_PRNumber",
                table: "PurchaseOrders",
                column: "PRNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_PurchaseOrderAuthorizedByID",
                table: "PurchaseOrders",
                column: "PurchaseOrderAuthorizedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_PurchaseOrderOrderedByUserID",
                table: "PurchaseOrders",
                column: "PurchaseOrderOrderedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_SupplierID",
                table: "PurchaseOrders",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitions_PurchaseRequstionAuthorizedById",
                table: "PurchaseRequisitions",
                column: "PurchaseRequstionAuthorizedById");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitions_PurchaseRequstionRequestedByUserId",
                table: "PurchaseRequisitions",
                column: "PurchaseRequstionRequestedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitions_UserID",
                table: "PurchaseRequisitions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_BranchID",
                table: "Requisitions",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_IssuedByUserID",
                table: "Requisitions",
                column: "IssuedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_ItemID",
                table: "Requisitions",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_RequisitionApprovedByUserID",
                table: "Requisitions",
                column: "RequisitionApprovedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_RequisitionAuthorizedByUserID",
                table: "Requisitions",
                column: "RequisitionAuthorizedByUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalInfos");

            migrationBuilder.DropTable(
                name: "AssetDisposals");

            migrationBuilder.DropTable(
                name: "AssetReturns");

            migrationBuilder.DropTable(
                name: "AssetTransfers");

            migrationBuilder.DropTable(
                name: "GoodsReceivingNotes");

            migrationBuilder.DropTable(
                name: "Requisitions");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "PurchaseRequisitions");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
