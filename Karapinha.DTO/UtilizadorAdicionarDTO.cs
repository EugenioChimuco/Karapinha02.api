using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class UtilizadorAdicionarDTO
    {
        [JsonIgnore]
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int TipoDeUser { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Bi { get; set; }
        public string? Email { get; set; }
        public IFormFile Foto { get; set; }
        public string? FotoPath { get; set; }
        public string? Phone { get; set; }
    }
}
