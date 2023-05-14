using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addednewprops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEmployees",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfMembers",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Courses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CountryId",
                table: "Courses",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Countries_CountryId",
                table: "Courses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Countries_CountryId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CountryId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NumberOfEmployees",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NumberOfMembers",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Courses");
        }
    }
}
