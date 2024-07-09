using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class MarcacaoDetalhadaDTO
    {
        public DateOnly DataMarcacao { get; set; }
        public string HoraMarcacao { get; set; }
        public string Profissional { get; set; }
        public string Cliente { get; set; }
        public string Servico { get; set; }
    }
}
