using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class ServicoAdicionarDTO
    {
        public string TipoDeServico { get; set; }
        public IFormFile Foto { get; set; }
        public string? FotoPath { get; set; }
        public float PrecoDoServico { get; set; }
        public int IdCategoria { get; set; }
    }
}
