using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class attemptatenum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BegginingOfEducation",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CV",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CollegeName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CollegeWebsite",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndOfEducation",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FieldId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SchoolarshipPrice",
                table: "Users",
                type: "numeric",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FieldId",
                table: "Users",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Field_FieldId",
                table: "Users",
                column: "FieldId",
                principalTable: "Field",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Field_FieldId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropIndex(
                name: "IX_Users_FieldId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BegginingOfEducation",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CV",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CollegeName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CollegeWebsite",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Course",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EndOfEducation",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SchoolarshipPrice",
                table: "Users");
        }
    }
}
