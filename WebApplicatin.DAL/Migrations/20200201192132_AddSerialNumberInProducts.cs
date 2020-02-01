using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicatin.DAL.Migrations
{
    public partial class AddSerialNumberInProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Products");
        }
    }
}
