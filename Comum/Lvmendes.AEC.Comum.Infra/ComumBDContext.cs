
using Lvmendes.AEC.Base.Entidade.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.AEC.Comum.Infra
{
    public class ComumBDContext : DbContext
    {

        public ComumBDContext(DbContextOptions<ComumBDContext> options) : base(options)
        {

        }
        public DbSet<UsuarioEntidade> Usuarios { get; set; }
        public DbSet<EnderecoEntidade> Entidades { get; set; }
      

    }


}