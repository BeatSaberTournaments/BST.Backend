using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BST.Backend.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "model",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "maps",
                columns: table => new
                {
                    map_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    beat_saver_id = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    mapper = table.Column<string>(type: "text", nullable: false),
                    length = table.Column<int>(type: "integer", nullable: false),
                    bpm = table.Column<int>(type: "integer", nullable: false),
                    difficulty = table.Column<string>(type: "text", nullable: false),
                    model_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_maps", x => x.map_id);
                    table.ForeignKey(
                        name: "fk_maps_model_model_id",
                        column: x => x.model_id,
                        principalTable: "model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "map_pools",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    map_id = table.Column<Guid>(type: "uuid", nullable: false),
                    set_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    model_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_map_pools", x => x.id);
                    table.ForeignKey(
                        name: "fk_map_pools_maps_map_id",
                        column: x => x.map_id,
                        principalTable: "maps",
                        principalColumn: "map_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_map_pools_model_model_id",
                        column: x => x.model_id,
                        principalTable: "model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_map_pools_map_id",
                table: "map_pools",
                column: "map_id");

            migrationBuilder.CreateIndex(
                name: "ix_map_pools_model_id",
                table: "map_pools",
                column: "model_id");

            migrationBuilder.CreateIndex(
                name: "ix_maps_model_id",
                table: "maps",
                column: "model_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "map_pools");

            migrationBuilder.DropTable(
                name: "maps");

            migrationBuilder.DropTable(
                name: "model");
        }
    }
}
