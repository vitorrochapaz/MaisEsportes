using maisesportes.Shared.Dados;
using maisesportes.Menus;
using maisesportes.Shared.Modelos;

var context = new maisEsportesContext();
var alunoDAL = new DAL<Aluno>(context);
var professorDAL = new DAL<Professor>(context);
var turmaDAL = new DAL<Turma>(context);

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuCadastrarAluno());
opcoes.Add(2, new MenuCadastrarProfessor());
opcoes.Add(3, new MenuCadastrarTurma());
opcoes.Add(4, new MenuConsultarAluno());
opcoes.Add(5, new MenuConsultarProfessor());
opcoes.Add(6, new MenuConsultarTurmas());
opcoes.Add(7, new MenuSair());

ExibirOpcoesDoMenu();

void ExibirOpcoesDoMenu()
{
    Console.WriteLine("Selecione uma opção:");
    Console.WriteLine("1 - Cadastrar Aluno");
    Console.WriteLine("2 - Cadastrar Professor");
    Console.WriteLine("3 - Cadastrar Turma");
    Console.WriteLine("4 - Consulta de Aluno");
    Console.WriteLine("5 - Consulta de Professor");
    Console.WriteLine("6 - Consulta de Turmas");
    Console.WriteLine("7 - Sair\n");

    Console.Write("Digite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = Convert.ToInt32(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica) && opcaoEscolhidaNumerica != 7)
    {
        Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
        menuASerExibido.Executar(alunoDAL, professorDAL, turmaDAL);
        ExibirOpcoesDoMenu();
    }
    else if (opcaoEscolhidaNumerica == 7)
    {
        Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
        menuASerExibido.Executar(alunoDAL, professorDAL, turmaDAL);
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }
}



