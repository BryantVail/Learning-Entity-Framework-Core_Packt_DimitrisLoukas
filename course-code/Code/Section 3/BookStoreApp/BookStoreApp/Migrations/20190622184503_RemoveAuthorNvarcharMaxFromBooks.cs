using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApp.Migrations
{
    public partial class RemoveAuthorNvarcharMaxFromBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");

            
        }

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
            
        //}
    }
}
