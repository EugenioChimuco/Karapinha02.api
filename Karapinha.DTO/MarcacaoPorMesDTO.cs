using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class MarcacaoPorMesDTO
    {
        public string MesAno { get; set; }
        public List<MarcacaoDetalhadaDTO> Marcacoes { get; set; }
    }
}
