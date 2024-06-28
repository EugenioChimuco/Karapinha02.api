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
        public async Task<ActionResult> AdicionarUtilizador([FromForm]ServicoAdicionarDTO servicoAdicionarDTO)
        {
            if (servicoAdicionarDTO.Foto !=null)
            {
                var caminhoFoto = await SalvarFotoAsync(servicoAdicionarDTO.Foto);
                servicoAdicionarDTO.FotoPath = caminhoFoto;
            }
            else
            {
                servicoAdicionarDTO.FotoPath = null;
            }
            return Ok(await _servicoService.AdicionarServico(servicoAdicionarDTO));
        }

        private async Task<string> SalvarFotoAsync(IFormFile foto)
        {
            var pastaUpload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imgServicos");

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
            return $"/imgServicos/{nomeArquivoUnico}";
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
