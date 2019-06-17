using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApp.Migrations
{
    public partial class authorBookLookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Books_Authors_AuthorId1",
            //    table: "Books");

            //Cannot drop the index 'Books.IX_Books_AuthorId1', because it does not exist or you do not have permission.
            //migrationBuilder.DropIndex(
            //    name: "IX_Books_AuthorId1",
            //    table: "Books");

            //Dropped from SSMS (SqlServerManagementStudio)
            //migrationBuilder.DropColumn(
            //    name: "AuthorId1",
            //    table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int));

            //migrationBuilder.DropColumn(
            //    name: "Id",
            //    table: "Authors");
            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Authors_Id",
            //    table: "Authors",
            //    column: "Id")
            //    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Books_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Authors_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBooks",
                column: "BookId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Books_Authors_AuthorId",
            //    table: "Books",
            //    column: "AuthorId",
            //    principalTable: "Authors",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: false);

            //migrationBuilder.DropColumn(
            //    name: "Id",
            //    table: "Authors");
            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Authors",
            //    type: "int"
            //);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Id",
            //    table: "Authors",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");



            //    migrationBuilder.AddForeignKey(
            //        name: "FK_Books_Authors_AuthorId",
            //        table: "Books",
            //        column: "AuthorId",
            //        principalTable: "Authors",
            //        principalColumn: "Id",
            //        onDelete: ReferentialAction.Restrict);
        }
    }
}
