namespace maisesportes.Web.Response;

public record TurmaResponse(
    int Id,
    string Modalidade,
    string Professor,
    string Horario,
    string Letra,
    List<string> Alunos  // 👈 nomes dos alunos
);
