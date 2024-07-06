using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class ServicoDTO
    {
        public int IdServico { get; set; }
        public string TipoDeServico { get; set; }
        public float PrecoDoServico { get; set; }
        public string? FotoPath { get; set; }
    }
}
