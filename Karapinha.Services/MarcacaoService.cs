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
    public class MarcacaoService : IMarcacaoService
    {
        private readonly IMarcacaoRepository _repository;

        public MarcacaoService(IMarcacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AceitarPedidoDeMarcacao(int id)
        {
            var marcacao = await _repository.MostrarPorId(id);
            if (marcacao == null)
            {
                return false;
            }
            marcacao.EstadoDeMarcacao = true;


            return await _repository.Atualizar(marcacao);
        }

        public async Task<bool> AdicionarMarcacao(AdicionarMarcacaoDTO adicionarMarcacaoDTO)
        {
            var marcacao = new Marcacao(
                idMarcacao: 0, 
                dataDeMarcacao: adicionarMarcacaoDTO.DataDeMarcacao,
                idUtilizador: adicionarMarcacaoDTO.IdUtilizador,
                precoDaMarcacao: adicionarMarcacaoDTO.PrecoDaMarcacao
            )
            {
                EstadoDeMarcacao = false,
            };

            return await _repository.Criar(marcacao);
        }

        public async Task<Marcacao> MostrarMarcacaoPorId(int id)
        {
            return await _repository.MostrarPorId(id);
        }

        public async Task<List<Marcacao>> MostrarTodasMarcacoes()
        {
            return await _repository.Listar();
        }
    }
}
