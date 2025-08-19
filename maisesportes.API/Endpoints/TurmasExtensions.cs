using maisesportes.Shared.Dados;
using maisesportes.Shared.Modelos;
using Microsoft.AspNetCore.Mvc;

public static class TurmasExtensions
{
    public record TurmaRequest(string Modalidade, string Professor, string Horario, string Letra);
    public record TurmaResponse(int Id, string Modalidade, string Professor, string Horario, string Letra, List<string> Alunos);

    public static void MapTurmasEndpoints(this WebApplication app)
    {
        // Criar turma
        app.MapPost("/Turmas", ([FromServices] DAL<Turma> dal, [FromBody] TurmaRequest request) =>
        {
            var turma = new Turma
            {
                Modalidade = request.Modalidade,
                Professor = request.Professor,
                Horario = request.Horario,
                Letra = request.Letra
            };

            dal.Adicionar(turma);
            return Results.Created($"/Turmas/{turma.Id}", EntityToResponse(turma));
        });

        // Listar turmas
        app.MapGet("/Turmas", ([FromServices] DAL<Turma> dal) =>
        {
            var turmas = dal.Listar().Select(t => EntityToResponse(t));
            return Results.Ok(turmas);
        });

        // Buscar turma com alunos
        app.MapGet("/Turmas/{id}", ([FromServices] DAL<Turma> dal, int id) =>
        {
            var turma = dal.RecuperarComAlunos(t => t.Id == id);
            return turma is not null ? Results.Ok(EntityToResponse(turma)) : Results.NotFound();
        });

        app.MapPut("/Turmas/{id}", ([FromServices] DAL<Turma> dal, [FromBody] Turma turmaAtualizada, int id) =>
        {
            var turma = dal.Recuperar(a => a.Id == id);
            if (turma is null) return Results.NotFound();

            turma.Modalidade = turmaAtualizada.Modalidade;
            turma.Professor = turmaAtualizada.Professor;
            turma.Horario = turmaAtualizada.Horario;
            turma.Letra = turmaAtualizada.Letra;

            dal.Atualizar(turma);
            return Results.Ok(turma);
        });
    }

    private static TurmaResponse EntityToResponse(Turma turma) =>
        new(turma.Id, turma.Modalidade, turma.Professor, turma.Horario, turma.Letra,
            turma.AlunosRegistrados?.Select(a => a.Nome).ToList() ?? new List<string>());
}
