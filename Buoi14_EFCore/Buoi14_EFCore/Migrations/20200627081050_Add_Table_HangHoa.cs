using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Buoi14_EFCore.Migrations
{
    public partial class Add_Table_HangHoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Loais",
                table: "Loais");

            migrationBuilder.RenameTable(
                name: "Loais",
                newName: "Loai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loai",
                table: "Loai",
                column: "MaLoai");

            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    MaHh = table.Column<Guid>(nullable: false),
                    TenHh = table.Column<string>(nullable: false),
                    Hinh = table.Column<string>(nullable: true),
                    DonGia = table.Column<double>(nullable: false),
                    MaLoai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.MaHh);
                    table.ForeignKey(
                        name: "FK_HangHoa_Loai_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "Loai",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa",
                column: "MaLoai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loai",
                table: "Loai");

            migrationBuilder.RenameTable(
                name: "Loai",
                newName: "Loais");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loais",
                table: "Loais",
                column: "MaLoai");
        }
    }
}
