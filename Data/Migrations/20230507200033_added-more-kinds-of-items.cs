using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addedmorekindsofitems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_DoneeId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Users_UserId",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "Passrate",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Investments",
                newName: "InvestorId");

            migrationBuilder.RenameColumn(
                name: "DoneeId",
                table: "Courses",
                newName: "OrganisationId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_DoneeId",
                table: "Courses",
                newName: "IX_Courses_OrganisationId");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:item_type", "course,application,bootcamp,online_course,event")
                .Annotation("Npgsql:PostgresExtension:hstore", ",,")
                .OldAnnotation("Npgsql:PostgresExtension:hstore", ",,");

            migrationBuilder.AddColumn<int>(
                name: "Tier",
                table: "Investments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "Activities",
                table: "Courses",
                type: "hstore",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppPurpose",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvarageDuration",
                table: "Courses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Courses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "Curriculum",
                table: "Courses",
                type: "hstore",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Courses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstimatedNumberOfUsers",
                table: "Courses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedRelease",
                table: "Courses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpectedAttendance",
                table: "Courses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpectedAudience",
                table: "Courses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Features",
                table: "Courses",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "Lessons",
                table: "Courses",
                type: "hstore",
                nullable: true);

            migrationBuilder.AddColumn<List<DateTime>>(
                name: "LessonsDate",
                table: "Courses",
                type: "timestamp with time zone[]",
                nullable: true);

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "LinksToChannels",
                table: "Courses",
                type: "hstore",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Markets",
                table: "Courses",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "NotableAttendees",
                table: "Courses",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "NotableSpeakers",
                table: "Courses",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<List<decimal>>(
                name: "Prices",
                table: "Courses",
                type: "numeric[]",
                nullable: false);

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "Tiers",
                table: "Courses",
                type: "hstore",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_OrganisationId",
                table: "Courses",
                column: "OrganisationId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Users_InvestorId",
                table: "Investments",
                column: "InvestorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_OrganisationId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Users_InvestorId",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "Tier",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "Activities",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AppPurpose",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AvarageDuration",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Curriculum",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "EstimatedNumberOfUsers",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "EstimatedRelease",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ExpectedAttendance",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ExpectedAudience",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Features",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Lessons",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LessonsDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LinksToChannels",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Markets",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "NotableAttendees",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "NotableSpeakers",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Prices",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Tiers",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "InvestorId",
                table: "Investments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "OrganisationId",
                table: "Courses",
                newName: "DoneeId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_OrganisationId",
                table: "Courses",
                newName: "IX_Courses_DoneeId");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:hstore", ",,")
                .OldAnnotation("Npgsql:Enum:item_type", "course,application,bootcamp,online_course,event")
                .OldAnnotation("Npgsql:PostgresExtension:hstore", ",,");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Investments",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Passrate",
                table: "Courses",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_DoneeId",
                table: "Courses",
                column: "DoneeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Users_UserId",
                table: "Investments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
