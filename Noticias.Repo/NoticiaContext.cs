using Microsoft.EntityFrameworkCore;
using Noticias.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticias.Repo
{
    public class NoticiaContext : DbContext
    {
        public NoticiaContext(DbContextOptions<NoticiaContext> options) : base(options)
        { 

        }

        public NoticiaContext()
        {

        }

        public DbSet<Noticia> Noticia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NoticiaContext).Assembly);
        }

    }
}
