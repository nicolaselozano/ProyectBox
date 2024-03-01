using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Portafolio.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProyectImages_Proyects_ProyectId1",
                table: "ProyectImages");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProyectId1",
                table: "ProyectImages",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectImages_Proyects_ProyectId1",
                table: "ProyectImages",
                column: "ProyectId1",
                principalTable: "Proyects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProyectImages_Proyects_ProyectId1",
                table: "ProyectImages");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProyectId1",
                table: "ProyectImages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectImages_Proyects_ProyectId1",
                table: "ProyectImages",
                column: "ProyectId1",
                principalTable: "Proyects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
