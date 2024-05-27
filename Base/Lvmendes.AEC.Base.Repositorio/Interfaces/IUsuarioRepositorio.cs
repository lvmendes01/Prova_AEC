using Lvmendes.AEC.Base.Entidade.Entidades;
using Lvmendes.AEC.Comum.Interfaces;

namespace Lvmendes.AEC.Base.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio : IComumInterfaces<UsuarioEntidade>
    {
        UsuarioEntidade Login(string usuario, string senha);
    }
}
