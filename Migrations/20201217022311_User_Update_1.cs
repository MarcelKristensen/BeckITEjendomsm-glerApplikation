using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeckITEjendomsmæglerApplikation.Migrations
{
    public partial class User_Update_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_User_PersonId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "Hyperlink",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Address",
                newName: "BoligsidenID");

            migrationBuilder.RenameIndex(
                name: "IX_Address_PersonId",
                table: "Address",
                newName: "IX_Address_BoligsidenID");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Zipcode",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BoligaID",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentDate",
                table: "Address",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Address",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BoligaAddress",
                columns: table => new
                {
                    BoligaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoligaHyperlink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoligaStreet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoligaAddress", x => x.BoligaID);
                });

            migrationBuilder.CreateTable(
                name: "BoligsidenAddress",
                columns: table => new
                {
                    BoligsidenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoligsidenHyperlink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoligsidenStreet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoligsidenAddress", x => x.BoligsidenID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_BoligaID",
                table: "Address",
                column: "BoligaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_BoligaAddress_BoligaID",
                table: "Address",
                column: "BoligaID",
                principalTable: "BoligaAddress",
                principalColumn: "BoligaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_BoligsidenAddress_BoligsidenID",
                table: "Address",
                column: "BoligsidenID",
                principalTable: "BoligsidenAddress",
                principalColumn: "BoligsidenID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_BoligaAddress_BoligaID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_BoligsidenAddress_BoligsidenID",
                table: "Address");

            migrationBuilder.DropTable(
                name: "BoligaAddress");

            migrationBuilder.DropTable(
                name: "BoligsidenAddress");

            migrationBuilder.DropIndex(
                name: "IX_Address_BoligaID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BoligaID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CurrentDate",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "BoligsidenID",
                table: "Address",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_BoligsidenID",
                table: "Address",
                newName: "IX_Address_PersonId");

            migrationBuilder.AlterColumn<int>(
                name: "Zipcode",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hyperlink",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.PersonId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_PersonId",
                table: "Address",
                column: "PersonId",
                principalTable: "User",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
