using Karapinha.DAL.Repositories;
using Karapinha.DTO;
using Karapinha.Model;
using Karapinha.Shared.IRepository;
using Karapinha.Shared.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karapinha.Services
{
    public class ProfissionalService : IProfissionalService
    {
        private readonly IProfissionalRepository _profissionalRepository;
        private readonly IHorarioRepository _horarioRepository;
        private readonly IHoraFuncionarioRepository _horarioFuncionarioRepository;

        public ProfissionalService(IProfissionalRepository profissionalRepository, IHorarioRepository horarioRepository, IHoraFuncionarioRepository horarioFuncionarioRepository)
        {
            _profissionalRepository = profissionalRepository;
            _horarioRepository = horarioRepository;
            _horarioFuncionarioRepository = horarioFuncionarioRepository;
        }
        public async Task<int> AdicionarProfissional(ProfissionalAdicionarDTO profissionalAdicionarDTO)
        {
            var profissional = new Profissional
            {
                NomeCompleto = profissionalAdicionarDTO.NomeCompleto,
                Email = profissionalAdicionarDTO.Email,
                BI = profissionalAdicionarDTO.Bi,
                Phone = profissionalAdicionarDTO.Phone,
                Foto = profissionalAdicionarDTO.Foto,
                IdCategoria = profissionalAdicionarDTO.IdCategoria
            };

            await _profissionalRepository.Criar(profissional);

            return profissional.IdProfissional;
        }


        public async Task<bool> ApagarProfissional(int id)
        {
            var profissional = await _profissionalRepository.MostrarPorId(id);
            if (profissional == null)
            {
                return false;
            }
            await _profissionalRepository.Apagar(profissional);
            return true;
        }

        public async Task<List<Profissional>> ListarTodosProfissionais()
        {
            return await _profissionalRepository.Listar();
        }

        public async Task AdicionarHorariosAoProfissional(AdicionarHorariosProfissionalDTO dto)
        {
            var profissional = await _profissionalRepository.MostrarPorId(dto.IdProfissional);
            if (profissional == null)
            {
                throw new KeyNotFoundException("Profissional não encontrado");
            }

            foreach (var idHorario in dto.IdHorarios)
            {
                var horario = await _horarioRepository.MostrarPorId(idHorario);
                if (horario == null)
                {
                    throw new KeyNotFoundException($"Horário com Id {idHorario} não encontrado");
                }

                var horarioFuncionario = new HorarioFuncionario
                {
                    IdProfissional = dto.IdProfissional,
                    IdHorario = idHorario
                };

                await _horarioFuncionarioRepository.Criar(horarioFuncionario);
            }
        }
    }
}
