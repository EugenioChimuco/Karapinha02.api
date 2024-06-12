using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Model
{
    public class Horario
    {
        [Key] public int IdHorario { get; set; }
        public TimeSpan Hora { get; set; }
    }
}
