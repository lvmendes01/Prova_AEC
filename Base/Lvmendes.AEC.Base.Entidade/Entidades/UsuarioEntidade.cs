using Lvmendes.AEC.Comum.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.AEC.Base.Entidade.Entidades
{

    [Table("Tb_Usuario")]
    public class UsuarioEntidade : EntidadeBase
    {
        public string usuario { get; set; }
        public string nome { get; set; }
        public string Senha { get; set; }
    }
}
