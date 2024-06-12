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
    public class HorarioService : IHorarioService
    {
        private readonly IHorarioRepository _horarioRepository;

        public HorarioService(IHorarioRepository horarioRepository)
        {
            _horarioRepository = horarioRepository;
        }

        public async Task<bool> AdicionarHora(HorarioAdicionarDTO horarioAdicionarDTO)
        {
            var horario = new Horario()
            {
                Hora = horarioAdicionarDTO.Hora,
            };
            return await _horarioRepository.Criar(horario);
        }

        public async Task<bool> ApagarHora(int id)
        {
            var horario = await _horarioRepository.MostrarPorId(id);
            if (horario != null)
            {
                return await _horarioRepository.Apagar(horario);
            }
            return false;
        }

        public async Task<bool> AtualizarHora(HorarioAtualizarDTO horarioAtualizarDTO)
        {
            var horario = await _horarioRepository.MostrarPorId(horarioAtualizarDTO.IdHorario);

            if (horario != null)
            {
                horario.Hora = horarioAtualizarDTO.Hora;

                return await _horarioRepository.Atualizar(horario);
            }
            return false;
        }

        public Task<Horario> ListarHoraPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Horario>> ListarTodasHoras()
        {
          return await _horarioRepository.Listar();
        }
    }
}
