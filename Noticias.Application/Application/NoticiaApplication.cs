using Noticias.Application.Dto;
using Noticias.Application.Interface;
using Noticias.Application.ViewModel;
using Noticias.Domain.Entidade;
using Noticias.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticias.Application.Application
{
    public class NoticiaApplication : INoticiaApplication
    {
        private readonly INoticiaRepository _noticiaRepository;

        public NoticiaApplication(INoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
        }

        public async Task AdicionarNoticia(NoticiaViewModel noticiaVM)
        {
           
            var noticia = new Noticia(noticiaVM.Titulo, noticiaVM.Conteudo, noticiaVM.Categoria, noticiaVM.Imagem);

            //if (noticia.Categoria != noticia.Categoria)
            //{
            //    throw new Exception("Erro");
            //}

            await _noticiaRepository.AdicionarNoticia(noticia);
        }

        public async Task AtualizarNoticia(NoticiaViewModel noticiaVM)
        {
            var noticia = await _noticiaRepository.ObterNoticaPorId(noticiaVM.NoticiaId);

            noticia.AtualizarDadosDaNoticia(noticiaVM.Titulo, noticiaVM.Conteudo, noticiaVM.Categoria, noticiaVM.Imagem);

            await _noticiaRepository.AtualizarNoticia(noticia);
        }

        public async Task<NoticiaDto> ObterNoticiaPorId(Guid idNoticia)
        {
            var noticia = await _noticiaRepository.ObterNoticaPorId(idNoticia);

            var noticiaDto = new NoticiaDto()
            {
                Titulo = noticia.Titulo,
                Conteudo = noticia.Conteudo,
                Categoria = noticia.Categoria.ToString(),
                Imagem = noticia.Imagem,
                NoticiaId = noticia.Id
            };

            return noticiaDto;
        }

        public async Task<List<NoticiaDto>> ObterTodasNoticias()
        {
            var noticias = await _noticiaRepository.ObterTodasNoticias();

            var listaNoticias = new List<NoticiaDto>();

            foreach (var noticia in noticias)
            {
                var noticiaDto = new NoticiaDto()
                {
                    Titulo = noticia.Titulo,
                    Conteudo = noticia.Conteudo,
                    Categoria =  noticia.Categoria.ToString(),
                    Imagem = noticia.Imagem,
                    DataCadastro = noticia.DataCadastro,
                    NoticiaId = noticia.Id
                   
                };

                listaNoticias.Add(noticiaDto);
            }
            return listaNoticias;
        }

        public async Task DeletarNoticia(Guid idNoticia)
        {
            await _noticiaRepository.Daletar(idNoticia);
        }
    }
}
