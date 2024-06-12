using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class HorarioAtualizarDTO
    {
        public int IdHorario { get; set; }
        public TimeSpan Hora { get; set; }
    }
}
