using maisesportes.Shared.Dados;
using maisesportes.Shared.Modelos;

namespace maisesportes.Menus;

class MenuSair : Menu
{
    public override void Executar(DAL<Aluno> alunoDAL, DAL<Professor> professorDAL, DAL<Turma> turmaDAL)
    {
        base.Executar(alunoDAL, professorDAL, turmaDAL);
        Console.WriteLine("Pressione qualquer tecla para fechar...");
        Console.ReadKey();
    }
}
