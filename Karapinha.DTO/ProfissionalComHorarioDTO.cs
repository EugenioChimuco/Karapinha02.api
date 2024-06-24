using System;
using System.Collections.Generic;

namespace Karapinha.DTO
{
    public class ProfissionalComHorariosDTO
    {
        public int IdProfissional { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public int IdCategoria { get; set; }
        public List<TimeSpan> Horarios { get; set; }
    }
}
