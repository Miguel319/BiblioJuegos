using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiblioJuegos.DAL.Migrations
{
    public partial class PrimeraMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plataformas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plataformas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombeUsuario = table.Column<string>(nullable: true),
                    Contra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videojuegos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Lanzamiento = table.Column<DateTime>(nullable: false),
                    AgregadoEn = table.Column<DateTime>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: true),
                    CompaniaId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true),
                    PlataformaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videojuegos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videojuegos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Videojuegos_Companias_CompaniaId",
                        column: x => x.CompaniaId,
                        principalTable: "Companias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Videojuegos_Plataformas_PlataformaId",
                        column: x => x.PlataformaId,
                        principalTable: "Plataformas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Videojuegos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videojuegos_CategoriaId",
                table: "Videojuegos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Videojuegos_CompaniaId",
                table: "Videojuegos",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Videojuegos_PlataformaId",
                table: "Videojuegos",
                column: "PlataformaId");

            migrationBuilder.CreateIndex(
                name: "IX_Videojuegos_UsuarioId",
                table: "Videojuegos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videojuegos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Companias");

            migrationBuilder.DropTable(
                name: "Plataformas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
