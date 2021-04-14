using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.SharedResources.Migrations
{
    public partial class AddedItemCountToResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemCount",
                table: "SharedResourcesResources",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCount",
                table: "SharedResourcesResources");
        }
    }
}
