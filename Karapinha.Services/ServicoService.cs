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
    public class ServicoService: IServicoService
    {
        private readonly IServicoRepository _servicoRepository;
        public ServicoService(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<bool> AdicionarServico(ServicoAdicionarDTO ServicoAdicionarDTO)
        {
            var servico = new Servico()
            {
                TipoDeServico = ServicoAdicionarDTO.TipoDeServico,
                PrecoDoServico = ServicoAdicionarDTO.PrecoDoServico,
                IdCategoria = ServicoAdicionarDTO.IdCategoria,
            };

            return await _servicoRepository.Criar(servico);
        }

        public async Task<bool> ApagarServico(int id)
        {
            var servico = await _servicoRepository.MostrarPorId(id);
            if (servico == null)
            {
                return false;
            }
            return await _servicoRepository.Apagar(servico);
        }

        public async Task<bool> AtualizarServico(int id, ServicoActualizarDTO ServicoAtualizarDTO)
        {
            var servico = await _servicoRepository.MostrarPorId(id);

            if (servico == null)
            {
                return false;
            }

            servico.TipoDeServico = ServicoAtualizarDTO.TipoDeServico;
            servico.PrecoDoServico = ServicoAtualizarDTO.PrecoDoServico;
            servico.IdCategoria = ServicoAtualizarDTO.IdCategoria;

            return await _servicoRepository.Atualizar(servico);

        }

        async Task<List<Servico>> IServicoService.ListarTodosServicos()
        {
            return await _servicoRepository.Listar();
        }

        async Task<bool> IServicoService.MostrarPorID(int id)
        {
            var servico = await _servicoRepository.MostrarPorId(id);
            if (servico == null)
            {
                return false;
            }
            return await _servicoRepository.Apagar(servico);
        }
    }

 

}
