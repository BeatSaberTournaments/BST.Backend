using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BST.Backend.Migrations
{
    public partial class AddMapPoolEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_map_pools_maps_map_id",
                table: "map_pools");

            migrationBuilder.DropPrimaryKey(
                name: "pk_maps",
                table: "maps");

            migrationBuilder.DropIndex(
                name: "ix_map_pools_map_id",
                table: "map_pools");

            migrationBuilder.DropColumn(
                name: "map_id",
                table: "map_pools");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "maps",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "pk_maps",
                table: "maps",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_maps_map_id",
                table: "maps",
                column: "map_id");

            migrationBuilder.AddForeignKey(
                name: "fk_maps_map_pools_map_pool_id",
                table: "maps",
                column: "map_id",
                principalTable: "map_pools",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_maps_map_pools_map_pool_id",
                table: "maps");

            migrationBuilder.DropPrimaryKey(
                name: "pk_maps",
                table: "maps");

            migrationBuilder.DropIndex(
                name: "ix_maps_map_id",
                table: "maps");

            migrationBuilder.DropColumn(
                name: "id",
                table: "maps");

            migrationBuilder.AddColumn<Guid>(
                name: "map_id",
                table: "map_pools",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "pk_maps",
                table: "maps",
                column: "map_id");

            migrationBuilder.CreateIndex(
                name: "ix_map_pools_map_id",
                table: "map_pools",
                column: "map_id");

            migrationBuilder.AddForeignKey(
                name: "fk_map_pools_maps_map_id",
                table: "map_pools",
                column: "map_id",
                principalTable: "maps",
                principalColumn: "map_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
