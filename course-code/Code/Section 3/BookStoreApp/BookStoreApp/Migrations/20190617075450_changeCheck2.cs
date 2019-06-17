using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApp.Migrations
{
    public partial class changeCheck2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Books_Authors_AuthorId",
            //    table: "Books");

            //migrationBuilder.DropUniqueConstraint(
            //    name: "AK_Authors_TempId",
            //    table: "Authors");

            //migrationBuilder.DropColumn(
            //    name: "TempId",
            //    table: "Authors");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId1",
                table: "Books",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Books_AuthorId1",
            //    table: "Books",
            //    column: "AuthorId1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Books_Authors_AuthorId1",
            //    table: "Books",
            //    column: "AuthorId1",
            //    principalTable: "Authors",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Books_Authors_AuthorId1",
            //    table: "Books"
            //);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId1",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId1",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "TempId",
                table: "Authors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Authors_TempId",
                table: "Authors",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
