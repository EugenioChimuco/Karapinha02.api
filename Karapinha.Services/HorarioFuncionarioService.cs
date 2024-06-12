using Karapinha.DAL.Repositories;
using Karapinha.DTO;
using Karapinha.Model;
using Karapinha.Shared.IRepository;
using Karapinha.Shared.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Services
{
    public class HorarioFuncionarioService : IHorarioFuncionarioService
    {
        private readonly IHoraFuncionarioRepository _repository;

        public HorarioFuncionarioService(IHoraFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AdicionarHora(AdicionarHorarioFuncionarioDTO adicionarHorarioFuncionarioDTO)
        {

            var hora = new HorarioFuncionario()
            {
                IdHorario = adicionarHorarioFuncionarioDTO.IdHorario,
                IdProfissional = adicionarHorarioFuncionarioDTO.IdProfissional,
            };
            return await _repository.Criar(hora);
        }


        public async Task<List<HorarioFuncionario>> ListarTodasHoras()
        {
            return await _repository.Listar();
        }
    }
}
