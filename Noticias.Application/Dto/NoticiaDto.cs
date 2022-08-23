using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Noticias.Domain.Enum.Enumeradores;

namespace Noticias.Application.Dto
{
    public class NoticiaDto
    {
        public Guid NoticiaId { get; set; }
        public string Titulo { get; set;}
        public string Conteudo { get; set;}
        public string Categoria { get; set; }
    }
}
