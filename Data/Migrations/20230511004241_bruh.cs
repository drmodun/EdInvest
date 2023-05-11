using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class bruh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Countries_CountryId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Subcategories_SubcategoryId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_OrganisationId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Courses_ItemId",
                table: "Investments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_SubcategoryId",
                table: "Items",
                newName: "IX_Items_SubcategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_OrganisationId",
                table: "Items",
                newName: "IX_Items_OrganisationId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CountryId",
                table: "Items",
                newName: "IX_Items_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CategoryId",
                table: "Items",
                newName: "IX_Items_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Items_ItemId",
                table: "Investments",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Countries_CountryId",
                table: "Items",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Subcategories_SubcategoryId",
                table: "Items",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_OrganisationId",
                table: "Items",
                column: "OrganisationId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Items_ItemId",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Countries_CountryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Subcategories_SubcategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_OrganisationId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Items_SubcategoryId",
                table: "Courses",
                newName: "IX_Courses_SubcategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_OrganisationId",
                table: "Courses",
                newName: "IX_Courses_OrganisationId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CountryId",
                table: "Courses",
                newName: "IX_Courses_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CategoryId",
                table: "Courses",
                newName: "IX_Courses_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Countries_CountryId",
                table: "Courses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Subcategories_SubcategoryId",
                table: "Courses",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_OrganisationId",
                table: "Courses",
                column: "OrganisationId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Courses_ItemId",
                table: "Investments",
                column: "ItemId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
