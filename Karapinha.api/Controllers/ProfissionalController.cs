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
    }
}
