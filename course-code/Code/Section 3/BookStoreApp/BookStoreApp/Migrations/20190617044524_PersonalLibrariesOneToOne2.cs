using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApp.Migrations
{
    public partial class PersonalLibrariesOneToOne2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorFirstName_AuthorLastName_AuthorDateOfBirth",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorFirstName_AuthorLastName_AuthorDateOfBirth",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "AuthorDateOfBirth",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorFirstName",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "AuthorLastName",
                table: "Books",
                newName: "AuthorId1");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Authors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Authors",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Authors",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId1",
                table: "Books",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId1",
                table: "Books",
                column: "AuthorId1",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId1",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId1",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "AuthorId1",
                table: "Books",
                newName: "AuthorLastName");

            migrationBuilder.AddColumn<DateTime>(
                name: "AuthorDateOfBirth",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorFirstName",
                table: "Books",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Authors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Authors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Authors",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                columns: new[] { "FirstName", "LastName", "DateOfBirth" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorFirstName_AuthorLastName_AuthorDateOfBirth",
                table: "Books",
                columns: new[] { "AuthorFirstName", "AuthorLastName", "AuthorDateOfBirth" });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorFirstName_AuthorLastName_AuthorDateOfBirth",
                table: "Books",
                columns: new[] { "AuthorFirstName", "AuthorLastName", "AuthorDateOfBirth" },
                principalTable: "Authors",
                principalColumns: new[] { "FirstName", "LastName", "DateOfBirth" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
