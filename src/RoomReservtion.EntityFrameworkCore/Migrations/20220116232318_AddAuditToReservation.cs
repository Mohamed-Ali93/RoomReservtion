using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomReservtion.Migrations
{
    public partial class AddAuditToReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Reservations",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Reservations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "Reservations");
        }
    }
}
