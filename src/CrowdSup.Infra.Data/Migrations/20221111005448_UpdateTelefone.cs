using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrowdSup.Infra.Data.Migrations
{
    public partial class UpdateTelefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TELEFONE",
                table: "USUARIOS",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 15);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TELEFONE",
                table: "USUARIOS",
                type: "integer",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);
        }
    }
}
