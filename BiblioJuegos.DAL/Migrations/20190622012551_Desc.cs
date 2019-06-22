using Microsoft.EntityFrameworkCore.Migrations;

namespace BiblioJuegos.DAL.Migrations
{
    public partial class Desc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Videojuegos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Plataformas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Companias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Videojuegos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Plataformas");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Companias");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Categorias");
        }
    }
}
