using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Shared.IRepository
{
    public interface IGenericRepository<T>
    {
        Task <T> MostrarPorId(int id);
        Task <Boolean> Criar(T entity);
        Task <Boolean> Apagar(T entity);
        Task <Boolean> Atualizar(T entity);
        Task <List<T>> Listar();


    }
}
