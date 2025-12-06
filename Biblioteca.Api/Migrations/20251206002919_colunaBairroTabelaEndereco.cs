using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Api.Migrations
{
    /// <inheritdoc />
    public partial class colunaBairroTabelaEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Usuarios_UsuarioId",
                table: "Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Enderecos_EnderecoId",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Enderecos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Usuarios_UsuarioId",
                table: "Logins",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Enderecos_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Usuarios_UsuarioId",
                table: "Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Enderecos_EnderecoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Enderecos");

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Usuarios_UsuarioId",
                table: "Logins",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Enderecos_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
