using Microsoft.EntityFrameworkCore.Migrations;

namespace demo_qltp_backend.Migrations
{
    public partial class InitialDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaQuanHuyen",
                table: "xaPhuongs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaTp",
                table: "quanHuyens",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaQuanHuyen",
                table: "xaPhuongs");

            migrationBuilder.DropColumn(
                name: "MaTp",
                table: "quanHuyens");
        }
    }
}
