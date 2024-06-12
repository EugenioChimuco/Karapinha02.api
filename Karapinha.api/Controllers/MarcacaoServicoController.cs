using Karapinha.DTO;
using Karapinha.Services;
using Karapinha.Shared.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karapinha.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcacaoServicoController : ControllerBase
    {
        private readonly IMarcacaoServico _marcacaoServico;

        public MarcacaoServicoController(IMarcacaoServico marcacaoServico)
        {
            _marcacaoServico = marcacaoServico;
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarMarcacaoServico(AdicionarMarcacaoServicoDTO adicionarMarcacaoServicoDTO)
        {
            return Ok(await _marcacaoServico.AdicionarMarcacaoServico(adicionarMarcacaoServicoDTO));
        }

        [HttpGet]
        public async Task<ActionResult> ListarTodosUtilizadores()
        {
            return Ok(await _marcacaoServico.MostrarTodasMarcacoes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> MostrarMarcacoesPorId(int id)
        {
            return Ok(await _marcacaoServico.MostrarMarcacaoPorID(id));
        }

    }
}
