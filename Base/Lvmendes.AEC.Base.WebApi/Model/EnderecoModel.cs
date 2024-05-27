using Lvmendes.AEC.Base.Entidade.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lvmendes.AEC.Base.WebApi.Model
{
    public class EnderecoModel
    {
        public Int64 Id { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string numero { get; set; }
        public Int64 UsuarioId { get; set; }



    }

    public static class ModelEntidade
    {



        public static EnderecoEntidade _RecuperarEndereco(EnderecoModel entidade)
        {
            if (entidade == null)
            {
                throw new ArgumentNullException(nameof(entidade), "EnderecoModel cannot be null");
            }

            return new EnderecoEntidade
            {
                cep = entidade.cep,
                bairro = entidade.bairro,
                cidade = entidade.cidade,
                complemento = entidade.complemento,
                logradouro = entidade.logradouro,
                numero = "",
                uf = entidade.uf,
                Usuario = new UsuarioEntidade { Id = entidade.UsuarioId}
            };
        }

        public static EnderecoModel _RecuperarEndereco(EnderecoEntidade entidade)
        {
            if (entidade == null)
            {
                throw new ArgumentNullException(nameof(entidade), "EnderecoModel cannot be null");
            }

            return new EnderecoModel
            {
                cep = entidade.cep,
                bairro = entidade.bairro,
                cidade = entidade.cidade,
                complemento = entidade.complemento,
                logradouro = entidade.logradouro,
                numero = "",
                uf = entidade.uf
            };
        }

    }
}

