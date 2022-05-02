using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreLibrary.Migrations
{
    public partial class mid_admin_table_password_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Passwors",
                table: "Admins",
                newName: "Password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admins",
                newName: "Passwors");
        }
    }
}
