using Microsoft.EntityFrameworkCore;
using Noticias.Domain.Entidade;
using Noticias.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticias.Repo.Repositories
{
    public class NoticiaRepository : INoticiaRepository
    {
        private readonly NoticiaContext _noticiaContext;

        public NoticiaRepository(NoticiaContext noticiaContext)
        {
            _noticiaContext = noticiaContext;
        }

        public async Task AdicionarNoticia(Noticia noticia)
        {
            await _noticiaContext.Noticia.AddAsync(noticia);
            _noticiaContext.SaveChanges();
        }

        public async Task AtualizarNoticia(Noticia noticia)
        {
            _noticiaContext.Noticia.Update(noticia);
            _noticiaContext.SaveChanges();
                
        }

        public async Task<Noticia> ObterNoticaPorId(Guid idNoticia)
        {
            return await _noticiaContext.Noticia.FirstOrDefaultAsync(x => x.Id == idNoticia);
        }

        public async Task<List<Noticia>> ObterTodasNoticias()
        {
            return await _noticiaContext.Noticia.ToListAsync();
        }

        public async Task Daletar(Guid idNoticia)
        {
            var noticia = await ObterNoticaPorId(idNoticia);
            _noticiaContext.Noticia.Remove(noticia);
            _noticiaContext.SaveChanges();
        }
    }
}
