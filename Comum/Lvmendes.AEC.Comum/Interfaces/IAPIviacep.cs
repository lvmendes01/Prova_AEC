using Lvmendes.AEC.Comum.Entidades.Api.viacep;

namespace Lvmendes.AEC.Comum.Interfaces
{
    public interface IAPIviacep
    {
        Retornoviacep RetornoCep(string cep);
    }
}
