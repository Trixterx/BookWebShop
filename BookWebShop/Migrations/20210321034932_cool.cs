using Microsoft.EntityFrameworkCore.Migrations;

namespace BookWebShop.Migrations
{
    public partial class cool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldBooks_Users_UserId",
                table: "SoldBooks");

            migrationBuilder.RenameColumn(
                name: "SessonTimer",
                table: "Users",
                newName: "SessionTimer");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SoldBooks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldBooks_Users_UserId",
                table: "SoldBooks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldBooks_Users_UserId",
                table: "SoldBooks");

            migrationBuilder.RenameColumn(
                name: "SessionTimer",
                table: "Users",
                newName: "SessonTimer");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SoldBooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldBooks_Users_UserId",
                table: "SoldBooks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
