using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Migrations
{
    public partial class Change_SKU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HangHoa_MaHH",
                table: "HangHoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hinhs",
                table: "Hinhs");

            migrationBuilder.DropColumn(
                name: "MaHH",
                table: "HangHoa");

            migrationBuilder.RenameTable(
                name: "Hinhs",
                newName: "Hinh");

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "HangHoa",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hinh",
                table: "Hinh",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_SKU",
                table: "HangHoa",
                column: "SKU",
                unique: true,
                filter: "[SKU] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HangHoa_SKU",
                table: "HangHoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hinh",
                table: "Hinh");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "HangHoa");

            migrationBuilder.RenameTable(
                name: "Hinh",
                newName: "Hinhs");

            migrationBuilder.AddColumn<string>(
                name: "MaHH",
                table: "HangHoa",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hinhs",
                table: "Hinhs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaHH",
                table: "HangHoa",
                column: "MaHH",
                unique: true,
                filter: "[MaHH] IS NOT NULL");
        }
    }
}
