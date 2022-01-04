using Microsoft.EntityFrameworkCore.Migrations;

namespace Solicitud_Fondos_Avance_API.Migrations
{
    public partial class sevenMigration_ModifyRelation0toMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Personas_personaId",
                table: "Proyectos");

            migrationBuilder.AlterColumn<int>(
                name: "personaId",
                table: "Proyectos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Personas_personaId",
                table: "Proyectos",
                column: "personaId",
                principalTable: "Personas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Personas_personaId",
                table: "Proyectos");

            migrationBuilder.AlterColumn<int>(
                name: "personaId",
                table: "Proyectos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Personas_personaId",
                table: "Proyectos",
                column: "personaId",
                principalTable: "Personas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
