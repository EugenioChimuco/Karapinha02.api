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
        public int IdMArcacoaServico { get; set; }
        public int IdServico { get; set; }
        [ForeignKey(nameof(IdServico))]
        public Servico? Servico { get; set; }
        public int IdMarcacao {  get; set; }
        [ForeignKey(nameof(IdMarcacao))]
        public Marcacao ? Marcacao { get; set; }

    }
}
