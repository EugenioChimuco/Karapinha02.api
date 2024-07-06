﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DTO
{
    public class MarcacaoComServicosDTO
    {
        public int IdMarcacao { get; set; }
        public DateOnly DataDeMarcacao { get; set; }
        public float PrecoDaMarcacao { get; set; }
        public Boolean EstadoDeMarcacao { get; set; }
        public int? IdUtilizador { get; set; }
        public List<ServicoDTO> Servicos { get; set; } = new List<ServicoDTO>();
    }
}
