using Lvmendes.AEC.Base.Entidade;
using Lvmendes.AEC.Base.Entidade.Entidades;
using Lvmendes.AEC.Comum.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.AEC.Base.Servico.Interfaces
{
    public interface IUsuarioService : IComumInterfaces<UsuarioEntidade>
    {
        UsuarioEntidade Login(string usuario, string senha);

    }
}
