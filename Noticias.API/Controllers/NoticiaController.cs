using Microsoft.AspNetCore.Mvc;
using Noticias.Application.Interface;
using Noticias.Application.ViewModel;
using System;
using System.Threading.Tasks;

namespace Noticias.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiaApplication _noticiaApplication;

        public NoticiaController(INoticiaApplication noticiaApplication)
        {
            _noticiaApplication = noticiaApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(NoticiaViewModel noticiaVM)
        {
            try
            {
                await _noticiaApplication.AdicionarNoticia(noticiaVM);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Obter()
        {
            var noticia = await _noticiaApplication.ObterTodasNoticias();

            return Ok(noticia);
        }

        [HttpGet("idNoticia")]
        public async Task<IActionResult> ObterPorId(Guid idNoticia)
        {
            var noticia = await _noticiaApplication.ObterNoticiaPorId(idNoticia);

            return Ok(noticia);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(NoticiaViewModel noticiaVM)
        {
            await _noticiaApplication.AtualizarNoticia(noticiaVM);

            return Ok();
        }

        [HttpDelete("idNoticia")]
        public async Task<IActionResult> Delete(Guid idNoticia)
        {
            await _noticiaApplication.DeletarNoticia(idNoticia);

            return Ok();
        }

    }
}
