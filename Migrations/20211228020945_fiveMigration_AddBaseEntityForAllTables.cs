using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Solicitud_Fondos_Avance_API.Migrations
{
    public partial class fiveMigration_AddBaseEntityForAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_creacion",
                table: "Personas",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.UtcNow);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_modificacion",
                table: "Personas",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_creacion",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "fecha_modificacion",
                table: "Personas");
        }
    }
}
