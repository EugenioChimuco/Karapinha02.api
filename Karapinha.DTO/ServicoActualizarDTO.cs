using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class ServicoActualizarDTO
    {
        [JsonIgnore]
        public int IdServico { get; set; }
        public string TipoDeServico { get; set; }
        public float PrecoDoServico { get; set; }
        public int IdCategoria { get; set; }
    }
}
