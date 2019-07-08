using Microsoft.EntityFrameworkCore.Migrations;

namespace BiblioJuegos.DAL.Migrations
{
    public partial class UsuarioSupr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videojuegos_Usuarios_UsuarioId",
                table: "Videojuegos");

            migrationBuilder.DropIndex(
                name: "IX_Videojuegos_UsuarioId",
                table: "Videojuegos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Videojuegos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Videojuegos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videojuegos_UsuarioId",
                table: "Videojuegos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videojuegos_Usuarios_UsuarioId",
                table: "Videojuegos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
