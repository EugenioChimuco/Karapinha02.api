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
        public async Task<ActionResult> AgendarMarcacao(AdicionarMarcacaoDTO adicionarMarcacaoDTO)
        {
            return Ok(await _marcacaoService.AdicionarMarcacao(adicionarMarcacaoDTO));
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
    }
}
