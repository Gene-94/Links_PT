using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabalho_Final.Migrations
{
    public partial class DbVersion4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "User",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "UserName");
        }
    }
}
