using Karapinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Shared.IRepository
{
    public interface IUtilizadorRepository:IGenericRepository<Utilizador>
    {
       Task<Utilizador> MostrarPorUsername(string username);
    }
     

}
