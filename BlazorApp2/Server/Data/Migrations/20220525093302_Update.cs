using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp2.Server.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HinhAnh_ThiSinh_ThiSinhId",
                table: "HinhAnh");

            migrationBuilder.AlterColumn<int>(
                name: "ThiSinhId",
                table: "HinhAnh",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhAnh_ThiSinh_ThiSinhId",
                table: "HinhAnh",
                column: "ThiSinhId",
                principalTable: "ThiSinh",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HinhAnh_ThiSinh_ThiSinhId",
                table: "HinhAnh");

            migrationBuilder.AlterColumn<int>(
                name: "ThiSinhId",
                table: "HinhAnh",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HinhAnh_ThiSinh_ThiSinhId",
                table: "HinhAnh",
                column: "ThiSinhId",
                principalTable: "ThiSinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
