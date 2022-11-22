using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrowdSup.Infra.Data.Migrations
{
    public partial class UpdateUsuariosAndEventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ESTADO",
                table: "USUARIOS",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Estado",
                table: "EVENTOS",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ESTADO",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "Endereco_Estado",
                table: "EVENTOS");
        }
    }
}
