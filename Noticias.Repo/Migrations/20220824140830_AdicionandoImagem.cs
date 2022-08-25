using Microsoft.EntityFrameworkCore.Migrations;

namespace Noticias.Repo.Migrations
{
    public partial class AdicionandoImagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Noticia",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Noticia");
        }
    }
}
