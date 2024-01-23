using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeanWork.Atividade3.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarColunaAtivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Candidatos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Candidatos");
        }
    }
}
