using Karapinha.DTO;
using Karapinha.Services;
using Karapinha.Shared.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Karapinha.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadorController : ControllerBase
    {
        private readonly IUtilizadorService _utilizadorService;

        public UtilizadorController(IUtilizadorService utilizadorService)
        {
            this._utilizadorService = utilizadorService;
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarUtilizador(UtilizadorAdicionarDTO utilizadorAdicionarDTO)
        {
            return Ok(await _utilizadorService.AdicionarUtilizador(utilizadorAdicionarDTO));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ApagarUtilizador(int id)
        {
            return Ok(await _utilizadorService.ApagarUtilizador(id));
        }

        [HttpGet]
        public async Task<ActionResult> ListarTodosUtilizadores()
        {
            return Ok(await _utilizadorService.ListarTodosUsuarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> MostrarUtilizadorPorId(int id)
        {
            return Ok(await _utilizadorService.MostrarUtilizadorPorId(id));
        }

        
        [HttpPut("AtualizarUtilizador/{id}")]
        public async Task<ActionResult> AtualizarDados(int id, [FromBody] UtilizadorAtualizarDTO utilizadorAtualizarDTO)
        {
            return Ok(await _utilizadorService.AtualizarDadosDoUtilizador(id,utilizadorAtualizarDTO));
        }

        [HttpPut("AtivarConta/{id}")]
        public async Task<ActionResult> AtivarUtilizador(int id)
        {
            return Ok(await _utilizadorService.AtivarUtilizador(id));
        }

        
        [HttpPut("BloquearDesbloquearConta/{id}")]
        public async Task<ActionResult> Bloquear_e_DesbloquearConta(int id)
        {
            return Ok(await _utilizadorService.Bloquear_e_DesbloquearConta(id));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null || string.IsNullOrEmpty(loginDTO.Username) || string.IsNullOrEmpty(loginDTO.Password))
            {
                return BadRequest("Invalid login request");
            }

            var user = await _utilizadorService.Login(loginDTO.Username, loginDTO.Password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok(new
            {
                Id = user.IdUtilizador,
                Username = user.UserName,
                TipoDeUser = user.TipoDeUser,
                EstadoDoUtilizador = user.EstadoDoUtilizador,
                EstadoDaConta = user.EstadoDaConta
            });
        }

    }
}
