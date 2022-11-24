using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrowdSup.Infra.Data.Migrations
{
    public partial class UpdateEventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QTD_PARTICIPANTES",
                table: "EVENTOS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QTD_PARTICIPANTES",
                table: "EVENTOS",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
