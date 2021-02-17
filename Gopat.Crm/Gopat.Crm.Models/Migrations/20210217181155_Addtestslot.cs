using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gopat.Crm.Models.Migrations
{
    public partial class Addtestslot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduledDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedDurationMins = table.Column<int>(type: "int", nullable: false),
                    ActualDurationMins = table.Column<int>(type: "int", nullable: true),
                    Price_CalloutFee = table.Column<long>(type: "bigint", nullable: true),
                    Price_ApplianceTestFee = table.Column<long>(type: "bigint", nullable: true),
                    EstimatedAppliances = table.Column<int>(type: "int", nullable: false),
                    ActualAppliances = table.Column<int>(type: "int", nullable: false),
                    TestSlowResult = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSlots_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestSlots_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestSlots_ContractId",
                table: "TestSlots",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSlots_SiteId",
                table: "TestSlots",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestSlots");
        }
    }
}
