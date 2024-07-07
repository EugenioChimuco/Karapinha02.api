using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class MarcacaoServicoDTO
    {
        public int IdMarcacaoServico { get; set; }
        public int IdServico { get; set; }
        public int IdProfissional { get; set; }
        public DateOnly DataMarcacao { get; set; }
        public int HoraMarcacao { get; set; }
    }

}
