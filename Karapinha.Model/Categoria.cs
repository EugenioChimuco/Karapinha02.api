using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Model
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string? Tipo { get; set; }
        public bool EstadoCategoria { get; set;}

    }
}
