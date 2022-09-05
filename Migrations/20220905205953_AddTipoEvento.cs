using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercicios.Migrations
{
    public partial class AddTipoEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoEvento",
                table: "Evento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoEvento",
                table: "Evento");
        }
    }
}
