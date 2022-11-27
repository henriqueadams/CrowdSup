using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrowdSup.Infra.Data.Migrations
{
    public partial class AddFotoPerfilToUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FOTO_PERFIL",
                table: "USUARIOS",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FOTO_PERFIL",
                table: "USUARIOS");
        }
    }
}
