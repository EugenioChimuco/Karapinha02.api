using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Model
{
    public class Servico
    {
        [Key]
        public int IdServico { get; set; }
        public string TipoDeServico { get; set; }
        public float PrecoDoServico { get; set; }
        public string? FotoPath { get; set; }
        public int IdCategoria { get; set; }
        [ForeignKey(nameof(IdCategoria))]
        public Categoria? Categoria { get; set; }

    }
}
