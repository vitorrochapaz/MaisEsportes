namespace maisesportes.Shared.Modelos;

public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }
    //public string Turma { get; set; }

    //chave estrangeira
    public int TurmaId { get; set; }
    public Turma Turma { get; set; }

    public Aluno(string nome, int idade, string email, string endereco, int turmaId)
    {
        Nome = nome;
        Idade = idade;
        Email = email;
        Endereco = endereco;
        TurmaId = turmaId;
    }

    public void ExibirDetalhes()
    {
    
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Idade: " + Idade);
        Console.WriteLine("E-mail: " + Email);
        Console.WriteLine("Endereço: " + Endereco);
        Console.WriteLine($"Turma ID: {TurmaId}");
        Console.WriteLine("\n----------------------\n");
    
    }
}
