using Karapinha.DTO;
using Karapinha.Services;
using Karapinha.Shared.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karapinha.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalService _profissionalService;

        public ProfissionalController(IProfissionalService profissionalService)
        {
            _profissionalService = profissionalService;
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarUtilizador(ProfissionalAdicionarDTO profissionalAdicionarDTO)
        {
            return Ok(await _profissionalService.AdicionarProfissional(profissionalAdicionarDTO));
        }

        [HttpGet]
        public async Task<ActionResult> ListarTodosUtilizadores()
        {
            return Ok(await _profissionalService.ListarTodosProfissionais());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ApagarUtilizador(int id)
        {
            return Ok(await _profissionalService.ApagarProfissional(id));
        }

        [HttpPost("adicionar-horarios")]
        public async Task<IActionResult> AdicionarHorariosAoProfissional([FromBody] AdicionarHorariosProfissionalDTO dto)
        {
            try
            {
                await _profissionalService.AdicionarHorariosAoProfissional(dto);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("listarProfissionalComHorarios")]
        public async Task<ActionResult<List<ProfissionalComHorariosDTO>>> GetProfissionaisComHorarios()
        {
            var result = await _profissionalService.ObterProfissionaisComHorarios();
            return Ok(result);
        }

    }

}
