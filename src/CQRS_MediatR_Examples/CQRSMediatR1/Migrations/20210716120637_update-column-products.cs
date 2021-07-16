using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRSMediatR1.Migrations
{
    public partial class updatecolumnproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Products",
                newName: "CreatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Products",
                newName: "DateTime");
        }
    }
}
