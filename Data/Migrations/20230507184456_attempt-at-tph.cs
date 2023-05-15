using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class attemptattph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDonator",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "FunderId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FunderId",
                table: "Users",
                column: "FunderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_FunderId",
                table: "Users",
                column: "FunderId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_FunderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FunderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FunderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsDonator",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
