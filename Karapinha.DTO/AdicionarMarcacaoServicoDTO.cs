using Karapinha.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class AdicionarMarcacaoServicoDTO
    {
        public int IdServico { get; set; }
        public int IdMarcacao { get; set; }
    }
}
