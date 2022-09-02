using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeContatos.Migrations
{
    public partial class AlterandoTabelaAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsAdmin",
                table: "adminModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "adminModels");
        }
    }
}
