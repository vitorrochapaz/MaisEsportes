namespace maisesportes.Shared.Modelos;

public class Professor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }
    public string Turmas { get; set; }

    public Professor(string nome, int idade, string email, string endereco, string turmas)
    {
        Nome = nome;
        Idade = idade;
        Email = email;
        Endereco = endereco;
        Turmas = turmas;
    }

    public void ExibirDetalhes()
    {

        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Idade: " + Idade);
        Console.WriteLine("E-mail: " + Email);
        Console.WriteLine("Endereço: " + Endereco);
        Console.WriteLine("Turmas: " + Turmas);
        Console.WriteLine("\n----------------------\n");

    }
}
