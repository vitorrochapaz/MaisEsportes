using maisesportes.Shared.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace maisesportes.Shared.Dados;

public class DAL<T> where T : class
{
    private readonly maisEsportesContext context;

    public DAL(maisEsportesContext context)
    {
        this.context = context;
    }

    public IEnumerable<T> Listar()
    {
        return context.Set<T>().ToList();
    }
    public void Adicionar(T objeto)
    {
        context.Set<T>().Add(objeto);
        context.SaveChanges();
    }
    public void Atualizar(T objeto)
    {
        context.Set<T>().Update(objeto);
        context.SaveChanges();
    }
    public void Deletar(T objeto)
    {
        context.Set<T>().Remove(objeto);
        context.SaveChanges();
    }
    public T? Recuperar(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }
    public Turma? RecuperarComAlunos(Expression<Func<Turma, bool>> predicate)
    {
        return context.Turmas
            .Include(t => t.AlunosRegistrados)
            .FirstOrDefault(predicate);
    }
}
