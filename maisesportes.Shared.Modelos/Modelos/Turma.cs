namespace maisesportes.Shared.Modelos;

public class Turma
{
    public int Id { get; set; }
    public string Modalidade { get; set; }
    public string Professor { get; set; }
    public string Horario { get; set; }
    public string Letra { get; set; }
    
    // Relacionamento EF
    public List<Aluno> AlunosRegistrados { get; set; } = new();
    public Turma(string modalidade, string professor, string horario, string letra)
    {
        Modalidade = modalidade;
        Professor = professor;
        Horario = horario;
        Letra = letra;
    }

    public Turma() { } // Necessário para EF Core

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Turma: {Letra}");
        Console.WriteLine($"Modalidade: {Modalidade}");
        Console.WriteLine($"Professor: {Professor}");
        Console.WriteLine($"Horário: {Horario}");
        Console.WriteLine("----------------------\n");
    }
}