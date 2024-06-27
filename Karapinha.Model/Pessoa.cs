using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Model
{
    public class Pessoa
    {
        public string? NomeCompleto { get; set; }
        [Unique]
        public string? BI { get; set; }
        [Unique]
        public string? Email { get; set; }
        public string ? FotoPath { get; set; }
        public string? Phone { get; set; }

        public Pessoa()
        {

        }
        public Pessoa(string? nomeCompleto, string? bi, string? email, string? phone)
        {
            NomeCompleto = nomeCompleto;
            BI = bi;
            Email = email;
            Phone = phone;
        }
    }
}
