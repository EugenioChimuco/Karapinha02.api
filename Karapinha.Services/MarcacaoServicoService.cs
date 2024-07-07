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

        public async Task<bool> AdicionarMarcacaoServico(MarcacaoServicoDTO marcacaoServicoDTO)
        {
            try
            {
                var marcacaoServico = new MarcacaoServico
                {
                    IdServico = marcacaoServicoDTO.IdServico,
                    IdProfissional = marcacaoServicoDTO.IdProfissional,
                    DataMarcacao = marcacaoServicoDTO.DataMarcacao, 
                    IdHorario = marcacaoServicoDTO.HoraMarcacao,

                };

                await _repository.Criar(marcacaoServico);
                return true;
            }
            catch (Exception)
            {
                // Lidar com exceções, logar, etc.
                return false;
            }
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
