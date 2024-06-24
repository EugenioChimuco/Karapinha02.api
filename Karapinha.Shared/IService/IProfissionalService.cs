using Karapinha.DTO;
using Karapinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Shared.IService
{
    public interface IProfissionalService
    {
        Task<int> AdicionarProfissional(ProfissionalAdicionarDTO profissionalAdicionarDTO);
        Task<List<Profissional>> ListarTodosProfissionais();
        Task<bool> ApagarProfissional(int id);
        Task AdicionarHorariosAoProfissional(AdicionarHorariosProfissionalDTO dto);
        Task<List<ProfissionalComHorariosDTO>> ObterProfissionaisComHorarios();
    }
}
