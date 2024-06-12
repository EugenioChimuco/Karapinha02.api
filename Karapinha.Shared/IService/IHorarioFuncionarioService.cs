using Karapinha.DTO;
using Karapinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Shared.IService
{
    public interface IHorarioFuncionarioService
    {
        Task<List<HorarioFuncionario>> ListarTodasHoras();
        Task<bool> AdicionarHora(AdicionarHorarioFuncionarioDTO adicionarHorarioFuncionarioDTO);

    }
}
