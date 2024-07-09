using Karapinha.DAL;
using Karapinha.DAL.Repositories;
using Karapinha.DTO;
using Karapinha.Model;
using Karapinha.Service;
using Karapinha.Shared.IRepository;
using Karapinha.Shared.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Services
{
    public class MarcacaoService : IMarcacaoService
    {
        private readonly KarapinhaContext _context;
        private readonly IMarcacaoRepository _marcacaoRepository;
        private readonly IServicoRepository _servicoRepository;
        private readonly IUtilizadorRepository _utilizadorRepository;
        private readonly IEmailService _emailService;

        public MarcacaoService(
            KarapinhaContext context,
            IMarcacaoRepository marcacaoRepository,
            IUtilizadorRepository utilizadorRepository,
            IEmailService emailService,
            IServicoRepository servicoRepository)
        {
            _context = context;
            _marcacaoRepository = marcacaoRepository;
            _servicoRepository = servicoRepository;
            _utilizadorRepository = utilizadorRepository;
            _emailService = emailService;
        }
        public async Task<bool> AceitarPedidoDeMarcacao(int id)
        {
            var marcacao = await _marcacaoRepository.MostrarPorId(id);
            if (marcacao == null)
            {
                return false;
            }

            var utilizadorId = marcacao.IdUtilizador;
            if (utilizadorId == null)
            {
                return false;
            }

            int userId = utilizadorId.Value;

            var utilizador = await _utilizadorRepository.MostrarPorId(userId);
            if (utilizador == null)
            {
                return false;
            }

            marcacao.EstadoDeMarcacao = true;
            await _emailService.SendEmailAsync(utilizador.Email, "Estado da Marcação", "A sua marcação foi aceite !");
            return await _marcacaoRepository.Atualizar(marcacao);
        }
        public async Task<bool> AtualizarDataMarcacao(int idMarcacao, ActualizarDataMarcacaoDTO dto)
        {
            var marcacao = await _marcacaoRepository.MostrarPorId(idMarcacao);
            if (marcacao == null)
            {
                return false; 
            }

            marcacao.DataDeMarcacao = dto.NovaData;
            return  await _marcacaoRepository.Atualizar(marcacao);
 
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
            
            var novaMarcacao = new Marcacao
            {
                DataDeMarcacao = marcacaoDTO.DataDeMarcacao,
                PrecoDaMarcacao = marcacaoDTO.PrecoDaMarcacao,
                IdUtilizador = marcacaoDTO.IdUtilizador,
                EstadoDeMarcacao = false, 
                ListaMarcacoes = new List<MarcacaoServico>()
            };

            
            foreach (var marcacaoServicoDTO in marcacaoDTO.ListaMarcacoes)
            {
                var novoMarcacaoServico = new MarcacaoServico
                {
                    IdServico = marcacaoServicoDTO.IdServico,
                    IdProfissional = marcacaoServicoDTO.IdProfissional,
                    DataMarcacao = marcacaoServicoDTO.DataMarcacao,
                    Horario = marcacaoServicoDTO.HoraMarcacao
                };

               
                novaMarcacao.ListaMarcacoes.Add(novoMarcacaoServico);
            }

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
                        HoraMarcacao = ms.Horario
                    }).ToList()
                };

                marcacoesComServicosDTO.Add(marcacaoDTO);
            }

            return marcacoesComServicosDTO;
        }
        public async Task<List<MarcacaoServicoDTO>> ListarPorProfissionalData(int idProfissional, DateOnly data)
        {
            var marcacoes = await _context.Marcacoes
                .Include(m => m.ListaMarcacoes)
                .Where(m => m.ListaMarcacoes.Any(ms => ms.IdProfissional == idProfissional && ms.DataMarcacao == data))
                .ToListAsync();

            var marcacoesDTO = marcacoes.SelectMany(m => m.ListaMarcacoes
                .Where(ms => ms.IdProfissional == idProfissional && ms.DataMarcacao == data)
                .Select(ms => new MarcacaoServicoDTO
                {
                    IdMarcacaoServico = ms.IdMarcacaoServico,
                    IdServico = ms.IdServico,
                    IdProfissional = ms.IdProfissional,
                    DataMarcacao = ms.DataMarcacao,
                    HoraMarcacao = ms.Horario
                })
            ).ToList();

            return marcacoesDTO;
        }

        public async Task<List<ProfissionalMaisRequisitadoDTO>> ListarProfissionaisMaisRequisitados()
        {
            var profissionaisMaisRequisitados = await _context.Marcacoes
                .Include(m => m.ListaMarcacoes)
                .SelectMany(m => m.ListaMarcacoes)
                .GroupBy(ms => ms.IdProfissional)
                .Select(g => new
                {
                    IdProfissional = g.Key,
                    TotalMarcacoes = g.Count()
                })
                .OrderByDescending(g => g.TotalMarcacoes)
                .Take(5)
                .ToListAsync();

            var profissionaisDTO = new List<ProfissionalMaisRequisitadoDTO>();

            foreach (var profissional in profissionaisMaisRequisitados)
            {
                var profissionalInfo = await _context.Profissionais
                    .Where(p => p.IdProfissional == profissional.IdProfissional)
                    .Select(p => new ProfissionalMaisRequisitadoDTO
                    {
                        IdProfissional = p.IdProfissional,
                        NomeProfissional = p.NomeCompleto, // Supondo que existe uma propriedade "Nome" na entidade Profissional
                        TotalMarcacoes = profissional.TotalMarcacoes
                    })
                    .FirstOrDefaultAsync();

                if (profissionalInfo != null)
                {
                    profissionaisDTO.Add(profissionalInfo);
                }
            }

            return profissionaisDTO;
        }
        public async Task<ServicoSolicitadoDTO> ObterServicoMaisSolicitado()
        {
            var servicoMaisSolicitado = await _context.Marcacoes
                .Include(m => m.ListaMarcacoes)
                .SelectMany(m => m.ListaMarcacoes)
                .GroupBy(ms => ms.IdServico)
                .OrderByDescending(g => g.Count())
                .Select(g => new ServicoSolicitadoDTO
                {
                    IdServico = g.Key,
                    NomeServico = g.FirstOrDefault().Servico.TipoDeServico, 
                    TotalMarcacoes = g.Count()
                })
                .FirstOrDefaultAsync();

            return servicoMaisSolicitado;
        }
        public async Task<ServicoSolicitadoDTO> ObterServicoMenosSolicitado()
        {
            var servicoMenosSolicitado = await _context.Marcacoes
                .Include(m => m.ListaMarcacoes)
                .SelectMany(m => m.ListaMarcacoes)
                .GroupBy(ms => ms.IdServico)
                .OrderBy(g => g.Count())
                .Select(g => new ServicoSolicitadoDTO
                {
                    IdServico = g.Key,
                    NomeServico = g.FirstOrDefault().Servico.TipoDeServico, 
                    TotalMarcacoes = g.Count()
                })
                .FirstOrDefaultAsync();

            return servicoMenosSolicitado;
        }
        public async Task<ValorFaturadoDTO> ObterValorFaturadoDiaCorrente()
        {
            var hoje = DateOnly.FromDateTime(DateTime.Today);
            var valorFaturado = await _context.Marcacoes
                .Where(m => m.DataDeMarcacao == hoje)
                .SumAsync(m => m.PrecoDaMarcacao);

            return new ValorFaturadoDTO { Data = hoje, Valor = valorFaturado };
        }
        public async Task<ValorFaturadoDTO> ObterValorFaturadoOntem()
        {
            var ontem = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));
            var valorFaturado = await _context.Marcacoes
                .Where(m => m.DataDeMarcacao == ontem)
                .SumAsync(m => m.PrecoDaMarcacao);

            return new ValorFaturadoDTO { Data = ontem, Valor = valorFaturado };
        }
        public async Task<ValorFaturadoDTO> ObterValorFaturadoMesCorrente()
        {
            var inicioMes = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, 1);
            var proximoMes = inicioMes.AddMonths(1);
            var valorFaturado = await _context.Marcacoes
                .Where(m => m.DataDeMarcacao >= inicioMes && m.DataDeMarcacao < proximoMes)
                .SumAsync(m => m.PrecoDaMarcacao);

            return new ValorFaturadoDTO { Data = inicioMes, Valor = valorFaturado };
        }
        public async Task<ValorFaturadoDTO> ObterValorFaturadoMesPassado()
        {
            var inicioMesPassado = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
            var inicioMesCorrente = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, 1);
            var valorFaturado = await _context.Marcacoes
                .Where(m => m.DataDeMarcacao >= inicioMesPassado && m.DataDeMarcacao < inicioMesCorrente)
                .SumAsync(m => m.PrecoDaMarcacao);

            return new ValorFaturadoDTO { Data = inicioMesPassado, Valor = valorFaturado };
        }
        public async Task<List<MarcacaoPorMesDTO>> ListarMarcacoesPorMes()
        {
            var marcacoes = await _context.Marcacoes
                .Include(m => m.ListaMarcacoes)
                .ThenInclude(ms => ms.Profissional)
                .Include(m => m.ListaMarcacoes)
                .ThenInclude(ms => ms.Servico)
                .Include(m => m.Utilizador)
                .ToListAsync();

            var marcacoesPorMes = marcacoes
                .GroupBy(m => new { m.DataDeMarcacao.Year, m.DataDeMarcacao.Month })
                .Select(g => new MarcacaoPorMesDTO
                {
                    MesAno = $"{g.Key.Month:00}/{g.Key.Year}",
                    Marcacoes = g.SelectMany(m => m.ListaMarcacoes
                        .Where(ms => ms.Profissional != null && ms.Servico != null && m.Utilizador != null)
                        .Select(ms => new MarcacaoDetalhadaDTO
                        {
                            DataMarcacao = m.DataDeMarcacao,
                            Profissional = ms.Profissional?.NomeCompleto ?? "N/A",
                            Cliente = m.Utilizador?.NomeCompleto ?? "N/A",
                            Servico = ms.Servico?.TipoDeServico ?? "N/A"
                        })).ToList()
                })
                .OrderBy(m => m.MesAno) 
                .ToList();

            return marcacoesPorMes;
        }

    }
}
