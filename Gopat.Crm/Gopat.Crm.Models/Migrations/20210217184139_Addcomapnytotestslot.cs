using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gopat.Crm.Models.Migrations
{
    public partial class Addcomapnytotestslot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "TestSlots",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );
            

            migrationBuilder.CreateIndex(
                name: "IX_TestSlots_CompanyId",
                table: "TestSlots",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TestSlots_CompanyId",
                table: "TestSlots");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "TestSlots"
            );
        }
    }
}
