using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Migrations
{
    public partial class Init_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hinhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    LoaiHinh = table.Column<int>(nullable: false),
                    MaLoai = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hinhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loai",
                columns: table => new
                {
                    MaLoai = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(maxLength: 100, nullable: false),
                    MaLoaiCha = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai", x => x.MaLoai);
                    table.ForeignKey(
                        name: "FK_Loai_Loai_MaLoaiCha",
                        column: x => x.MaLoaiCha,
                        principalTable: "Loai",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MaHH = table.Column<string>(maxLength: 10, nullable: true),
                    TenHH = table.Column<string>(maxLength: 100, nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    DonGia = table.Column<double>(nullable: false),
                    MoTa = table.Column<string>(maxLength: 200, nullable: true),
                    Hinh = table.Column<string>(maxLength: 150, nullable: true),
                    ChiTiet = table.Column<string>(nullable: true),
                    GiamGia = table.Column<byte>(nullable: false),
                    MaLoai = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HangHoa_Loai_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "Loai",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaHH",
                table: "HangHoa",
                column: "MaHH",
                unique: true,
                filter: "[MaHH] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_Loai_MaLoaiCha",
                table: "Loai",
                column: "MaLoaiCha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoa");

            migrationBuilder.DropTable(
                name: "Hinhs");

            migrationBuilder.DropTable(
                name: "Loai");
        }
    }
}
