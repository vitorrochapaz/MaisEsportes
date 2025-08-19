using maisesportes.Shared.Dados;
using maisesportes.Shared.Modelos;

namespace maisesportes.Menus;

class MenuCadastrarAluno : Menu
{
    public override void Executar(DAL<Aluno> alunoDAL, DAL<Professor> professorDAL, DAL<Turma> turmaDAL)
    {
        base.Executar(alunoDAL, professorDAL, turmaDAL);
        ExibirTituloDaOpcao("Cadastro de Alunos");

        Console.WriteLine("Digite o nome do aluno: ");
        string nome = Console.ReadLine()!;

        Console.WriteLine("Digite a idade do aluno: ");
        int idade = Convert.ToInt32(Console.ReadLine())!;

        Console.WriteLine("Digite o e-mail do aluno: ");
        string email = Console.ReadLine()!;

        Console.WriteLine("Digite o endereço do aluno: ");
        string endereco = Console.ReadLine()!;

        Console.WriteLine("Digite a turma que o aluno irá entrar: ");
        string turma = Console.ReadLine()!;
        var turmaRecuperada = turmaDAL.Recuperar(a => a.Letra.Equals(turma));

        if (turmaRecuperada is not null)
        {
            Console.WriteLine("Aluno adicionado com sucesso.");
            Aluno aluno = new Aluno(nome, idade, email, endereco, turmaRecuperada.Id);
            alunoDAL.Adicionar(aluno);
        }
        else
        {
            Console.WriteLine("Turma não encontrada!");
            return;
        }


        //foreach (Turma t in turmasRegistradas.Values)
        //{
        //    if (t.ID == turma)
        //    {
        //        t.AlunosRegistrados.Add(aluno);
        //    }
        //}


        Thread.Sleep(4000);
        Console.Clear();
    }
}


