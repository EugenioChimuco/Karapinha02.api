using Karapinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class AdicionarMarcacaoDTO
    {
        [JsonIgnore]
        public int IdMarcacao { get; set; }
        public DateOnly DataDeMarcacao { get; set; }
        public float PrecoDaMarcacao { get; set; }
        [JsonIgnore]
        public Boolean EstadoDeMarcacao { get; set; }
        public int? IdUtilizador { get; set; }
    }
}
