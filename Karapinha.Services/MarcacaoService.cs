using Karapinha.DAL;
using Karapinha.DAL.Repositories;
using Karapinha.DTO;
using Karapinha.Model;
using Karapinha.Shared.IRepository;
using Karapinha.Shared.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Services
{
    public class MarcacaoService : IMarcacaoService
    {
        private readonly KarapinhaContext _context;
        private readonly IMarcacaoServicoRepository _marcacaoServicoRepository;
        private readonly IMarcacaoRepository _marcacaoRepository;
        private readonly IServicoRepository _servicoRepository;

        public MarcacaoService(KarapinhaContext context, IMarcacaoRepository marcacaoRepository, IMarcacaoServicoRepository marcacaoServicoRepository, IServicoRepository servicoRepository)
        {
            _context = context;
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
        public async Task<bool> CriarMarcacaoComServicos(MarcacaoDTO marcacaoDTO)
        {
            // Cria uma nova entidade de Marcacao
            var novaMarcacao = new Marcacao
            {
                DataDeMarcacao = marcacaoDTO.DataDeMarcacao,
                PrecoDaMarcacao = marcacaoDTO.PrecoDaMarcacao,
                IdUtilizador = marcacaoDTO.IdUtilizador,
                EstadoDeMarcacao = false, // Por padrão, assume como não concluída
                ListaMarcacoes = new List<MarcacaoServico>()
            };

            // Adiciona os serviços à marcação
            foreach (var marcacaoServicoDTO in marcacaoDTO.ListaMarcacoes)
            {
                var novoMarcacaoServico = new MarcacaoServico
                {
                    IdServico = marcacaoServicoDTO.IdServico,
                    IdProfissional = marcacaoServicoDTO.IdProfissional,
                    DataMarcacao = marcacaoServicoDTO.DataMarcacao,
                    IdHorario = marcacaoServicoDTO.HoraMarcacao
                };

                // Adiciona o novo MarcacaoServico à lista de MarcacaoServico da novaMarcacao
                novaMarcacao.ListaMarcacoes.Add(novoMarcacaoServico);
            }

            // Cria a marcação no banco de dados
            var criadaComSucesso = await _marcacaoRepository.Criar(novaMarcacao);

            return criadaComSucesso;
        }

        public async Task<List<MarcacaoComServicosDTO>> ListarMarcacoesComServicos()
        {
            var marcacoes = await _context.Marcacoes.Include(m => m.ListaMarcacoes).ToListAsync();

            var marcacoesComServicosDTO = new List<MarcacaoComServicosDTO>();

            foreach (var marcacao in marcacoes)
            {
                var marcacaoDTO = new MarcacaoComServicosDTO
                {
                    IdMarcacao = marcacao.IdMarcacao,
                    DataDeMarcacao = marcacao.DataDeMarcacao,
                    PrecoDaMarcacao = marcacao.PrecoDaMarcacao,
                    EstadoDeMarcacao = marcacao.EstadoDeMarcacao,
                    IdUtilizador = marcacao.IdUtilizador,
                    ListaMarcacoes = marcacao.ListaMarcacoes.Select(ms => new MarcacaoServicoDTO
                    {
                        IdMarcacaoServico = ms.IdMarcacaoServico,
                        IdServico = ms.IdServico,
                        IdProfissional = ms.IdProfissional,
                        DataMarcacao = ms.DataMarcacao,
                        HoraMarcacao = ms.IdHorario
                    }).ToList()
                };

                marcacoesComServicosDTO.Add(marcacaoDTO);
            }

            return marcacoesComServicosDTO;
        }



    }
}
