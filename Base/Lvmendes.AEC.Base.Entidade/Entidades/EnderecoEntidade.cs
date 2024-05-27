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

    [Table("Tb_Endereco")]
    public class EnderecoEntidade : EntidadeBase
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string numero { get; set; }
        public UsuarioEntidade Usuario { get; set; }

    }
}
