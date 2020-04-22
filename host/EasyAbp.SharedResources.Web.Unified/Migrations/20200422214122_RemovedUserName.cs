using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.SharedResources.Migrations
{
    public partial class RemovedUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SharedResourcesResourceUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SharedResourcesResourceUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
