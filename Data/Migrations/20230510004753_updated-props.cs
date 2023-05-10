using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedprops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Courses_CourseId",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Investments",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Investments_CourseId",
                table: "Investments",
                newName: "IX_Investments_ItemId");

            migrationBuilder.AddColumn<decimal>(
                name: "TicketPrice",
                table: "Courses",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Courses_ItemId",
                table: "Investments",
                column: "ItemId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Courses_ItemId",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Investments",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Investments_ItemId",
                table: "Investments",
                newName: "IX_Investments_CourseId");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Courses_CourseId",
                table: "Investments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
