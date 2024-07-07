using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Model
{
    public class MarcacaoServico
    {
        [Key]
        public int IdMarcacaoServico { get; set; }
        public int IdServico { get; set; }
        [ForeignKey(nameof(IdServico))]
        public Servico Servico { get; set; }
        public int IdProfissional { get; set; }
        [ForeignKey(nameof(IdProfissional))]
        public Profissional Profissional { get; set; }
        public DateOnly DataMarcacao { get; set; }
        public int IdHorario { get; set; }
        [ForeignKey(nameof(IdHorario))]
        public Horario Horario { get; set; }
    }
}
