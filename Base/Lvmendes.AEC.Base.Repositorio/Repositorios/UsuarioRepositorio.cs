using Lvmendes.AEC.Base.Entidade;
using Lvmendes.AEC.Base.Entidade.Entidades;
using Lvmendes.AEC.Base.Repositorio.Interfaces;
using Lvmendes.AEC.Comum;
using Lvmendes.AEC.Comum.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.AEC.Base.Repositorio.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        internal ComumBDContext Context;
        public UsuarioRepositorio(ComumBDContext context)
        {
            Context = context;
        }
        public string Adicionar(UsuarioEntidade entity)
        {

            try
            {
                entity.DataCadastro = DateTime.Now;
                entity.Senha = new Hash(SHA512.Create()).CriptografarSenha(entity.Senha);
                Context.Set<UsuarioEntidade>().Add(entity);
                Context.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Atualizar(UsuarioEntidade entity)
        {
            try
            {
                entity.Senha = new Hash(SHA512.Create()).CriptografarSenha(entity.Senha);
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return "Atualizar com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

      
        public string Deletar(Func<UsuarioEntidade, bool> predicate)
        {
            try
            {
                Context.Set<UsuarioEntidade>()
          .Where(predicate).ToList()
          .ForEach(del => Context.Set<UsuarioEntidade>().Remove(del));
                Context.SaveChanges();
                return "Deletado com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public UsuarioEntidade Login(string usuario, string senha)
        {
            var senhaCriptografada = new Hash(SHA512.Create()).CriptografarSenha(senha);

            return Context.Set<UsuarioEntidade>()
                .SingleOrDefault(s=>s.usuario == usuario && s.Senha == senhaCriptografada);
        }

        public List<UsuarioEntidade> ObterFiltros(Expression<Func<UsuarioEntidade, bool>> predicate)
        {
            return Context.Set<UsuarioEntidade>().Where(predicate).ToList();
        }

        public List<UsuarioEntidade> ObterTodos(bool includes = false)
        {
            var query = Context.Set<UsuarioEntidade>().AsQueryable();
            return query.ToList();
        }

        public UsuarioEntidade Primeiro(Expression<Func<UsuarioEntidade, bool>> predicate)
        {
            return Context.Set<UsuarioEntidade>().Where(predicate).FirstOrDefault();
        }

        public UsuarioEntidade Procurar(params object[] key)
        {
            return Context.Set<UsuarioEntidade>().Find(key);
        }
    }
}
