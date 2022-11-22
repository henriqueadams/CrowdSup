using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrowdSup.Infra.Data.Migrations
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "SEQ_EVENTO");

            migrationBuilder.CreateSequence(
                name: "SEQ_USUARIO",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SEQ_VOLUNTARIO",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    NOME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    SENHA = table.Column<string>(type: "text", nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CIDADE = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    TELEFONE = table.Column<int>(type: "integer", maxLength: 15, nullable: false),
                    SEXO = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EVENTOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    TITULO = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DESCRICAO = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CIDADE = table.Column<string>(type: "text", nullable: false),
                    BAIRRO = table.Column<string>(type: "text", nullable: false),
                    RUA = table.Column<string>(type: "text", nullable: false),
                    NUMERO = table.Column<string>(type: "text", nullable: false),
                    DATA_EVENTO = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ORGANIZADOR_ID = table.Column<int>(type: "integer", nullable: false),
                    QTD_VOLUNT_NEC = table.Column<int>(type: "integer", nullable: false),
                    QTD_PARTICIPANTES = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EVENTO_ORGANIZADOR",
                        column: x => x.ORGANIZADOR_ID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VOLUNTARIOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    USUARIO_ID = table.Column<int>(type: "integer", nullable: false),
                    EVENTO_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VOLUNTARIOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VOLUNTARIO_EVENTO",
                        column: x => x.EVENTO_ID,
                        principalTable: "EVENTOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VOLUNTARIO_USUARIO",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EVENTOS_ORGANIZADOR_ID",
                table: "EVENTOS",
                column: "ORGANIZADOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VOLUNTARIOS_EVENTO_ID",
                table: "VOLUNTARIOS",
                column: "EVENTO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VOLUNTARIOS_USUARIO_ID",
                table: "VOLUNTARIOS",
                column: "USUARIO_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VOLUNTARIOS");

            migrationBuilder.DropTable(
                name: "EVENTOS");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropSequence(
                name: "SEQ_EVENTO");

            migrationBuilder.DropSequence(
                name: "SEQ_USUARIO");

            migrationBuilder.DropSequence(
                name: "SEQ_VOLUNTARIO");
        }
    }
}
