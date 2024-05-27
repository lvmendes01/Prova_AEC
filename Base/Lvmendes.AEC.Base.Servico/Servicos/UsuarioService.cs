using Lvmendes.AEC.Base.Entidade;
using Lvmendes.AEC.Base.Entidade.Entidades;
using Lvmendes.AEC.Base.Repositorio.Interfaces;
using Lvmendes.AEC.Base.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.AEC.Base.Servico.Servicos
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepositorio UsuarioRepositorio;
        public UsuarioService(IUsuarioRepositorio _UsuarioRepositorio)
        {
            UsuarioRepositorio = _UsuarioRepositorio;
        }


        public string Adicionar(UsuarioEntidade entity)
        {
            return UsuarioRepositorio.Adicionar(entity);
        }

        public string Atualizar(UsuarioEntidade entity)
        {
            return UsuarioRepositorio.Atualizar(entity);
        }

     

        public string Deletar(Func<UsuarioEntidade, bool> predicate)
        {
            return UsuarioRepositorio.Deletar(predicate);
        }

        public UsuarioEntidade Login(string usuario, string senha)
        {
            return UsuarioRepositorio.Login(usuario, senha);
        }

        public List<UsuarioEntidade> ObterFiltros(Expression<Func<UsuarioEntidade, bool>> predicate)
        {
            return UsuarioRepositorio.ObterFiltros(predicate);
        }

        public List<UsuarioEntidade> ObterTodos(bool includes)
        {
            return UsuarioRepositorio.ObterTodos(includes);
        }

        public UsuarioEntidade Primeiro(Expression<Func<UsuarioEntidade, bool>> predicate)
        {
            return UsuarioRepositorio.Primeiro(predicate);
        }

        public UsuarioEntidade Procurar(params object[] key)
        {
            return UsuarioRepositorio.Procurar(key);
        }
    }
}
