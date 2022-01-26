using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Solicitud_Fondos_Avance_API.Migrations
{
    public partial class tenMigration_AddRelationManyToMany_SubProyecto_Actividad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubProyecto_Actividades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subProyectoId = table.Column<int>(type: "int", nullable: false),
                    actividadProyectoId = table.Column<int>(type: "int", nullable: false),
                    faseActual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<byte>(type: "tinyint", nullable: false, defaultValue:1),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: DateTime.UtcNow),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProyecto_Actividades", x => x.id);
                    table.ForeignKey(
                        name: "FK_SubProyecto_Actividades_ActividadProyectos_actividadProyectoId",
                        column: x => x.actividadProyectoId,
                        principalTable: "ActividadProyectos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubProyecto_Actividades_SubProyectos_subProyectoId",
                        column: x => x.subProyectoId,
                        principalTable: "SubProyectos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubProyecto_Actividades_actividadProyectoId",
                table: "SubProyecto_Actividades",
                column: "actividadProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubProyecto_Actividades_subProyectoId",
                table: "SubProyecto_Actividades",
                column: "subProyectoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubProyecto_Actividades");
        }
    }
}
