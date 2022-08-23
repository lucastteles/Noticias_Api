using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noticias.Application.Interface;
using Noticias.Application.ViewModel;
using System;
using System.Threading.Tasks;

namespace Noticias.MVC.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly INoticiaApplication _noticaApplication;

        public NoticiaController(INoticiaApplication noticiaApplication)
        {
            _noticaApplication = noticiaApplication;
        }
        // GET: NoticiaController
        public async Task<IActionResult> Index()
        {
            var noticia = await _noticaApplication.ObterTodasNoticias();

            return View(noticia);
        }

        // GET: NoticiaController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var noticia = await _noticaApplication.ObterNoticiaPorId(id);

            return View(noticia);
        }

        // GET: NoticiaController/Create
        public async Task<IActionResult> Create()
        {
           
            return View();
        }

        // POST: NoticiaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NoticiaViewModel noticiaVM)
        {
            try
            {
                await _noticaApplication.AdicionarNoticia(noticiaVM);
                ViewBag.Mensagem = $"{noticiaVM.Titulo} adicionada com sucesso as {DateTime.Now}";
            }
            catch (Exception ex)
            {
                ViewBag.mensagemErro = ex.Message;
            }

            return View();
        }

        // GET: NoticiaController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var noticia = await _noticaApplication.ObterNoticiaPorId(id);

            return View(noticia);
        }

        // POST: NoticiaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NoticiaViewModel noticiaVM)
        {
            await _noticaApplication.AtualizarNoticia(noticiaVM);

            return RedirectToAction(nameof(Index));
        }

        // GET: NoticiaController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var noticia = await _noticaApplication.ObterNoticiaPorId(id);

            return View(noticia);
        }

        // POST: NoticiaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _noticaApplication.DeletarNoticia(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
