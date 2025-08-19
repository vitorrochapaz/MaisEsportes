using maisesportes.Shared.Dados;
using maisesportes.Shared.Modelos;

namespace maisesportes.Menus;

class MenuConsultarProfessor : Menu
{
    public override void Executar(DAL<Aluno> alunoDAL, DAL<Professor> professorDAL, DAL<Turma> turmaDAL)
    {
        base.Executar(alunoDAL, professorDAL, turmaDAL);
        ExibirTituloDaOpcao("Consulta de Professores");
        Console.WriteLine("Digite o nome do professor: ");
        string nome = Console.ReadLine()!;
        var professorRecuperado = professorDAL.Recuperar(a => a.Nome.Equals(nome));
        if (professorRecuperado is not null)
        {
            professorRecuperado.ExibirDetalhes();
}
        else
        {
            Console.WriteLine("Professor não encontrado!");
            MenuConsultarAluno menu = new();
        }
        Thread.Sleep(4000);
        Console.Clear();

    }
}
