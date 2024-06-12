using Karapinha.DTO;
using Karapinha.Model;
using Karapinha.Shared.IRepository;
using Karapinha.Shared.IService;


namespace Karapinha.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AdicionarCategoria(CategoriaAdicionarDTO categoriaAdicionarDTO)
        {
            var categoria = new Categoria()
            {
                Tipo = categoriaAdicionarDTO.Tipo,
            };
            return await _repository.Criar(categoria);
        }

        public async Task<bool> ApagarCategoria(int id)
        {
            var categoria = await _repository.MostrarPorId(id);
            if (categoria != null)
            {
                return await _repository.Apagar(categoria);
            }
            return false;
        }

        public async Task <bool> AtualizarCategoria(int id,CategoriaAtualizarDTO categoriaAtualizarDTO)
        {
            var categoria = await _repository.MostrarPorId(id);

            if (categoria == null)
            {
                return false;
            }

                categoria.Tipo = categoriaAtualizarDTO.Tipo;

                return await _repository.Atualizar(categoria);
            }

        public async Task<Categoria> ListarPorId(int id)
        {
            return await _repository.MostrarPorId(id);
        }

        public async Task<List<Categoria>> ListarTodasCategorias()
        {
            return await _repository.Listar();
        }
    }

 }

