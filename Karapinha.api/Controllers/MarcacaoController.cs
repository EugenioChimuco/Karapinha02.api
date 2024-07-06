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

        [HttpPost]
        public async Task<IActionResult> CriarMarcacao([FromBody] MarcacaoDTO marcacaoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _marcacaoService.AdicionarMarcacao(marcacaoDto);

            return CreatedAtAction(nameof(MostrarMarcacaoPorId), new { id = result.IdMarcacao }, result);
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

        [HttpGet("listarMarcacoesComServicos")]
        public async Task<IActionResult> ListarMarcacoesComServicos()
        {
            var marcacoesComServicos = await _marcacaoService.ObterMarcacoesComServicos();
            return Ok(marcacoesComServicos);
        }


    }
}
