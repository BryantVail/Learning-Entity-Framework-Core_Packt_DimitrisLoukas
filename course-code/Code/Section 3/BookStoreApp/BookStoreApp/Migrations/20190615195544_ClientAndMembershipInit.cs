using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApp.Migrations
{
    public partial class ClientAndMembershipInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookIdentifier",
                table: "Books",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "AuthorDateOfBirth",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorFirstName",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AuthorLastName",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DoB",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Author",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorFirstName_AuthorLastName_AuthorDateOfBirth",
                table: "Books",
                columns: new[] { "AuthorFirstName", "AuthorLastName", "AuthorDateOfBirth" });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Author_AuthorFirstName_AuthorLastName_AuthorDateOfBirth",
                table: "Books",
                columns: new[] { "AuthorFirstName", "AuthorLastName", "AuthorDateOfBirth" },
                principalTable: "Author",
                principalColumns: new[] { "FirstName", "LastName", "DateOfBirth" },
                onDelete: ReferentialAction.Restrict);
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Author_AuthorFirstName_AuthorLastName_AuthorDateOfBirth",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorFirstName_AuthorLastName_AuthorDateOfBirth",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorDateOfBirth",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorFirstName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            //migrationBuilder.DropColumn(
            //    name: "AuthorLastName",
            //    table: "Books");

            migrationBuilder.DropColumn(
                name: "DoB",
                table: "Author");

            //migrationBuilder.DropColumn(
            //    name: "Id",
            //    table: "Author");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "BookIdentifier");
        }
    }
}
