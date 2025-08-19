namespace maisesportes.Web.Requests;

public record AlunoRequest(string Nome, int Idade, string Email, string Endereco, int TurmaId);