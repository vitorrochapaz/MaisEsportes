using maisesportes.Shared.Dados;
using maisesportes.Shared.Modelos;

namespace maisesportes.Menus;

class MenuConsultarAluno : Menu
{
    public override void Executar(DAL<Aluno> alunoDAL, DAL<Professor> professorDAL, DAL<Turma> turmaDAL)
    {
        base.Executar(alunoDAL, professorDAL, turmaDAL);
        ExibirTituloDaOpcao("Consulta de Alunos");
        Console.WriteLine("Digite o nome do aluno: ");
        string nome = Console.ReadLine()!;
        var AlunoRecuperado = alunoDAL.Recuperar(a => a.Nome.Equals(nome));
        if (AlunoRecuperado is not null)
        {
            Console.WriteLine(" ");
            AlunoRecuperado.ExibirDetalhes();
        }
        else {
        Console.WriteLine("Aluno não encontrado!");
        }
        Thread.Sleep(4000);
        Console.Clear();
    }
}