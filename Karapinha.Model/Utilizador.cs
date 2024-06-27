using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Model
{
    public class Utilizador : Pessoa
    {
        [Key]
        public int IdUtilizador { get; set; }
        [Unique]
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int TipoDeUser { get; set; }
        public Boolean EstadoDoUtilizador { get; set; }
        public Boolean EstadoDaConta { get; set; }
        public Utilizador()
        {

        }
        public Utilizador(int idUtilizador, string? userName, string? password, int tipoDeUser,
                          string? nomeCompleto, string? bi, string? email, string? phone)
            : base(nomeCompleto, bi, email, phone)
        {
            IdUtilizador = idUtilizador;
            UserName = userName;
            Password = password;
            TipoDeUser = tipoDeUser;
            EstadoDoUtilizador = false;
            EstadoDaConta = false;
        }

    }
}
