using Karapinha.DTO;
using Karapinha.Services;
using Karapinha.Shared.IService;
using Microsoft.AspNetCore.Mvc;

namespace Karapinha.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoService _servicoService;

        public ServicoController(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult> AdicionarUtilizador(ServicoAdicionarDTO servicoAdicionarDTO)
        {
            var resultado = await _servicoService.AdicionarServico(servicoAdicionarDTO);
            return Ok(resultado);
        }

        [HttpDelete("Apagar/{id}")]
        public async Task<ActionResult> ApagarUtilizador(int id)
        {
            var resultado = await _servicoService.ApagarServico(id);
            return Ok(resultado);
        }

        [HttpGet("ListarTodos")]
        public async Task<ActionResult> ListarTodosUtilizadores()
        {
            var resultado = await _servicoService.ListarTodosServicos();
            return Ok(resultado);
        }

        [HttpGet("Mostrar/{id}")]
        public async Task<ActionResult> MostrarUtilizadorPorId(int id)
        {
            var resultado = await _servicoService.MostrarPorID(id);
            return Ok(resultado);
        }
    }
}
