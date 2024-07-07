using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class MarcacaoDTO
    {
        
        public DateOnly DataDeMarcacao { get; set; }
        public float PrecoDaMarcacao { get; set; }
        public int? IdUtilizador { get; set; }
        public List<MarcacaoServicoDTO> ListaMarcacoes { get; set; }
    }

}
