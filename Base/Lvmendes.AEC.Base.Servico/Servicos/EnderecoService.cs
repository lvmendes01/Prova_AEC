using Lvmendes.AEC.Base.Entidade;
using Lvmendes.AEC.Base.Entidade.Entidades;
using Lvmendes.AEC.Base.Repositorio.Interfaces;
using Lvmendes.AEC.Base.Servico.Interfaces;
using Lvmendes.AEC.Comum.Interfaces;
using Lvmendes.AEC.Comum.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.AEC.Base.Servico.Servicos
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IAPIviacep servicoAPICEP;
        private IEnderecoRepositorio EnderecoRepositorio;
        private IUsuarioRepositorio UsuarioRepositorio;
        public EnderecoService(IUsuarioRepositorio _UsuarioRepositorio, IEnderecoRepositorio _EnderecoRepositorio, IAPIviacep _servicoAPICEP)
        {
            servicoAPICEP = _servicoAPICEP;
            EnderecoRepositorio = _EnderecoRepositorio;
            UsuarioRepositorio = _UsuarioRepositorio;
        }


        public string Adicionar(EnderecoEntidade entity)
        {


            var enderecoLsita = EnderecoRepositorio.ObterFiltros(s => s.cep == entity.cep);

            if(enderecoLsita.Count > 0 && enderecoLsita.Exists(s=>s.numero == entity.numero && s.complemento == entity.complemento))
            {
                return "Ja existe Endereço cadastrado";
            }



            var usuario = UsuarioRepositorio.Primeiro(s => s.Id == entity.Usuario.Id);



            entity.Usuario = usuario;
            entity.DataCadastro = DateTime.Now;
            return EnderecoRepositorio.Adicionar(entity);
        }

        public string Atualizar(EnderecoEntidade entity)
        {
            return EnderecoRepositorio.Atualizar(entity);
        }

        public string Deletar(Func<EnderecoEntidade, bool> predicate)
        {
            return EnderecoRepositorio.Deletar(predicate);
        }

        public EnderecoEntidade ObterDadosAtravesCep(string cep)
        {
            //Buscar primeiro na base assim evitamos chamar a api repetidamente 
            var pesquisaBase = EnderecoRepositorio.Primeiro(s => s.cep.Replace("-", "") == cep);

            if (pesquisaBase != null)
                return pesquisaBase;



            var resultado = servicoAPICEP.RetornoCep(cep);

            if(resultado != null)
            {
                return new EnderecoEntidade {
                    cep = resultado.cep,
                    bairro = resultado.bairro,
                    cidade = resultado.localidade,
                    complemento = resultado.complemento,
                    logradouro = resultado.logradouro,
                    numero = "",
                    uf = resultado.uf,
                    
                };
            }

            return null;

            
        }

        public List<EnderecoEntidade> ObterFiltros(Expression<Func<EnderecoEntidade, bool>> predicate)
        {
            return EnderecoRepositorio.ObterFiltros(predicate);
        }

        public List<EnderecoEntidade> ObterTodos(bool includes)
        {
            return EnderecoRepositorio.ObterTodos(includes);
        }

        public EnderecoEntidade Primeiro(Expression<Func<EnderecoEntidade, bool>> predicate)
        {
            return EnderecoRepositorio.Primeiro(predicate);
        }

        public EnderecoEntidade Procurar(params object[] key)
        {
            return EnderecoRepositorio.Procurar(key);
        }

        public string RecuperarArquivoCSVEnderecos()
        {
            var listaEnderecos = ObterTodos(false).ToList();
       
            return CsvHelper.WriteCsv(listaEnderecos); 
        }
    }
}
