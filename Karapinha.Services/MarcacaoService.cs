﻿using Karapinha.DAL;
using Karapinha.DAL.Repositories;
using Karapinha.DTO;
using Karapinha.Model;
using Karapinha.Service;
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

    }
}
