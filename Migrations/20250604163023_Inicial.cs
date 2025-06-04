using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReconhecimentoFacialApp.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Img_Codigo = table.Column<string>(type: "text", nullable: true),
                    Created_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo_Usuario = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "validacoes_faciais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Usuario_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tipo_Validacao = table.Column<string>(type: "text", nullable: true),
                    Resultado_Validacao = table.Column<string>(type: "text", nullable: true),
                    Mensagem = table.Column<string>(type: "text", nullable: true),
                    Imagem_Path = table.Column<string>(type: "text", nullable: true),
                    Data_Validacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_validacoes_faciais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_validacoes_faciais_usuarios_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_validacoes_faciais_Usuario_Id",
                table: "validacoes_faciais",
                column: "Usuario_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "validacoes_faciais");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
