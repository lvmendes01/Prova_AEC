using Lvmendes.AEC.Base.Entidade;
using Lvmendes.AEC.Base.Entidade.Entidades;
using Lvmendes.AEC.Base.Repositorio.Interfaces;
using Lvmendes.AEC.Comum.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.AEC.Base.Repositorio.Repositorios
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {

        internal ComumBDContext Context;
        public EnderecoRepositorio(ComumBDContext context)
        {
            Context = context;
        }
        public string Adicionar(EnderecoEntidade entity)
        {

            try
            {
                Context.Set<EnderecoEntidade>().Add(entity);
                Context.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Atualizar(EnderecoEntidade entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return "Atualizar com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Deletar(Func<EnderecoEntidade, bool> predicate)
        {
            try
            {
                Context.Set<EnderecoEntidade>()
          .Where(predicate).ToList()
          .ForEach(del => Context.Set<EnderecoEntidade>().Remove(del));
                Context.SaveChanges();
                return "Deletado com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public List<EnderecoEntidade> ObterFiltros(Expression<Func<EnderecoEntidade, bool>> predicate)
        {
            return Context.Set<EnderecoEntidade>().Where(predicate).ToList();
        }

        public List<EnderecoEntidade> ObterTodos(bool includes = false)
        {
            var query = Context.Set<EnderecoEntidade>().AsQueryable();
            return query.ToList();
        }

        public EnderecoEntidade Primeiro(Expression<Func<EnderecoEntidade, bool>> predicate)
        {
            return Context.Set<EnderecoEntidade>().Where(predicate).FirstOrDefault();
        }

        public EnderecoEntidade Procurar(params object[] key)
        {
            return Context.Set<EnderecoEntidade>().Find(key);
        }
    }
}
