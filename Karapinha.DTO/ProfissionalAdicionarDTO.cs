using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class ProfissionalAdicionarDTO
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Bi { get; set; }
        public string Phone { get; set; }
        public IFormFile Foto { get; set; } 
        public int IdCategoria { get; set; }
        public string ? FotoPath { get; set; }
    }


}
