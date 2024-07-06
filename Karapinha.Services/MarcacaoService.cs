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
    public class MarcacaoService : IMarcacaoService
    {
        private readonly IMarcacaoServicoRepository _marcacaoServicoRepository;
        private readonly IMarcacaoRepository _marcacaoRepository;
        private readonly IServicoRepository _servicoRepository;

        public MarcacaoService(IMarcacaoRepository marcacaoRepository, IMarcacaoServicoRepository marcacaoServicoRepository, IServicoRepository servicoRepository)
        {
            _marcacaoRepository = marcacaoRepository;
            _marcacaoServicoRepository = marcacaoServicoRepository;
            _servicoRepository = servicoRepository;
        }

        public async Task<bool> AceitarPedidoDeMarcacao(int id)
        {
            var marcacao = await _marcacaoRepository.MostrarPorId(id);
            if (marcacao == null)
            {
                return false;
            }
            marcacao.EstadoDeMarcacao = true;
            return await _marcacaoRepository.Atualizar(marcacao);
        }

        public async Task<MarcacaoDTO> AdicionarMarcacao(MarcacaoDTO adicionarMarcacaoDTO)
        {
            var marcacao = new Marcacao(
                dataDeMarcacao: adicionarMarcacaoDTO.DataDeMarcacao,
                idUtilizador: adicionarMarcacaoDTO.IdUtilizador,
                precoDaMarcacao: adicionarMarcacaoDTO.PrecoDaMarcacao
            )
            {
                EstadoDeMarcacao = false,
            };

            await _marcacaoRepository.Criar(marcacao);

            foreach (var servicoId in adicionarMarcacaoDTO.ServicoIds)
            {
                var marcacaoServico = new MarcacaoServico
                {
                    IdMarcacao = marcacao.IdMarcacao,
                    IdServico = servicoId
                };

                await _marcacaoServicoRepository.Criar(marcacaoServico);
            }

            return adicionarMarcacaoDTO;
        }

        public async Task<Marcacao> MostrarMarcacaoPorId(int id)
        {
            var marcacao = await _marcacaoRepository.MostrarPorId(id);
            if (marcacao == null) return null;

            return marcacao;
        }

        public async Task<List<Marcacao>> MostrarTodasMarcacoes()
        {
            return await _marcacaoRepository.Listar();
        }

        public async Task<List<MarcacaoComServicosDTO>> ObterMarcacoesComServicos()
        {
            var marcacoes = await _marcacaoRepository.Listar();
            var marcacaoServicos = await _marcacaoServicoRepository.Listar();
            var servicos = await _servicoRepository.Listar();

            if (marcacoes == null || marcacaoServicos == null || servicos == null)
            {
                throw new InvalidOperationException("One of the repositories returned null.");
            }

            var result = from marcacao in marcacoes
                         join marcacaoServico in marcacaoServicos on marcacao.IdMarcacao equals marcacaoServico.IdMarcacao
                         join servico in servicos on marcacaoServico.IdServico equals servico.IdServico
                         select new
                         {
                             marcacao.IdMarcacao,
                             marcacao.DataDeMarcacao,
                             marcacao.PrecoDaMarcacao,
                             marcacao.EstadoDeMarcacao,
                             marcacao.IdUtilizador,
                             servico.IdServico,
                             servico.TipoDeServico,
                             servico.PrecoDoServico,
                         };

            if (result == null)
            {
                throw new InvalidOperationException("Query result is null.");
            }

            var groupedResult = result
                .GroupBy(m => new { m.IdMarcacao, m.DataDeMarcacao, m.PrecoDaMarcacao, m.EstadoDeMarcacao, m.IdUtilizador })
                .Select(g => new MarcacaoComServicosDTO
                {
                    IdMarcacao = g.Key.IdMarcacao,
                    DataDeMarcacao = g.Key.DataDeMarcacao,
                    PrecoDaMarcacao = g.Key.PrecoDaMarcacao,
                    EstadoDeMarcacao = g.Key.EstadoDeMarcacao,
                    IdUtilizador = g.Key.IdUtilizador,
                    Servicos = g.Select(s => new ServicoDTO
                    {
                        IdServico = s.IdServico,
                        TipoDeServico = s.TipoDeServico,
                        PrecoDoServico = s.PrecoDoServico,
                    }).ToList()
                }).ToList();

            return groupedResult;
        }
    }
}
