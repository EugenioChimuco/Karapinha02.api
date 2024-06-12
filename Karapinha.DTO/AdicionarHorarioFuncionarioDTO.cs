using Karapinha.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class AdicionarHorarioFuncionarioDTO
    {
        public int IdProfissional { get; set; } 
        public int IdHorario { get; set; }
     
    }
}
