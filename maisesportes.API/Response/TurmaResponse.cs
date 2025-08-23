namespace maisesportes.API.Response;

public record TurmaResponse(int id, string modalidade, string professor, string horario, string letra, ICollection<TurmaResponse> AlunosRegistrados);
