﻿using Karapinha.DTO;
using Karapinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Shared.IService
{
    public interface IMarcacaoServico
    {
        Task<MarcacaoServico> MostrarMarcacaoPorID(int id);
        Task<List<MarcacaoServico>> MostrarTodasMarcacoes();
        Task<bool> AdicionarMarcacaoServico(MarcacaoServicoDTO marcacaoServicoDTO);

    }
}
