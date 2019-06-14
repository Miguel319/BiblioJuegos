using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiblioJuegos.DAL.Migrations
{
    public partial class ModelosActualizados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenURL",
                table: "Videojuegos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AgregadoEn",
                table: "Usuarios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImagenURL",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AgregadoEn",
                table: "Plataformas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImagenURL",
                table: "Plataformas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AgregadoEn",
                table: "Companias",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImagenURL",
                table: "Companias",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AgregadoEn",
                table: "Categorias",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImagenURL",
                table: "Categorias",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenURL",
                table: "Videojuegos");

            migrationBuilder.DropColumn(
                name: "AgregadoEn",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ImagenURL",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AgregadoEn",
                table: "Plataformas");

            migrationBuilder.DropColumn(
                name: "ImagenURL",
                table: "Plataformas");

            migrationBuilder.DropColumn(
                name: "AgregadoEn",
                table: "Companias");

            migrationBuilder.DropColumn(
                name: "ImagenURL",
                table: "Companias");

            migrationBuilder.DropColumn(
                name: "AgregadoEn",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "ImagenURL",
                table: "Categorias");
        }
    }
}
