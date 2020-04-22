using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.SharedResources.Migrations
{
    public partial class AddedResourceItemType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResourceItemType",
                table: "SharedResourcesResourceItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResourceItemType",
                table: "SharedResourcesResourceItems");
        }
    }
}
