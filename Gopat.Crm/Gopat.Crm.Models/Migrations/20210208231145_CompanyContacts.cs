using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gopat.Crm.Models.Migrations
{
    public partial class CompanyContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TradingStyle",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobRole = table.Column<int>(type: "int", nullable: false),
                    Person_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyId",
                table: "Contacts",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TradingStyle",
                table: "Companies");
        }
    }
}
