using Karapinha.DTO;
using Karapinha.Model;
using Karapinha.Shared.IRepository;
using Karapinha.Shared.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karapinha.Services
{
    public class MarcacaoServicoService : IMarcacaoServico
    {
        private readonly IMarcacaoServicoRepository _repository;

        public MarcacaoServicoService(IMarcacaoServicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AdicionarMarcacaoServico(AdicionarMarcacaoServicoDTO adicionarMarcacaoServicoDTO)
        {
            var marcacao = new Model.MarcacaoServico()
            {
                IdServico = adicionarMarcacaoServicoDTO.IdServico,
                IdMarcacao = adicionarMarcacaoServicoDTO.IdMarcacao
            };
            return await _repository.Criar(marcacao);
        }

        public async Task<Model.MarcacaoServico> MostrarMarcacaoPorID(int id)
        {
            return await _repository.MostrarPorId(id);
        }

        public async Task<List<Model.MarcacaoServico>> MostrarTodasMarcacoes()
        {
            return await _repository.Listar();
        }
    }
}
