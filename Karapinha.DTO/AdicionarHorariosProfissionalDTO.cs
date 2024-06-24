using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class AdicionarHorariosProfissionalDTO
    {
        public int IdProfissional { get; set; }
        public List<int> IdHorarios { get; set; }
    }
}
