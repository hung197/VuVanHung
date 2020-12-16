using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace demo_qltp_backend.Migrations
{
    public partial class InitalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quanHuyens",
                columns: table => new
                {
                    MaQuanHuyen = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenQuanHuyen = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quanHuyens", x => x.MaQuanHuyen);
                });

            migrationBuilder.CreateTable(
                name: "thanhPhos",
                columns: table => new
                {
                    MaTp = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenTp = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thanhPhos", x => x.MaTp);
                });

            migrationBuilder.CreateTable(
                name: "xaPhuongs",
                columns: table => new
                {
                    MaXaPhuong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenXaPhuong = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xaPhuongs", x => x.MaXaPhuong);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quanHuyens");

            migrationBuilder.DropTable(
                name: "thanhPhos");

            migrationBuilder.DropTable(
                name: "xaPhuongs");
        }
    }
}
