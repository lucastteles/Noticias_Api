using Noticias.Application.Dto;
using Noticias.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticias.Application.Interface
{
    public interface INoticiaApplication
    {
        Task AdicionarNoticia(NoticiaViewModel noticiaVM);
        Task<List<NoticiaDto>> ObterTodasNoticias();
        Task AtualizarNoticia(NoticiaViewModel noticiaVM);
        Task<NoticiaDto> ObterNoticiaPorId(Guid idNoticia);
        Task DeletarNoticia (Guid idNoticia);
    }
}
