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
    public class ProfissionalService : IProfissionalService
    {
        private readonly IProfissionalRepository _profissionalRepository;
        public ProfissionalService(IProfissionalRepository profissionalRepository)
        {
            _profissionalRepository = profissionalRepository;
        }
        public async Task<bool> AdicionarProfissional(ProfissionalAdicionarDTO profissionalAdicionarDTO)
        {
            var profissional = new Profissional()
            {
                NomeCompleto = profissionalAdicionarDTO.NomeCompleto,
                Email = profissionalAdicionarDTO.Email,
                BI = profissionalAdicionarDTO.Bi,
                Phone = profissionalAdicionarDTO.Phone,
                Foto = profissionalAdicionarDTO.Foto,
                IdCategoria = profissionalAdicionarDTO.IdCategoria
            
            };

            return await _profissionalRepository.Criar(profissional);
   
        }

        public async Task<bool> ApagarProfissional(int id)
        {
            var profissinal = await _profissionalRepository.MostrarPorId(id);
            if (profissinal == null)
            {
                return false;
            }
            return await _profissionalRepository.Apagar(profissinal);
        }

        public async Task<List<Profissional>> ListarTodosProfissionais()
        {
            return await _profissionalRepository.Listar();
        }

    }
}
