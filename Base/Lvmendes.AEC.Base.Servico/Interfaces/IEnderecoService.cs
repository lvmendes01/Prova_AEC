

using Lvmendes.AEC.Base.Entidade.Entidades;
using Lvmendes.AEC.Comum.Interfaces;

namespace Lvmendes.AEC.Base.Servico.Interfaces
{
    public interface IEnderecoService : IComumInterfaces<EnderecoEntidade>
    {
        EnderecoEntidade ObterDadosAtravesCep(string cep);
    }
}
