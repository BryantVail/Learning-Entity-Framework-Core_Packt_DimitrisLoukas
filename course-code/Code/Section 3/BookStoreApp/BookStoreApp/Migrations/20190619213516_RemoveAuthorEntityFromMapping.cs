using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApp.Migrations
{
    public partial class RemoveAuthorEntityFromMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //needs to stay bc its the right constraint
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Books_Authors_AuthorId",
            //    table: "Books");

            //index still valid
            //migrationBuilder.DropIndex(
            //    name: "IX_Books_AuthorId",
            //    table: "Books");


            //Edits//Edits//Edits//Edits//Edits//Edits//Edits
            //Edits//Edits//Edits//Edits//Edits//Edits//Edits

            //drop Author Column from Books
            //migrationBuilder.DropColumn(
            //    name: "Author",
            //    table: "Books");

            //didn't need this at home
            migrationBuilder.DropColumn(
                name: "AuthorLastName",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.CreateIndex(
        //        name: "IX_Books_AuthorId",
        //        table: "Books",
        //        column: "AuthorId");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Books_Authors_AuthorId",
        //        table: "Books",
        //        column: "AuthorId",
        //        principalTable: "Authors",
        //        principalColumn: "Id",
        //        onDelete: ReferentialAction.Cascade);
        }
    }
}
