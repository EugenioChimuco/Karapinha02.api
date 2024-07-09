using Karapinha.DTO;
using Karapinha.Services;
using Karapinha.Shared.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karapinha.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcacaoController : ControllerBase
    {
        private readonly IMarcacaoService _marcacaoService;

        public MarcacaoController(IMarcacaoService marcacaoService)
        {
            _marcacaoService = marcacaoService;
        }

        [HttpPut("AceitarPedidoDeMarcacao/{id}")]
        public async Task<ActionResult> AceitarMarcacao(int id)
        {
            return Ok(await _marcacaoService.AceitarPedidoDeMarcacao(id));
        }

        [HttpGet]
        public async Task<ActionResult> MostrarTodasMarcacoes()
        {
            return Ok(await _marcacaoService.MostrarTodasMarcacoes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> MostrarMarcacaoPorId(int id)
        {
            return Ok(await _marcacaoService.MostrarMarcacaoPorId(id));
        }

        [HttpPost("criar-com-servicos")]
        public async Task<IActionResult> CriarMarcacaoComServicos([FromBody] MarcacaoDTO marcacaoDTO)
        {
            var resultado = await _marcacaoService.CriarMarcacaoComServicos(marcacaoDTO);
            if (resultado)
                return Ok("Marcação com serviços criada com sucesso.");
            else
                return BadRequest("Não foi possível criar a marcação com serviços.");
        }

        [HttpGet("marcacoes-com-servicos")]
        public async Task<ActionResult<List<MarcacaoComServicosDTO>>> ListarMarcacoesComServicos()
        {
            try
            {
                var marcacoesComServicos = await _marcacaoService.ListarMarcacoesComServicos();
                return Ok(marcacoesComServicos);
            }
            catch (Exception ex)
            {
                // Logar o erro
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao listar marcações com serviços: " + ex.Message);
            }
        }

        [HttpGet("ListarPorProfissionalData/{idProfissional}/{data}")]
        public async Task<ActionResult<List<MarcacaoServicoDTO>>> ListarPorProfissionalData(int idProfissional, DateOnly data)
        {
            try
            {
                var marcacoes = await _marcacaoService.ListarPorProfissionalData(idProfissional, data);
                if (marcacoes == null || !marcacoes.Any())
                {
                    return NotFound("Não foram encontradas marcações para o profissional e data fornecidos.");
                }

                return Ok(marcacoes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("atualizar-data/{idMarcacao}")]
        public async Task<IActionResult> AtualizarDataMarcacao(int idMarcacao, [FromBody] ActualizarDataMarcacaoDTO dto)
        {
            var atualizadaComSucesso = await _marcacaoService.AtualizarDataMarcacao(idMarcacao, dto);

            if (!atualizadaComSucesso)
            {
                return NotFound();
            }
            return Ok(); 
        }


    }
}
