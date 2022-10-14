using Microsoft.EntityFrameworkCore.Migrations;

namespace eAgenda.Infra.Orm.Migrations
{
    public partial class NomeTipoLocalizacaoCompromisso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoLocal",
                table: "TBCompromisso",
                newName: "TipoLocalizacaoCompromisso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoLocalizacaoCompromisso",
                table: "TBCompromisso",
                newName: "TipoLocal");
        }
    }
}
