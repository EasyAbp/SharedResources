using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.SharedResources.Migrations
{
    public partial class AdjustedDesigns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "SharedResourcesResources");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SharedResourcesResources");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SharedResourcesResourceItems");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "SharedResourcesCategories");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SharedResourcesCategories");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "SharedResourcesResources",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SharedResourcesCategoryOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    OwnerUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedResourcesCategoryOwners", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SharedResourcesCategoryOwners");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "SharedResourcesResources",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerUserId",
                table: "SharedResourcesResources",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "SharedResourcesResources",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "SharedResourcesResourceItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerUserId",
                table: "SharedResourcesCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "SharedResourcesCategories",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
