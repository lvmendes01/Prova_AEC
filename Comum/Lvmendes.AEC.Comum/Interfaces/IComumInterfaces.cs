
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lvmendes.AEC.Comum.Interfaces
{
    public interface IComumInterfaces<T> where T : class
    {
        List<T> ObterTodos(bool includes = false);
        List<T> ObterFiltros(Expression<Func<T, bool>> predicate);
        T Procurar(params object[] key);
        T Primeiro(Expression<Func<T, bool>> predicate);
        string Adicionar(T entity);
        string Atualizar(T entity);
        string Deletar(Func<T, bool> predicate);
    }
}

