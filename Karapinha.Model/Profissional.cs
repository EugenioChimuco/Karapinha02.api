using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Model
{
    public class Profissional : Pessoa
    {
        [Key]
        public int IdProfissional { get; set; }
        public int IdCategoria { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        public Categoria? Categoria { get; set; }
        public Profissional()
        {

        }
        public Profissional(int idProfissional, int idCategoria, string?
            nomeCompleto, string? bi, string? email, string? foto, string? phone)
            : base(nomeCompleto, bi, email, foto, phone)
        {
            IdProfissional = idProfissional;
            IdCategoria = idCategoria;
        }
    }
}
