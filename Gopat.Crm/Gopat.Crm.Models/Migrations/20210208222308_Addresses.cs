using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gopat.Crm.Models.Migrations
{
    public partial class Addresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_Area",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_BuildingNumberName",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Postcode",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_StreetName",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelledDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RenewalDate",
                table: "Contracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Contracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Address_Area",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_BuildingNumberName",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Postcode",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_StreetName",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplianceTotal",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Cancelled",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ExpectedApplianceTotal",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Rescheduled",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Area",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "Address_BuildingNumberName",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "Address_Postcode",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "Address_StreetName",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "CancelledDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "RenewalDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "Address_Area",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Address_BuildingNumberName",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Address_Postcode",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Address_StreetName",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ApplianceTotal",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ExpectedApplianceTotal",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Rescheduled",
                table: "Appointments");
        }
    }
}
