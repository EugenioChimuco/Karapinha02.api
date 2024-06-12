using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Karapinha.Model
{
    public class HorarioFuncionario
    {
        [Key] public int IdHorarioFuncionario { get; set; }
        public int IdProfissional { get; set; }
        [ForeignKey(nameof(IdProfissional))]
        public Profissional? Profissional { get; set; }
        public int IdHorario { get; set; }
        [ForeignKey(nameof(IdHorario))]
        public Horario? Horario { get; set; }
    }
}

