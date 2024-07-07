using Karapinha.DTO;
using Karapinha.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Karapinha.Shared.IService
{
    public interface IMarcacaoService
    {
        Task<Marcacao> MostrarMarcacaoPorId(int id);
        Task<List<Marcacao>> MostrarTodasMarcacoes();
        Task<bool> AceitarPedidoDeMarcacao(int id);
        Task<bool> CriarMarcacaoComServicos(MarcacaoDTO marcacaoDTO);
        Task<List<MarcacaoComServicosDTO>> ListarMarcacoesComServicos();



    }
}