using Noticias.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticias.Domain.Repositories
{
    public interface INoticiaRepository
    {
        Task AdicionarNoticia(Noticia noticia);
        Task AtualizarNoticia(Noticia noticia);
        Task<Noticia> ObterNoticaPorId(Guid idNoticia);
        Task<List<Noticia>> ObterTodasNoticias();
        public Task Daletar(Guid idNoticia);
    }
}
