using Karapinha.DTO;
using Karapinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Shared.IService
{
    public interface IServicoService
    {
        Task<bool> MostrarPorID(int id);
        Task<List<Servico>> ListarTodosServicos();
        Task<bool> AtualizarServico(int id, ServicoActualizarDTO ServicoAtualizarDTO);
        Task<bool> AdicionarServico(ServicoAdicionarDTO ServicoAdicionarDTO);
        Task<bool> ApagarServico(int id);

        
    }
}
