using maisesportes.Shared.Dados;
using maisesportes.Shared.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public static class AlunosExtensions
{
    public record AlunoRequest(string Nome, int Idade, string Email, string Endereco, int TurmaId);
    public record AlunoResponse(int Id, string Nome, int Idade, string Email, string Endereco, int TurmaId, string TurmaLetra);

    public static void MapAlunosEndpoints(this WebApplication app)
    {
        // Criar aluno
        app.MapPost("/Alunos", ([FromServices] DAL<Aluno> dal, [FromServices] DAL<Turma> turmaDal, [FromBody] AlunoRequest request) =>
        {
            var turma = turmaDal.Recuperar(t => t.Id == request.TurmaId);
            if (turma is null)
                return Results.BadRequest($"Turma com ID {request.TurmaId} não encontrada.");

            var aluno = new Aluno(request.Nome, request.Idade, request.Email, request.Endereco, request.TurmaId);
            dal.Adicionar(aluno);

            return Results.Created($"/Alunos/{aluno.Id}", EntityToResponse(aluno));
        });

        // Listar todos os alunos
        app.MapGet("/Alunos", async ([FromServices] maisEsportesContext context) =>
        {
            var alunos = await context.Alunos
                .Include(a => a.Turma) // 👈 garante que vem junto
                .Select(a => a.EntityToResponse())
                .ToListAsync();

            return Results.Ok(alunos);
        });

        // Buscar aluno por ID
        app.MapGet("/Alunos/{id}", ([FromServices] DAL<Aluno> dal, int id) =>
        {
            var aluno = dal.Recuperar(a => a.Id == id);
            return aluno is not null ? Results.Ok(EntityToResponse(aluno)) : Results.NotFound();
        });
    }
    public static AlunoResponse EntityToResponse(this Aluno aluno)
    {
        return new AlunoResponse(
            aluno.Id,
            aluno.Nome,
            aluno.Idade,
            aluno.Email,
            aluno.Endereco,
            aluno.TurmaId,                // 👈 novo campo
            aluno.Turma?.Letra ?? ""   // 👈 pega a letra da turma
        );
    }
}
