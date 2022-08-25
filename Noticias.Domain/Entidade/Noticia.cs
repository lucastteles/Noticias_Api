using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Noticias.Domain.Enum.Enumeradores;

namespace Noticias.Domain.Entidade
{
    public class Noticia : EntidadeBase
    {
        private Noticia() { }


        public Noticia(string titulo, string conteudo, CategoriaEnum categoria, string imagem)
        {
            Titulo = titulo;
            Conteudo = conteudo;
            Categoria = categoria;
            Imagem = imagem;
            


            ValidarTitulo();
            ValidarMaximo50Caracteres();
            ValidarConteudo();
        }

        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Imagem { get; set; }
        public CategoriaEnum Categoria { get; set; }

        private void ValidarTitulo()
        {
            if (string.IsNullOrEmpty(Titulo))
            {
                throw new Exception("O campo titulo não pode ser vazio");
            }
        }

        private void ValidarMaximo50Caracteres()
        {
            if (Titulo.Length > 50)
            {
                throw new Exception("O campo titulo não pode ser maior que 50 caracteres");
            }
        }

        private void ValidarConteudo()
        {
            if (string.IsNullOrEmpty(Conteudo))
            {
                throw new Exception("O campo conteúdo não pode ser vazio");
            }
        }

        public void AtualizarDadosDaNoticia(string titulo, string conteudo, CategoriaEnum categoria, string imagem)
        {
            Titulo = titulo;
            Conteudo = conteudo;
            Categoria = categoria;
            Imagem = imagem;

            ValidarTitulo();
            ValidarMaximo50Caracteres();
            ValidarConteudo();

        }
    }
}
