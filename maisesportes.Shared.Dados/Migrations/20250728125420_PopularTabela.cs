using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maisesportes.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Alunos",
                columns: new[] { "Nome", "Idade", "Email", "Endereco", "Turma" }, 
                new object[] {"Denis", 15, "denis@gmail.com", "Capadocia, 452", "A"});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Alunos");
        }
    }
}
