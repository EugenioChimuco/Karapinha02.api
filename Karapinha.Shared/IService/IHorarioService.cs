using Karapinha.DTO;
using Karapinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Shared.IService
{
    public interface IHorarioService
    {
        Task<Horario> ListarHoraPorId(int id);
        Task<List<Horario>> ListarTodasHoras();
        Task<bool> AtualizarHora(HorarioAtualizarDTO horarioAtualizarDTO);
        Task<bool> AdicionarHora(HorarioAdicionarDTO horarioAdicionarDTO);
        Task<bool> ApagarHora(int id);
    }
}
