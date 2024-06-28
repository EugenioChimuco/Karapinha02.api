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
        public async Task<ActionResult> AdicionarUtilizador([FromForm] ProfissionalAdicionarDTO profissionalAdicionarDTO)
        {
            if (profissionalAdicionarDTO.Foto != null)
            {
                var caminhoFoto = await SalvarFotoAsync(profissionalAdicionarDTO.Foto);
                profissionalAdicionarDTO.FotoPath = caminhoFoto; 
            }
            else
            {
                profissionalAdicionarDTO.FotoPath = null; 
            }

            return Ok(await _profissionalService.AdicionarProfissional(profissionalAdicionarDTO));
        }

        private async Task<string> SalvarFotoAsync(IFormFile foto)
        {
            var pastaUpload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imgProfissionais");

            if (!Directory.Exists(pastaUpload))
            {
                Directory.CreateDirectory(pastaUpload);
            }

            // Gera um nome de arquivo único mais curto
            var nomeArquivoUnico = Guid.NewGuid().ToString().Substring(0, 8) + Path.GetExtension(foto.FileName);
            var caminhoArquivo = Path.Combine(pastaUpload, nomeArquivoUnico);

            using (var fileStream = new FileStream(caminhoArquivo, FileMode.Create))
            {
                await foto.CopyToAsync(fileStream);
            }

            return $"/imgProfissionais/{nomeArquivoUnico}";
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
