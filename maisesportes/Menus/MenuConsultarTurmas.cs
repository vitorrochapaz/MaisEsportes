using maisesportes.Shared.Dados;
using maisesportes.Shared.Modelos;

namespace maisesportes.Menus;

class MenuConsultarTurmas : Menu
{
    public override void Executar(DAL<Aluno> alunoDAL, DAL<Professor> professorDAL, DAL<Turma> turmaDAL)
    {
        base.Executar(alunoDAL, professorDAL, turmaDAL);
        ExibirTituloDaOpcao("Consulta de Turmas");
        Console.WriteLine("Digite a letra da turma: ");
        string letra = Console.ReadLine()!;
        var turmaRecuperada = turmaDAL.Recuperar(a => a.Letra.Equals(letra));

        if (turmaRecuperada is not null)
        {
            turmaRecuperada.ExibirDetalhes();

            foreach (Aluno aluno in alunoDAL.Listar().Where(a => a.Turma.Equals(letra))) 
            {
                Console.WriteLine(aluno.Nome);
            }

            //foreach (Turma turma in turmasRegistradas.Values)
            //{
            //    if (ID == turma.Id)
            //    {
            //        Console.WriteLine($"Essa turma tem {turma.AlunosRegistrados.Count} alunos.\n");
            //        turma.ExibirDetalhes();
            //        foreach (Aluno aluno in turma.AlunosRegistrados)
            //        {
            //            Console.WriteLine($"{aluno.Nome}");
            //        }

            //    }
            //}

        } else
        {
        Console.WriteLine("Turma não encontrada!");
        MenuConsultarTurmas menu = new();
        }

        Thread.Sleep(4000);
        Console.Clear();
    }
}
