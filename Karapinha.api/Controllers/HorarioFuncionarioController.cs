using Karapinha.DTO;
using Karapinha.Services;
using Karapinha.Shared.IService;
using Microsoft.AspNetCore.Mvc;

namespace Karapinha.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioFuncionarioController : ControllerBase
    {
        private readonly IHorarioFuncionarioService _horarioService;

        public HorarioFuncionarioController(IHorarioFuncionarioService horarioService)
        {
            _horarioService = horarioService;
        }

        [HttpPost("AdicionarHoras")]
        public async Task<ActionResult> AdicionarHoras(AdicionarHorarioFuncionarioDTO adicionarHorarioFuncionarioDTO)
        {
            var result = await _horarioService.AdicionarHora(adicionarHorarioFuncionarioDTO);
            return Ok(result);
        }

        [HttpGet("ListarHorarios")]
        public async Task<ActionResult> ListarCategorias()
        {
            var result = await _horarioService.ListarTodasHoras();
            return Ok(result);
        }
    }
}
