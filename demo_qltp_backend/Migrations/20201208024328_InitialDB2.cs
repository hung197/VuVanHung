using Microsoft.EntityFrameworkCore.Migrations;

namespace demo_qltp_backend.Migrations
{
    public partial class InitialDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaTp",
                table: "xaPhuongs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaTp",
                table: "xaPhuongs");
        }
    }
}
