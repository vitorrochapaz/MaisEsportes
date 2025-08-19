using maisesportes.Shared.Dados;
using maisesportes.Shared.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace maisesportes.API.Endpoints
{
    public static class ProfessoresExtensions
    {
        public static void AddEndpointProfessores(this WebApplication app)
        {
            app.MapGet("/Professores", ([FromServices] DAL<Professor> dal) =>
            {
                return Results.Ok(dal.Listar());
            });

            app.MapGet("/Professores/{id}", ([FromServices] DAL<Professor> dal, int id) =>
            {
                var professor = dal.Recuperar(a => a.Id == id);
                return professor is null ? Results.NotFound() : Results.Ok(professor);
            });

            app.MapPost("/Professores", ([FromServices] DAL<Professor> dal, [FromBody] Professor professor) =>
            {
                dal.Adicionar(professor);
                return Results.Created($"/Professores/{professor.Id}", professor);
            });

            app.MapPut("/Professores/{id}", ([FromServices] DAL<Professor> dal, [FromBody] Professor professorAtualizado, int id) =>
            {
                var professor = dal.Recuperar(a => a.Id == id);
                if (professor is null) return Results.NotFound();

                professor.Nome = professorAtualizado.Nome;
                professor.Idade = professorAtualizado.Idade;
                professor.Email = professorAtualizado.Email;
                professor.Endereco = professorAtualizado.Endereco;

                dal.Atualizar(professor);
                return Results.Ok(professor);
            });

            app.MapDelete("/Professores/{id}", ([FromServices] DAL<Professor> dal, int id) =>
            {
                var professor = dal.Recuperar(a => a.Id == id);
                if (professor is null) return Results.NotFound();

                dal.Deletar(professor);
                return Results.NoContent();
            });
        }
    }
}
