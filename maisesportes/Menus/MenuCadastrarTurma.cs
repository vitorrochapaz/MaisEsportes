using maisesportes.Shared.Dados;
using maisesportes.Shared.Modelos;
using System;

namespace maisesportes.Menus;

class MenuCadastrarTurma : Menu
{
    public override void Executar(DAL<Aluno> alunoDAL, DAL<Professor> professorDAL, DAL<Turma> turmaDAL)
    {
        base.Executar(alunoDAL, professorDAL, turmaDAL);
        ExibirTituloDaOpcao("Cadastro de Turmas");

        Console.WriteLine("Digite a letra da turma: ");
        string letra = Console.ReadLine()!;
        var turmaRecuperada = turmaDAL.Recuperar(a => a.Letra.Equals(letra));
        if (turmaRecuperada is not null)
        {
            Console.WriteLine("Já existe uma turma registrada com essa letra!");
            Thread.Sleep(4000);
            Console.Clear();
            MenuCadastrarTurma menu = new();
        }
        else
        {
            Console.WriteLine("Digite a modalidade da turma: ");
            string modalidade = Console.ReadLine()!;

            Console.WriteLine("Digite o nome do professor: ");
            string professor = Console.ReadLine()!;

            Console.WriteLine("Digite o horário da aula: ");
            string horario = Console.ReadLine()!;

            Turma turma = new Turma(modalidade, professor, horario, letra);
            turmaDAL.Adicionar(turma);

            Console.WriteLine("Turma registrada com sucesso.");
            Thread.Sleep(4000);
            Console.Clear();
        }
    }
}
