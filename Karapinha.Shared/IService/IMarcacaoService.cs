using Karapinha.DTO;
using Karapinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Shared.IService
{
    public interface IMarcacaoService
    {
        Task<Marcacao> MostrarMarcacaoPorId(int id);
        Task<List<Marcacao>> MostrarTodasMarcacoes();
        Task<MarcacaoDTO> AdicionarMarcacao(MarcacaoDTO adicionarMarcacaoDTO);
        Task<bool> AceitarPedidoDeMarcacao(int id);
        Task<List<MarcacaoComServicosDTO>> ObterMarcacoesComServicos();


    }
}