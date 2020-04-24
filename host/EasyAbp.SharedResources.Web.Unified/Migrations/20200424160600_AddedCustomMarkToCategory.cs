using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.SharedResources.Migrations
{
    public partial class AddedCustomMarkToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomMark",
                table: "SharedResourcesCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomMark",
                table: "SharedResourcesCategories");
        }
    }
}
