using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noticias.Domain.Entidade
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }

        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
