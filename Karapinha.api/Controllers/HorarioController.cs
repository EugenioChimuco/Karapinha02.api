using Karapinha.DTO;
using Karapinha.Shared.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karapinha.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly IHorarioService horarioService;

        public HorarioController(IHorarioService horarioService)
        {
            this.horarioService = horarioService;
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarHoras(HorarioAdicionarDTO horarioAdicionarDTO)
        {
            return Ok(await horarioService.AdicionarHora(horarioAdicionarDTO));
        }

        [HttpGet]
        public async Task<ActionResult> ListarCategorias()
        {
            return Ok(await horarioService.ListarTodasHoras());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ApagarCategoria(int id)
        {
            return Ok(await horarioService.ApagarHora(id));
        }
    }
}
