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
        [JsonIgnore]
        public int IdMarcacao { get; set; }
        public DateOnly DataDeMarcacao { get; set; }
        public float PrecoDaMarcacao { get; set; }
        public int? IdUtilizador { get; set; }
        public List<int> ServicoIds { get; set; } = new List<int>();
    }

}
