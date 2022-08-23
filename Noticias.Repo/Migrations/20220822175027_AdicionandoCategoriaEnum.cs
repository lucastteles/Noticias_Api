using Microsoft.EntityFrameworkCore.Migrations;

namespace Noticias.Repo.Migrations
{
    public partial class AdicionandoCategoriaEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Categoria",
                table: "Noticia",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Noticia",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
