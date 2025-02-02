﻿using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Karapinha.Model
{
    public class Marcacao
    {
        [Key]
        public int IdMarcacao { get; set; }
        public DateOnly DataDeMarcacao { get; set; }
        public float PrecoDaMarcacao { get; set; }
        public bool EstadoDeMarcacao { get; set; } = false;
        public int? IdUtilizador { get; set; }

        [ForeignKey(nameof(IdUtilizador))]
        public Utilizador Utilizador { get; set; }
        public List<MarcacaoServico> ListaMarcacoes { get; set; } = new List<MarcacaoServico>();
    }

}

