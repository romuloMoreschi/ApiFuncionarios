using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAulaDev.Migrations
{
    public partial class AdionandoColunaCPF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Funcionario",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Funcionario");
        }
    }
}
