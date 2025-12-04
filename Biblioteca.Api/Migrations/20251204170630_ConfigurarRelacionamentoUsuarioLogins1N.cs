using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Api.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurarRelacionamentoUsuarioLogins1N : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatCadastro",
                table: "Logins",
                newName: "DataCriacao");

            migrationBuilder.AddColumn<bool>(
                name: "Inativo",
                table: "Logins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Logins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UsuarioId",
                table: "Logins",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Usuarios_UsuarioId",
                table: "Logins",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Usuarios_UsuarioId",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_UsuarioId",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "Inativo",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Logins");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Logins",
                newName: "DatCadastro");
        }
    }
}
