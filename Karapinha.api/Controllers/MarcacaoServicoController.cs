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

        [HttpPost]
        public async Task<IActionResult> AdicionarMarcacaoServico([FromBody] MarcacaoServicoDTO marcacaoServicoDTO)
        {
            try
            {
                var resultado = await _marcacaoServico.AdicionarMarcacaoServico(marcacaoServicoDTO);
                if (resultado)
                {
                    return Ok(new { message = "Marcacao de servico adicionada com sucesso." });
                }
                else
                {
                    return BadRequest(new { message = "Falha ao adicionar marcacao de servico." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }


    }
}
