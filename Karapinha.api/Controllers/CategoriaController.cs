using Karapinha.DTO;
using Karapinha.Services;
using Karapinha.Shared.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karapinha.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ListarCategoriaPorId(int id)
        {
            return Ok(await _service.ListarPorId(id));
        }

        [HttpGet]
        public async Task<ActionResult> ListarCategorias()
        {
            return Ok(await _service.ListarTodasCategorias());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ApagarCategoria(int id)
        {
            return Ok(await _service.ApagarCategoria(id));
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarCategoria(CategoriaAdicionarDTO categoriaAdicionarDTO)
        {
            return Ok(await _service.AdicionarCategoria(categoriaAdicionarDTO));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarCategoria(int id, CategoriaAtualizarDTO categoriaAtualizarDTO)
        {
            return Ok(await _service.AtualizarCategoria(id,categoriaAtualizarDTO));
        }

        [HttpPut("BloquearCategoria/{id}")]
        public async Task<ActionResult> AtivarUtilizador(int id)
        {
            return Ok(await _service.BloquearCategoria(id));
        }

    }
}
