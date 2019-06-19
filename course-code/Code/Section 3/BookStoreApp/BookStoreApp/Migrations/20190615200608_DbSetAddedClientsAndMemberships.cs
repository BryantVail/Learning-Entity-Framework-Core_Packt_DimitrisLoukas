using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApp.Migrations
{
    public partial class DbSetAddedClientsAndMemberships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Author_AuthorFirstName_AuthorLastName_AuthorDateOfBirth",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                columns: new[] { "FirstName", "LastName", "DateOfBirth" });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 64, nullable: false),
                    LastName = table.Column<string>(maxLength: 64, nullable: false),
                    Email = table.Column<string>(maxLength: 64, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateInitiated = table.Column<DateTime>(nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memberships_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_ClientId",
                table: "Memberships",
                column: "ClientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorFirstName_AuthorLastName_AuthorDateOfBirth",
                table: "Books",
                columns: new[] { "AuthorFirstName", "AuthorLastName", "AuthorDateOfBirth" },
                principalTable: "Authors",
                principalColumns: new[] { "FirstName", "LastName", "DateOfBirth" },
                onDelete: ReferentialAction.Restrict);

            //EDITS//EDITS//EDITS//EDITS//EDITS//EDITS//EDITS//EDITS
            //EDITS//EDITS//EDITS//EDITS//EDITS//EDITS//EDITS//EDITS

            //Drop Books ForeignKey
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            //Drop Authors AlternateKey
            migrationBuilder.DropForeignKey(
                name: "AK_Authors_TempId",
                table: "Authors");
            

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Authors");

            

            //drop & add dbo.Authors.Id to create as "int" type
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Authors",
                type: "int",
                nullable: false);

            //DropForeignKey Books
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorFirstName_AuthorLastName_AuthorDateOfBirth",
                table: "Books");

            //DropPrimaryKey
            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            //AddPrimaryKey to Authors so foreign key check is validated
            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorFirstName_AuthorLastName_AuthorDateOfBirth",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                columns: new[] { "FirstName", "LastName", "DateOfBirth" });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Author_AuthorFirstName_AuthorLastName_AuthorDateOfBirth",
                table: "Books",
                columns: new[] { "AuthorFirstName", "AuthorLastName", "AuthorDateOfBirth" },
                principalTable: "Author",
                principalColumns: new[] { "FirstName", "LastName", "DateOfBirth" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
