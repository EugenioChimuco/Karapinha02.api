using Karapinha.DTO;
using Karapinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Shared.IService
{
    public interface ICategoriaService
    {
        Task <Categoria> ListarPorId(int id);
        Task <List<Categoria>> ListarTodasCategorias();
        Task<bool> AtualizarCategoria(int id ,CategoriaAtualizarDTO categoriaAtualizarDTO);
        Task <bool> AdicionarCategoria(CategoriaAdicionarDTO categoriaAdicionarDTO);
        Task<bool> ApagarCategoria(int id);
        Task<bool> BloquearCategoria(int id);
    }
}
